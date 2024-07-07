using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    
    public PlayerState playerStateNow { get; set; }
    public Player player { get; set; }
    public bool isComboContinue { get; set; }
    public virtual void Update()
    {
        playerStateNow.Update();
    }
    
#region define playerState
    public PlayerState playerState_idle;
    public PlayerState playerState_run ;
    public PlayerState playerState_walk ;
    public PlayerState playerState_attack ;
    public PlayerState playerState_skill_E;
    public PlayerState playerState_skill_Q;
    public PlayerState playerState_parry;
    public PlayerState playerState_dash;
    public PlayerState playerState_beAttacked ;
    public PlayerState playerState_backEnd ;
#endregion

    public virtual void Init(Player player , Enums.EPlayerState eState)
    {
        isComboContinue = false ;

        this.player = player;
        InitPlayerState(player);

        if(eState == Enums.EPlayerState.Idle)
        {
            playerStateNow = playerState_idle;
        }
        else if(eState == Enums.EPlayerState.BackEnd)
        {
            playerStateNow = playerState_backEnd;
        }
        else
        {
            Debug.Log("error: init player state machine using error state");
        }
        playerStateNow.EnterState();
    }

    public virtual void InitPlayerState(Player player)
    {

    }
    public virtual void ChangeState(PlayerState state)
    {
        playerStateNow.ExitState();
        playerStateNow = state;
        playerStateNow.EnterState();
    }
    public virtual void BackToIdle()
    {
        if(player.attribute.isBackEnd)
        {
            player.attribute.isBackEnd = false;
            ChangeState(playerState_backEnd);
        }
        else
        {
            ChangeState(playerState_idle);
        }
    }
    public virtual void AddCombo(Enums.EPlayerState playerState)
    {
        
    }
    public virtual void Prepared(Enums.EPlayerState playerState)
    {

    }
    public virtual void Finished(Enums.EPlayerState playerState)
    {

    }
    public virtual void BeAttacked(Structs.AttackAttribute attackAttribute, Creature attacker)
    {
        
    }
    public virtual Structs.AttackAttribute GetAttackAttribute()
    {
        return default;
    }
    public virtual void Free(bool flag)
    {
        playerStateNow.Free(flag);
    }
}
