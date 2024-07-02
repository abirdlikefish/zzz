using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_levelOn : GameState
{
    public CameraController cameraController ;
    public GameState_levelOn(GameStateMachine gameStateMachine, Enums.EGameState eGameState) : base(gameStateMachine, eGameState)
    {
        cameraController = new CameraController();
    }
    public override void EnterState()
    {
        gameStateMachine.gameManager.team.BegBattle(cameraController);
        gameStateMachine.gameManager.team_enemy.BegBattle();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public override void Update()
    {
        gameStateMachine.gameManager.team.ModifyAttribute();
        gameStateMachine.gameManager.team_enemy.ModifyAttribute();
        if(InputBuffer.Instance.IsStop())
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
