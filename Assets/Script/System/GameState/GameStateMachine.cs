using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateMachine 
{
    public GameState gameStateNow;
    public GameState gameStateNext ;
    public GameManager gameManager;

#region define game state
    private GameState gameState_levelOn ;
    private GameState gameState_levelSelection ;
    private GameState gameState_startMenu ;
#endregion

#region  init
    public GameStateMachine(GameManager gameManager , Enums.EGameState eGameState)
    {
        this.gameManager = gameManager;
        gameState_levelOn = new GameState_levelOn(this , Enums.EGameState.LevelOn);
        gameState_levelSelection = new GameState_levelSelection(this , Enums.EGameState.LevelSelection);
        gameState_startMenu = new GameState_startMenu(this , Enums.EGameState.StartMenu);

        if(eGameState == Enums.EGameState.StartMenu)
        {
            SceneManager.LoadScene("Start");
            gameStateNext = gameState_startMenu;
        }
        else if(eGameState == Enums.EGameState.LevelSelection)
        {
            SceneManager.LoadScene("LevelSelection");
            gameStateNext = gameState_levelSelection;
        }
        else if(eGameState == Enums.EGameState.LevelOn)
        {
            SceneManager.LoadScene("Level_forest");
            gameStateNext = gameState_levelOn;
        }
        else
        {
            Debug.Log("init gameStateMachine error");
        }
    }
#endregion

#region change state
    public void changeGameStateToLevelOn()
    {
        gameStateNow.ExitState();
        SceneManager.LoadScene("Level_forest");
        gameStateNext = gameState_levelOn;
    }
    public void changeGameStateToLevelSelection()
    {
        gameStateNow.ExitState();
        SceneManager.LoadScene("LevelSelection");
        gameStateNext = gameState_levelSelection;
    }
    public void changeGameStateToStartMenu()
    {
        gameStateNow.ExitState();
        SceneManager.LoadScene("Start");
        gameStateNext = gameState_startMenu;
        // Debug.Log("change gameState to start menu");
    }
#endregion
    public void Update()
    {
        if(gameStateNext  != null)
        {
            gameStateNow = gameStateNext;
            gameStateNow.EnterState();
            gameStateNext = null;
            return ;
        }
        gameStateNow.Update();
    }
}
