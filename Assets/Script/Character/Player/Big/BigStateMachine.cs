using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigStateMachine : PlayerStateMachine
{
    public override void Init(Player player , Enums.EPlayerState eState)
    {
        base.Init(player , eState);
    }

    public override void InitPlayerState(Player player)
    {
        base.InitPlayerState(player);
        playerState_idle = new BigState_idle(this , Enums.EPlayerState.Idle);
        playerState_run = new BigState_run(this , Enums.EPlayerState.Run);
        playerState_attack = new BigState_attack(this , Enums.EPlayerState.Attack);
        playerState_skill_E = new BigState_skill_E(this , Enums.EPlayerState.Skill_E);
        playerState_skill_Q = new BigState_skill_Q(this , Enums.EPlayerState.Skill_Q);
        playerState_parry = new BigState_parry(this , Enums.EPlayerState.Parry);
        playerState_dash = new BigState_dash(this , Enums.EPlayerState.Dash) ;
        playerState_beAttacked = new BigState_beAttacked(this,Enums.EPlayerState.BeAttacked) ;
        playerState_backEnd = new BigState_backEnd(this,Enums.EPlayerState.BackEnd) ;
    }
    public override void Prepared(Enums.EPlayerState playerState)
    {
        base.Prepared(playerState);
        if(playerStateNow.ePlayerState != playerState)
        {
            Debug.Log("error : player state is not the same");
        }
        else if(playerState == Enums.EPlayerState.Dash)
        {
            (playerStateNow as BigState_dash).Prepared();
        }
        else
        {
            Debug.Log("error state");
        }
    }
    public override void Finished(Enums.EPlayerState playerState)
    {
        if(playerStateNow.ePlayerState != playerState)
        {
            Debug.Log("error : player state is not the same");
        }
        else if(playerState == Enums.EPlayerState.Attack)
        {
            (playerStateNow as BigState_attack).Finished();
        }
        else
        {
            Debug.Log("error state");
        }
    }

    public override void BeAttacked(Structs.AttackAttribute attackAttribute, Creature attacker)
    {
        base.BeAttacked(attackAttribute, attacker);

        if(playerStateNow.ePlayerState == Enums.EPlayerState.Dash)
        {

        }
        else if(playerStateNow.ePlayerState == Enums.EPlayerState.Parry)
        {
            (playerStateNow as BigState_parry).BeAttacked();
        }
        else
        {
            Debug.Log("Error playerState in BeAttacked function");
        }
    }
    public override void AddCombo(Enums.EPlayerState playerState)
    {
        if(playerStateNow.ePlayerState != playerState)
        {
            Debug.Log("error : player state is not the same");
        }
        else if(playerState == Enums.EPlayerState.Dash)
        {
            (playerStateNow as BigState_dash).AddCombo();
        }
        else if(playerState == Enums.EPlayerState.Attack)
        {
            (playerStateNow as BigState_attack).AddCombo();
        }
        else
        {
            Debug.Log("error state");
        }
    }
    public override Structs.AttackAttribute GetAttackAttribute()
    {
        if(playerStateNow.ePlayerState == Enums.EPlayerState.Dash)
        {
            return (playerStateNow as BigState_dash).GetAttackAttribute();
        }
        else if(playerStateNow.ePlayerState == Enums.EPlayerState.Attack)
        {
            return (playerStateNow as BigState_attack).GetAttackAttribute();
        }
        else if(playerStateNow.ePlayerState == Enums.EPlayerState.Skill_E)
        {
            return (playerStateNow as BigState_skill_E).GetAttackAttribute();
        }
        else if(playerStateNow.ePlayerState == Enums.EPlayerState.Skill_Q)
        {
            return (playerStateNow as BigState_skill_Q).GetAttackAttribute();
        }
        else if(playerStateNow.ePlayerState == Enums.EPlayerState.Parry)
        {
            return (playerStateNow as BigState_parry).GetAttackAttribute();
        }
        else
        {
            Debug.Log("error state");
            return default ;
        }
    }
}
