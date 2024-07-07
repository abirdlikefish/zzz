using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState_startMenu : GameState
{
    public GameState_startMenu(GameStateMachine gameStateMachine, Enums.EGameState eGameState) : base(gameStateMachine, eGameState)
    {
    }

    public override void EnterState()
    {
        Debug.Log("GameBegin");
        InputBuffer.Instance.UseUIActionMap();
    }

    public override void Update()
    {
        // return ;
        if(InputBuffer.Instance.IsBeginGame())
        {
            // Debug.Log("change game state to level selection");
            gameStateMachine.changeGameStateToLevelSelection();
        }
        else if(InputBuffer.Instance.IsExitGame())
        {
            Debug.Log("quit game");
            Application.Quit();
        }
    }
}
