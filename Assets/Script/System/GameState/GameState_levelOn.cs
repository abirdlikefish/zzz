using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState_levelOn : GameState
{
    public CameraController cameraController ;
    public GameObject stopMenu ;
    public GameObject endMenu ;
    public GameState_levelOn(GameStateMachine gameStateMachine, Enums.EGameState eGameState) : base(gameStateMachine, eGameState)
    {
        cameraController = new CameraController();
    }
    public override void EnterState()
    {
        InputBuffer.Instance.UseGamePlayActionMap();
        gameStateMachine.gameManager.team.BegBattle(cameraController);
        gameStateMachine.gameManager.team_enemy.BegBattle();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        stopMenu = GameObject.Find("StopMenu");
        endMenu = GameObject.Find("EndMenu");
        stopMenu.SetActive(false);
        endMenu.SetActive(false);

    }
    public override void ExitState()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public override void Update()
    {
    // return ;
        gameStateMachine.gameManager.team.ModifyAttribute();
        gameStateMachine.gameManager.team_enemy.ModifyAttribute();
        if(gameStateMachine.gameManager.team_enemy.enemyNum_survive == 0)
        {
            endMenu.SetActive(true);
            InputBuffer.Instance.UseStopMenuMap();
            Time.timeScale = 0;
            if(InputBuffer.Instance.IsReturn())
            {
                Time.timeScale = 1;
                VFX.Instance.Clean();
                gameStateMachine.changeGameStateToStartMenu();
            }

        }
        else if(InputBuffer.Instance.IsStop())
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            stopMenu.SetActive(true);
            Time.timeScale = 0;
            InputBuffer.Instance.UseStopMenuMap();
        }
        else if(InputBuffer.Instance.IsContinue())
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            stopMenu.SetActive(false);
            Time.timeScale = 1;
            InputBuffer.Instance.UseGamePlayActionMap();
        }
        else if(InputBuffer.Instance.IsReturn())
        {
            Time.timeScale = 1;
            gameStateMachine.changeGameStateToStartMenu();
        }
    }
}
