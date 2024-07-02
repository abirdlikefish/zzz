using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollState_skill_Q : PlayerState
{
    float remainingTime ;
    float totalTime ;
    public DollState_skill_Q(PlayerStateMachine playerStateMachine, Enums.EPlayerState ePlayerState) : base(playerStateMachine, ePlayerState)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        playerStateMachine.player.AnimationBeg_skill_Q();
        remainingTime = (playerStateMachine.player.attribute as Structs.DollAttribute).time_skill_Q;
        totalTime = (playerStateMachine.player.attribute as Structs.DollAttribute).time_skill_Q;
    }

    public override void ExitState()
    {
        base.ExitState();
        playerStateMachine.player.AnimationEnd_skill_Q();
    }

    public override void Update()
    {
        playerStateMachine.player.Move((playerStateMachine.player.attribute as Structs.DollAttribute).velocity_skill_Q * remainingTime / totalTime * Time.deltaTime);
        remainingTime -= Time.deltaTime;
        if(remainingTime <= 0)
        {
            playerStateMachine.BackToIdle();
            return;
        }
        if(playerStateMachine.player.attribute.isBackEnd)
        {
            return ;
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
        attackAttribute.damage_hp = (playerStateMachine.player.attribute as Structs.DollAttribute).damage_hp_skill_Q;
        attackAttribute.damage_poise = (playerStateMachine.player.attribute as Structs.DollAttribute).damage_poise_skill_Q;
        return attackAttribute;
    }
}
