using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigState_skill_Q : PlayerState
{
    float remainingTime ;
    bool isFinished ;
    // float totalTime ;
    public BigState_skill_Q(PlayerStateMachine playerStateMachine, Enums.EPlayerState ePlayerState) : base(playerStateMachine, ePlayerState)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        playerStateMachine.player.AnimationBeg_skill_Q();
        remainingTime = (playerStateMachine.player.attribute as Structs.BigAttribute).time_skill_Q;
        isFinished = false ;
        // totalTime = (playerStateMachine.player.attribute as Structs.BigAttribute).time_skill_Q;
    }

    public override void ExitState()
    {
        base.ExitState();
        playerStateMachine.player.AnimationEnd_skill_Q();
    }

    public override void Update()
    {
        if(isFinished == false)
        {
            playerStateMachine.player.Move((playerStateMachine.player.attribute as Structs.BigAttribute).velocity_skill_Q * Time.deltaTime);
        }
        remainingTime -= Time.deltaTime;
        if(remainingTime <= 0)
        {
            // playerStateMachine.BackToIdle();
            playerStateMachine.player.AnimationBeg_skill_Q();
            isFinished = true ;
            return;
        }
        if(playerStateMachine.player.attribute.isBackEnd)
        {
            return ;
        }

        if(InputBuffer.Instance.IsCommandCancelled(Enums.EPlayerCommand.Skill_Q))
        {
            playerStateMachine.player.AnimationBeg_skill_Q();
            isFinished = true ;
            // playerStateMachine.BackToIdle();
        }

        
        Vector3 midDirection = InputBuffer.Instance.GetDirection();
        if(midDirection == Vector3.zero)
        {
            playerStateMachine.player.LockEnemy();
            playerStateMachine.player.FixForwardDirection_lock(ePlayerState);
        }
        else
        {
            playerStateMachine.player.FixForwardDirection(midDirection , ePlayerState);
        }

        IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Skill_Q]);
        if(playerCommand != null)
        {
            playerCommand.Execute(playerStateMachine.player);
        }
    }
    public Structs.AttackAttribute GetAttackAttribute()
    {
        Structs.AttackAttribute attackAttribute = new Structs.AttackAttribute();
        attackAttribute.damage_hp = (playerStateMachine.player.attribute as Structs.BigAttribute).damage_hp_skill_Q;
        attackAttribute.damage_poise = (playerStateMachine.player.attribute as Structs.BigAttribute).damage_poise_skill_Q;
        return attackAttribute;
    }
}
