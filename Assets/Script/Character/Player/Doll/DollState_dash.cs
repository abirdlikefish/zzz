using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollState_dash : PlayerState
{
    public DollState_dash(PlayerStateMachine playerStateMachine, Enums.EPlayerState ePlayerState) : base(playerStateMachine, ePlayerState)
    {
    }
    private bool isPrepared ;
    
    public override void EnterState()
    {
        base.EnterState();
        playerStateMachine.player.AnimationBeg_dash();
        isPrepared = false;
        playerStateMachine.player.SetInvisibleBeg_dash(true);
    }
    public override void ExitState()
    {
        base.ExitState();
        playerStateMachine.player.AnimationEnd_dash();
        isPrepared = false;
        playerStateMachine.player.SetInvisibleBeg_dash(false);
    }
    public override void Update()
    {
        base.Update();
        IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Dash]);
        if(playerCommand != null)
        {
            playerCommand.Execute(playerStateMachine.player);
        }
        if(isPrepared)
        {
            Vector3 direction = InputBuffer.Instance.GetDirection();
            if(direction != Vector3.zero)
            {
                playerStateMachine.ChangeState(playerStateMachine.playerState_run);
            }
        }
    }
    public void Prepared()
    {
        isPrepared = true;
    }
}
