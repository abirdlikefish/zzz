using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollStateMachine : PlayerStateMachine
{
    // Doll doll ;
    public override void Init(Player player , Enums.EPlayerState eState)
    {
        base.Init(player , eState);
        // doll = player as Doll;
    }

    public override void InitPlayerState(Player player)
    {
        base.InitPlayerState(player);
        playerState_idle = new DollState_idle(this , Enums.EPlayerState.Idle);
        playerState_run = new DollState_run(this , Enums.EPlayerState.Run);
        playerState_attack = new DollState_attack(this , Enums.EPlayerState.Attack);
        playerState_skill_E = new DollState_skill_E(this , Enums.EPlayerState.Skill_E);
        playerState_skill_Q = new DollState_skill_Q(this , Enums.EPlayerState.Skill_Q);
        playerState_parry = new DollState_parry(this , Enums.EPlayerState.Parry);
        playerState_dash = new DollState_dash(this , Enums.EPlayerState.Dash) ;
        // playerState_defend = new DollState_defend(this,Enums.EPlayerState.Defend) ;
        playerState_beAttacked = new DollState_beAttacked(this,Enums.EPlayerState.BeAttacked) ;
        playerState_backEnd = new DollState_backEnd(this,Enums.EPlayerState.BackEnd) ;
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
            (playerStateNow as DollState_dash).Prepared();
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
            (playerStateNow as DollState_attack).Finished();
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
            (playerStateNow as DollState_parry).BeAttacked();
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
            (playerStateNow as DollState_dash).AddCombo();
        }
        else if(playerState == Enums.EPlayerState.Attack)
        {
            (playerStateNow as DollState_attack).AddCombo();
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
            return (playerStateNow as DollState_dash).GetAttackAttribute();
        }
        else if(playerStateNow.ePlayerState == Enums.EPlayerState.Attack)
        {
            return (playerStateNow as DollState_attack).GetAttackAttribute();
        }
        else if(playerStateNow.ePlayerState == Enums.EPlayerState.Skill_E)
        {
            return (playerStateNow as DollState_skill_E).GetAttackAttribute();
        }
        else if(playerStateNow.ePlayerState == Enums.EPlayerState.Skill_Q)
        {
            return (playerStateNow as DollState_skill_Q).GetAttackAttribute();
        }
        else if(playerStateNow.ePlayerState == Enums.EPlayerState.Parry)
        {
            return (playerStateNow as DollState_parry).GetAttackAttribute();
        }
        else
        {
            Debug.Log("error state");
            return default ;
        }
    }
}
