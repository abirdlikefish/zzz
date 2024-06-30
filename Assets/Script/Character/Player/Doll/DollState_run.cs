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
        IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Run]);
        if(playerCommand != null)
        {
            playerCommand.Execute(playerStateMachine.player);
        }
        playerStateMachine.player.ChangeDirection_run();
    }

}
