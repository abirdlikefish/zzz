using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigState_idle : PlayerState
{
    public BigState_idle(PlayerStateMachine playerStateMachine , Enums.EPlayerState ePlayerState) : base(playerStateMachine , ePlayerState)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        playerStateMachine.player.AnimationBeg_idle();
    }

    public override void ExitState()
    {
        base.ExitState();
        playerStateMachine.player.AnimationEnd_idle();
    }

    public override void Update()
    {
        base.Update();
        IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Idle]);
        if(playerCommand != null)
        {
            playerCommand.Execute(playerStateMachine.player);
        }
    }

}
