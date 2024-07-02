using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigState_run : PlayerState
{
    public BigState_run(PlayerStateMachine playerStateMachine , Enums.EPlayerState ePlayerState) : base(playerStateMachine , ePlayerState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        playerStateMachine.player.AnimationBeg_run();
        playerStateMachine.player.Animation_setRunSpeed();
    }

    public override void ExitState()
    {
        // Debug.Log("exit state run");
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
        

        Vector3 midDirection = InputBuffer.Instance.GetDirection();
        if(midDirection == Vector3.zero)
        {
            playerStateMachine.BackToIdle();
        }
        else
        {
            playerStateMachine.player.FixForwardDirection(midDirection , ePlayerState);
            // playerStateMachine.player.Run(midDirection);
        }
    }

}
