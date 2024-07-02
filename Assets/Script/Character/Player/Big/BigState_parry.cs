using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigState_parry : PlayerState
{
    float remainingTime ;
    float totalTime ;
    float comboNum ;
    public BigState_parry(PlayerStateMachine playerStateMachine, Enums.EPlayerState ePlayerState) : base(playerStateMachine, ePlayerState)
    {
    }
    public override void EnterState()
    {
        // Debug.Log("beg parry");
        base.EnterState();
        playerStateMachine.player.AnimationBeg_parry();
        remainingTime = (playerStateMachine.player.attribute as Structs.BigAttribute).time_parry;
        totalTime = (playerStateMachine.player.attribute as Structs.BigAttribute).time_parry;
        playerStateMachine.player.SetInvisible(true);
        comboNum = 0;
    }

    public override void ExitState()
    {
        base.ExitState();
        playerStateMachine.player.AnimationEnd_parry();
        playerStateMachine.player.SetInvisible(false);
    }

    public override void Update()
    {
        // if(playerStateMachine.player.name == "Player_0")
        // {
        //     Debug.Log("Player_0 : isBackEnd = " + playerStateMachine.player.attribute.isBackEnd);
        // }
        if(comboNum == 2)   return ;
        remainingTime -= Time.deltaTime;
        if(comboNum == 0)
        {
            if(remainingTime < totalTime * 0.5f)
            {
                playerStateMachine.BackToIdle();
            }
            return;
        }
        else if(comboNum == 1)
        {
            if(remainingTime < 0)
            {
                playerStateMachine.BackToIdle();
                return ;
            }
            float k = remainingTime / totalTime;
            playerStateMachine.player.Move((playerStateMachine.player.attribute as Structs.BigAttribute).velocity_parry * Mathf.Pow(k , 5) * Time.deltaTime);
            if(k < 0.5f)
            {
                if(InputBuffer.Instance.IsAttack())
                {
                    playerStateMachine.player.AnimationBeg_parry();
                    comboNum = 2;
                }
            }
        }

        // if(comboNum == 1 && remainingTime <= 0)
        // {
        //     playerStateMachine.BackToIdle();
        //     return;
        // }
        // if(comboNum == 0)   return ;
        // if(comboNum == 1)
        // {
        //     float k = remainingTime / totalTime;
        //     playerStateMachine.player.Move((playerStateMachine.player.attribute as Structs.BigAttribute).velocity_parry * Mathf.Pow(k , 5) * Time.deltaTime);
        //     if(k < 0.5f)
        //     {
        //         if(InputBuffer.Instance.IsAttack())
        //         {
        //             playerStateMachine.player.AnimationBeg_parry();
        //             comboNum = 2;
        //         }
        //     }
        // }
        // if(playerStateMachine.player.attribute.isBackEnd)
        // {
        //     Debug.Log("error in backend state");
        // }


        // IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Parry]);
        // if(playerCommand != null)
        // {
        //     playerCommand.Execute(playerStateMachine.player);
        // }
    }
    // public void AddCombo()
    // {
    //     if(comboNum <= 1)
    //     {
    //         comboNum = 1;
    //     }
    // }
    public void BeAttacked()
    {
        if(comboNum == 0)
        {
            playerStateMachine.player.ParryEffect();
            comboNum = 1;
            remainingTime = totalTime;
            playerStateMachine.player.AnimationBeg_parry();
        }
    }
}
