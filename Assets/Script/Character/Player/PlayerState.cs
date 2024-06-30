using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class PlayerState : IPlayerState
public class PlayerState
{
    public PlayerStateMachine playerStateMachine;
    public Enums.EPlayerState ePlayerState{ get; set; }

    public PlayerState(PlayerStateMachine playerStateMachine , Enums.EPlayerState ePlayerState)
    {
        this.playerStateMachine = playerStateMachine;
        this.ePlayerState = ePlayerState;
    }

    public virtual void EnterState()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void Update()
    {
    }
}
