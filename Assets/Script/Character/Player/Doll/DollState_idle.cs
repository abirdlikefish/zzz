using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollState_idle : PlayerState
{
    public DollState_idle(PlayerStateMachine playerStateMachine , Enums.EPlayerState ePlayerState) : base(playerStateMachine , ePlayerState)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        // Debug.Log("111111111111");
        // playerStateMachine.player.AnimationBeg_idle();
        // Debug.Log("222222222222222");
    }

    public override void ExitState()
    {
        base.ExitState();
        // playerStateMachine.player.AnimationEnd_idle();
    }

    public override void Update()
    {
        base.Update();
        if(playerStateMachine.player.IsRun())
        {
            playerStateMachine.ChangeState(playerStateMachine.playerState_run);
        }
        if(playerStateMachine.player.IsAttack())
        {
            playerStateMachine.ChangeState(playerStateMachine.playerState_attack);
        }
    }

}
