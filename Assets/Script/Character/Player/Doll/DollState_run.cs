using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollState_run : PlayerState
{
    public DollState_run(PlayerStateMachine playerStateMachine , Enums.EPlayerState ePlayerState) : base(playerStateMachine , ePlayerState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        playerStateMachine.player.AnimationBeg_run();
    }

    public override void ExitState()
    {
        base.ExitState();
        playerStateMachine.player.AnimationEnd_run();
    }

    public override void Update()
    {
        base.Update();
        if(playerStateMachine.player.IsAttack())
        {
            playerStateMachine.ChangeState(playerStateMachine.playerState_attack);
        }
        else if(playerStateMachine.player.IsRun())
        {
            playerStateMachine.player.MoveForward_run();
        }
        else
        {
            playerStateMachine.ChangeState(playerStateMachine.playerState_idle);
        }
    }

}
