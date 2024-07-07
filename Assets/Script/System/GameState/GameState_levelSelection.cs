using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState_levelSelection : GameState
{
    int piggyMan_bowNum;
    int piggyMan_daggerNum;
    Text text_piggyMan_bowNum;
    Text text_piggyMan_daggerNum;
    public GameState_levelSelection(GameStateMachine gameStateMachine, Enums.EGameState eGameState) : base(gameStateMachine, eGameState)
    {
    }
    public override void EnterState()
    {
        piggyMan_bowNum = 1;
        piggyMan_daggerNum = 1;
        text_piggyMan_bowNum = GameObject.Find("Num_piggyMan_bow").GetComponent<Text>();
        text_piggyMan_daggerNum = GameObject.Find("Num_piggyMan_dagger").GetComponent<Text>();
        text_piggyMan_daggerNum.text = piggyMan_daggerNum.ToString() ;
        text_piggyMan_bowNum.text = piggyMan_bowNum.ToString() ;
        gameStateMachine.gameManager.team_enemy.CleanEnemy();
        InputBuffer.Instance.UseSelectMenuMap();
    }

    public override void Update()
    {
        if(InputBuffer.Instance.IsAddPiggyMan_bow())
        {
            piggyMan_bowNum ++ ;
            if(piggyMan_bowNum > 5)
            {
                piggyMan_bowNum = 0;
                if(piggyMan_daggerNum == 0)
                    piggyMan_bowNum = 1;
            }
            text_piggyMan_bowNum.text = piggyMan_bowNum.ToString() ;
        }
        else if(InputBuffer.Instance.IsAddPiggyMan_dagger())
        {
            piggyMan_daggerNum ++ ;
            if(piggyMan_daggerNum > 5)
            {
                piggyMan_daggerNum = 0;
                if(piggyMan_bowNum == 0)
                    piggyMan_daggerNum = 1;
            }
            text_piggyMan_daggerNum.text = piggyMan_daggerNum.ToString() ;
        }
        else if(InputBuffer.Instance.IsLoadGame())
        {
            for(int i = 0 ; i < piggyMan_daggerNum ; i++)
            {
                gameStateMachine.gameManager.team_enemy.AddEnemy( Random.Range(0 , 4), 0 , 1);
            }
            {
            for(int i = 0 ; i < piggyMan_bowNum ; i++)
                gameStateMachine.gameManager.team_enemy.AddEnemy( Random.Range(0 , 4), 1 , 1);
            }
            Debug.Log("dagger num: " + piggyMan_daggerNum + "bow num: " + piggyMan_bowNum );
            gameStateMachine.changeGameStateToLevelOn();
        }
    }
}
