using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine 
{
    public GameState gameStateNow;
    public GameManager gameManager;

#region define gamestate
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
            gameStateNow = gameState_startMenu;
            gameStateNow.EnterState();
        }
        else if(eGameState == Enums.EGameState.LevelSelection)
        {
            gameStateNow = gameState_levelSelection;
            gameStateNow.EnterState();
        }
        else if(eGameState == Enums.EGameState.LevelOn)
        {
            gameStateNow = gameState_levelOn;
            gameStateNow.EnterState();
        }
        else
        {
            Debug.Log("init gameStateMachine error");
        }
    }
#endregion

#region change state
    private void changeGameState(GameState gameState)
    {
        gameStateNow.ExitState();
        gameStateNow = gameState;
        gameStateNow.EnterState();
    }
    public void changeGameStateToLevelOn()
    {
        changeGameState(gameState_levelOn);
    }
    public void changeGameStateToLevelSelection()
    {
        changeGameState(gameState_levelSelection);
    }
    public void changeGameStateToStartMenu()
    {
        changeGameState(gameState_startMenu);
    }
#endregion
    public void Update()
    {
        gameStateNow.Update();
    }
}
