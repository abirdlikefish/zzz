using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollState_beAttacked : PlayerState
{
    public DollState_beAttacked(PlayerStateMachine playerStateMachine, Enums.EPlayerState ePlayerState) : base(playerStateMachine, ePlayerState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        playerStateMachine.player.AnimationBeg_beAttacked();
    }

    public override void ExitState()
    {
        base.ExitState();
        playerStateMachine.player.AnimationEnd_beAttacked();
    }

    public override void Update()
    {
        base.Update();
        IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.BeAttacked]);
        if(playerCommand != null)
        {
            playerCommand.Execute(playerStateMachine.player);
        }
    }
}
