using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigState_skill_E : PlayerState
{
    public BigState_skill_E(PlayerStateMachine playerStateMachine, Enums.EPlayerState ePlayerState) : base(playerStateMachine, ePlayerState)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        playerStateMachine.player.AnimationBeg_skill_E();
    }
    public override void ExitState()
    {
        base.ExitState();
        playerStateMachine.player.AnimationEnd_skill_E();
    }
    public override void Update()
    {
        if(playerStateMachine.player.attribute.isBackEnd)
        {
            return ;
        }

        
        Vector3 midDirection = InputBuffer.Instance.GetDirection();
        if(midDirection == Vector3.zero || midDirection.z > 0.9f)
        {
            playerStateMachine.player.LockEnemy();
            playerStateMachine.player.FixForwardDirection_lock(ePlayerState);
        }
        else
        {
            playerStateMachine.player.FixForwardDirection(midDirection , ePlayerState);
        }

        
        IPlayerCommand playerCommand ;
        if(isFree)
        {
            playerCommand = InputBuffer.Instance.GetCommand(0);
        }
        else
        {
            playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Skill_E]);
        }

        // IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Skill_E]);
        if(playerCommand != null)
        {
            playerCommand.Execute(playerStateMachine.player);
        }

    }
    public Structs.AttackAttribute GetAttackAttribute()
    {
        Structs.AttackAttribute attackAttribute = new Structs.AttackAttribute();
        attackAttribute.damage_hp = (playerStateMachine.player.attribute as Structs.BigAttribute).damage_hp_skill_E;
        attackAttribute.damage_poise = (playerStateMachine.player.attribute as Structs.BigAttribute).damage_poise_skill_E;
        return attackAttribute;
    }
}
