using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollState_attack : PlayerState
{
    public DollState_attack(PlayerStateMachine playerStateMachine , Enums.EPlayerState ePlayerState) : base(playerStateMachine , ePlayerState)
    {
    }
    

    public override void EnterState()
    {
        base.EnterState();
        playerStateMachine.player.AnimationBeg_attack();
    }

    public override void ExitState()
    {
        base.ExitState();
        playerStateMachine.player.AnimationEnd_attack();
    }

    public override void Update()
    {
        base.Update();
        if(playerStateMachine.player.IsAttack())
        {
            playerStateMachine.ChangeState(playerStateMachine.playerState_attack);
        }
    }

}
