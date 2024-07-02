using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollState_backEnd : PlayerState
{
    public DollState_backEnd(PlayerStateMachine playerStateMachine, Enums.EPlayerState ePlayerState) : base(playerStateMachine, ePlayerState)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        playerStateMachine.player.gameObject.SetActive(false);
    }

    public override void ExitState()
    {
        playerStateMachine.player.gameObject.SetActive(true);
        base.ExitState();
    }

    public override void Update()
    {
    }
}
