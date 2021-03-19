using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit 
{
    // Start is called before the first frame update
    public EnemiesStats Base{get; set;}
    public int Level {get;set;}
    public int Hp {get; set;}
    public List<Move> moves{get;set;}
    public Unit(EnemiesStats pBase, int pLevel)
    {
        Base =pBase;
        Level = pLevel;
        Hp = MaxHP;

        //generate Move
        moves = new List<Move>();
        foreach(var move in Base.LearnableMoves)
        {
            if (move.level <= Level)
                moves.Add(new Move(move.Movebase));
            if (moves.Count >= 4)
            {
                break;
            }
        }
    }
    public int MaxHP
    {
        get { return Mathf.FloorToInt((Base.HP*Level)/100f) + 10;}
    }
    public int Attack{
        get {return Mathf.FloorToInt((Base.Attack*Level)/100f)+5;}
    }
    public int Defense{
        get { return Mathf.FloorToInt((Base.Defense*Level)/100f)+5;}
    }
    public int Speed{
        get {return Mathf.FloorToInt((Base.Speed+Level)/100f)+5;}
    }


    public bool TakeDamage(Move move, Unit Attacker)
    {
        float Modifiers =  Random.Range(0.85f, 1f);
        float a= (2*Attacker.Level +10)/250f;
        float d = a* move.Base.Power * ((float)Attacker.Attack/Defense) + 2;
        int damage = Mathf.FloorToInt(d * Modifiers);

        Hp-= damage;
        if(Hp < 0)
        {
            Hp = 0;
            return true;
        }
        return false;
    }

    public Move GetrandomMove()
    {
        int r = Random.Range(0,moves.Count);
        return moves[r];
    }
}
