using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollState_parry : PlayerState
{
    float remainingTime ;
    float totalTime ;
    float comboNum ;
    public DollState_parry(PlayerStateMachine playerStateMachine, Enums.EPlayerState ePlayerState) : base(playerStateMachine, ePlayerState)
    {
    }
    public override void EnterState()
    {
        // Debug.Log("beg parry");
        base.EnterState();
        playerStateMachine.player.AnimationBeg_parry();
        remainingTime = (playerStateMachine.player.attribute as Structs.DollAttribute).time_parry;
        totalTime = (playerStateMachine.player.attribute as Structs.DollAttribute).time_parry;
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
        // Debug.Log(comboNum);
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
            playerStateMachine.player.Move((playerStateMachine.player.attribute as Structs.DollAttribute).velocity_parry * Mathf.Pow(k , 5) * Time.deltaTime);
            if(k < 0.5f)
            {
                if(InputBuffer.Instance.IsAttack())
                {
                    // Debug.Log("comboNum -> 2 ");
                    playerStateMachine.player.AnimationBeg_parry();
                    comboNum = 2;
                }
            }
        }




        // playerStateMachine.player.Move((playerStateMachine.player.attribute as Structs.DollAttribute).velocity_parry * remainingTime / totalTime * Time.deltaTime);
        // remainingTime -= Time.deltaTime;
        // if(remainingTime <= 0)
        // {
        //     playerStateMachine.BackToIdle();
        //     return;
        // }
        // if(playerStateMachine.player.attribute.isBackEnd)
        // {
        //     return ;
        // }
        // IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Parry]);
        // if(playerCommand != null)
        // {
        //     playerCommand.Execute(playerStateMachine.player);
        // }
    }
    
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
        attackAttribute.damage_hp = (playerStateMachine.player.attribute as Structs.DollAttribute).damage_hp_parry;
        attackAttribute.damage_poise = (playerStateMachine.player.attribute as Structs.DollAttribute).damage_poise_parry;
        return attackAttribute;
    }

}
