using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    
    public PlayerState playerStateNow { get; set; }
    public Player player { get; set; }
    
#region define playerState
    public PlayerState playerState_idle;
    public PlayerState playerState_run ;
    public PlayerState playerState_walk ;
    public PlayerState playerState_attack ;
    public PlayerState playerState_skill_E;
    public PlayerState playerState_skill_Q;
    public PlayerState playerState_defend;
    public PlayerState playerState_dash;
    public PlayerState playerState_beAttacked ;
    public PlayerState playerState_backEnd ;
#endregion
    public virtual void Init(Player player)
    {
        this.player = player;
        InitPlayerState(player);

        playerStateNow = playerState_idle;
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

    public virtual void Update()
    {
        playerStateNow.Update();
    }

    public virtual void BackToIdle()
    {
        ChangeState(playerState_idle);
    }
    public virtual void AddCombo()
    {
        
    }
    public virtual void AddNeedCombo()
    {

    }
    public virtual bool IsComboContinue()
    {
        return false;
    }
    public virtual void Prepared(Enums.EPlayerState playerState)
    {

    }
    public virtual void BeAttacked(Structs.AttackAttribute attackAttribute, Creature attacker)
    {
        
    }
}
