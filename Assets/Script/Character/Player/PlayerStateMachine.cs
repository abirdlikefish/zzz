using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    
    public IPlayerState PlayerStateNow { get; set; }
    public Player player { get; set; }
    
    public PlayerState playerState_idle;
    public PlayerState playerState_run ;
    public PlayerState playerState_walk ;
    public PlayerState playerState_attack ;

    public virtual void Init(Player player)
    {
        this.player = player;
        InitPlayerState(player);

        PlayerStateNow = playerState_idle;
        PlayerStateNow.EnterState();
    }

    public virtual void InitPlayerState(Player player)
    {

    }
    public virtual void ChangeState(IPlayerState state)
    {
        PlayerStateNow.ExitState();
        PlayerStateNow = state;
        PlayerStateNow.EnterState();
    }

    public virtual void Update()
    {
        PlayerStateNow.Update();
    }

    public virtual void BackToIdle()
    {
        if(PlayerStateNow.ePlayerState != Enums.EPlayerState.idle)
        {
            ChangeState(playerState_idle);
        }
    }

}
