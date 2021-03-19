using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BattleState{
    Start,
    Playeraction,
    PlayerMove,
    EnemyMove,
    Busy

}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleBar PlayerHud;
    [SerializeField] BattleUnit EnemyUnit;
    [SerializeField] BattleBar EnemyHud;
    [SerializeField] BattleDialog dialogBox;
    BattleState State;
    int currentAction, currentMove;
    
    private void Start() {
       StartCoroutine(setupBattle());
    }
    public IEnumerator setupBattle()
    {
        playerUnit.Setup();
        EnemyUnit.Setup();
        PlayerHud.SetData(playerUnit.unit);
        EnemyHud.SetData(EnemyUnit.unit);
        dialogBox.SetMoveName(playerUnit.unit.moves);
        yield return dialogBox.TypeDialog($"A wild {EnemyUnit.unit.Base.name} appear");
        yield return new WaitForSeconds(1f);

        PlayerAction();

    }
    public void PlayerAction()
    {
        State = BattleState.Playeraction;
        StartCoroutine(dialogBox.TypeDialog($"What will {playerUnit.unit.Base.name} do"));
        dialogBox.enableActionSeletor(true);
    }

    void PlayerMove()
    {
        State = BattleState.PlayerMove;
        dialogBox.enableActionSeletor(false);
        dialogBox.enableDialogText(false);
        dialogBox.enableMoveSelector(true);
    }

    IEnumerator PerformPlayerMove()
    {

        State = BattleState.Busy;
        var move = playerUnit.unit.moves[currentMove];

        yield return dialogBox.TypeDialog($"{playerUnit.unit.Base.name} Used {move.Base.name}");

        yield return new WaitForSeconds(1f);


        bool isFainted = EnemyUnit.unit.TakeDamage(move, playerUnit.unit);
        yield return EnemyHud.UpdateHP();
        if (isFainted)
        {
            yield return dialogBox.TypeDialog($"{EnemyUnit.unit.Base.Name} Fainted");
        }
        else {
            StartCoroutine(enemyMove());
        }
    }

    IEnumerator enemyMove()
    {
        State = BattleState.EnemyMove;

        var move = EnemyUnit.unit.GetrandomMove();
        yield return dialogBox.TypeDialog($"{EnemyUnit.unit.Base.name} Used {move.Base.name}");

        yield return new WaitForSeconds(1f);


        bool isFainted = playerUnit.unit.TakeDamage(move, playerUnit.unit);
        yield return PlayerHud.UpdateHP();
        if (isFainted)
        {
            yield return dialogBox.TypeDialog($"{playerUnit.unit.Base.Name} Fainted");
        }
        else {
            PlayerAction();
        }
    }

    private void Update() {
        if(State == BattleState.Playeraction)
        {
            HandleActionSelector();
        }
        else if (State == BattleState.PlayerMove)
        {
            HandleMoveSelector();
        }
    }
    void HandleActionSelector()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentAction < 1)
                ++currentAction;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentAction > 0)
                --currentAction;
        }
        dialogBox.UpdateActionSelector(currentAction);

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if(currentAction == 0)
            {
                //Fight
                PlayerMove();
                
            }
            else if(currentAction == 1)
            {
                //Run
            }
        }
    }
    public void HandleMoveSelector()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(currentMove < playerUnit.unit.moves.Count -1)
                ++currentMove;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(currentMove > 0)
                --currentMove;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentMove < playerUnit.unit.moves.Count -2)
            {
                currentMove+=2;
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentMove >1)
            {
                currentMove -=2;
            }
        }

        dialogBox.UpdateMoveSelector(currentMove,playerUnit.unit.moves[currentMove]);
    
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            dialogBox.enableMoveSelector(false);
            dialogBox.enableDialogText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }
}
