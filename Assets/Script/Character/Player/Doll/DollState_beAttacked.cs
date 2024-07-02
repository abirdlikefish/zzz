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
        // Debug.Log("dollstate beg: " + playerStateMachine.player.transform.eulerAngles.y);
        base.EnterState();
        playerStateMachine.player.AnimationBeg_beAttacked();
        // Debug.Log("dollstate on: " + playerStateMachine.player.transform.eulerAngles.y);
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
