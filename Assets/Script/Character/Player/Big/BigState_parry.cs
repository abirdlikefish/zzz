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
        if(comboNum == 2)   
        {
            IPlayerCommand playerCommand ;
            if(isFree)
            {
                playerCommand = InputBuffer.Instance.GetCommand(0);
            }
            else
            {
                playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Parry]);
            }
            if(playerCommand != null)
            {
                playerCommand.Execute(playerStateMachine.player);
            }
            return ;
        }
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

    public Structs.AttackAttribute GetAttackAttribute()
    {
        Structs.AttackAttribute attackAttribute = new Structs.AttackAttribute();
        attackAttribute.damage_hp = (playerStateMachine.player.attribute as Structs.BigAttribute).damage_hp_parry;
        attackAttribute.damage_poise = (playerStateMachine.player.attribute as Structs.BigAttribute).damage_poise_parry;
        return attackAttribute;
    }
}
