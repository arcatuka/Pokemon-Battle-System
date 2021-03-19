using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName="Enemies", menuName="Enemy/Create Enemy")]
public class EnemiesStats : ScriptableObject {
    
    [SerializeField]
    string name;
    [TextArea]
    [SerializeField]
    string description;
    [SerializeField]
    Sprite frontSprite;
    [SerializeField]
    Sprite BackSprite;
    [SerializeField]
    
    EnemyType Type;

    //stats
    [SerializeField]
    int hp;
    [SerializeField]
    int attack;
    [SerializeField]
    int defense;
    [SerializeField]
    int speed;
    [SerializeField] 
    List<learnable> Learnablemove;


    public string Name
    {
        get {return name;}
    }

    public string Description{
        get {return description;}
    }
    public Sprite FrontSprite{
        get {return frontSprite;}
    }
    public Sprite backSprite{
        get {return BackSprite;}
    }
    public EnemyType type{
        get {return Type;}
    }

    public int HP{
        get {return hp;}
    }
    public int Attack{
        get {return attack;}
    }
    public int Defense{
        get {return defense;}
    }
    public int Speed {
        get {return speed;}
    }
    public List<learnable> LearnableMoves{get {return Learnablemove;}}
}
[System.Serializable]
public class learnable
{
    [SerializeField] UnityMove MoveBase;
    [SerializeField] int Level;
    public UnityMove Movebase{get {return MoveBase;}}
    public int level{get {return Level;}}

}
public enum EnemyType
    {
        normal,
        fire,
        water,
        grass

    }