using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollStateMachine : PlayerStateMachine
{
    // Doll doll ;
    public override void Init(Player player)
    {
        base.Init(player);
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
        playerState_dash = new DollState_dash(this , Enums.EPlayerState.Dash) ;
        playerState_defend = new DollState_defend(this,Enums.EPlayerState.Defend) ;
        playerState_beAttacked = new DollState_beAttacked(this,Enums.EPlayerState.BeAttacked) ;
        playerState_backEnd = new DollState_backEnd(this,Enums.EPlayerState.BackEnd) ;
    }

#region combo
    public override void AddCombo()
    {
        base.AddCombo();
        if(playerStateNow.ePlayerState == Enums.EPlayerState.Attack)
        {
            (playerStateNow as DollState_attack).AddCombo();
        }
        else if(playerStateNow.ePlayerState == Enums.EPlayerState.Skill_E)
        {
            (playerStateNow as DollState_skill_E).AddCombo();
        }
    }
    public override void AddNeedCombo()
    {
        base.AddNeedCombo();
        if(playerStateNow.ePlayerState == Enums.EPlayerState.Attack)
        {
            (playerStateNow as DollState_attack).AddNeedComboNum();
        }
        else if(playerStateNow.ePlayerState == Enums.EPlayerState.Skill_E)
        {
            (playerStateNow as DollState_skill_E).AddNeedComboNum();
        }

    }
    public override bool IsComboContinue()
    {
        base.IsComboContinue();
        if(playerStateNow.ePlayerState == Enums.EPlayerState.Attack)
        {
            return (playerStateNow as DollState_attack).IsContinue();
        }
        if(playerStateNow.ePlayerState == Enums.EPlayerState.Skill_E)
        {
            return (playerStateNow as DollState_skill_E).IsContinue();
        }

        Debug.Log("error: wrong player state");
        return false;
    }
#endregion


    public override void Prepared(Enums.EPlayerState playerState)
    {
        base.Prepared(playerState);
        if(playerStateNow.ePlayerState != playerState)
        {
            Debug.Log("error : player state is not the same");
        }
        if(playerState == Enums.EPlayerState.Defend)
        {
            (playerStateNow as DollState_defend).Prepared();
        }
        else if(playerState == Enums.EPlayerState.Skill_E)
        {
            (playerStateNow as DollState_skill_E).Prepared();
        }
        else if(playerState == Enums.EPlayerState.Dash)
        {
            (playerStateNow as DollState_dash).Prepared();
        }

    }

    public override void BeAttacked(Structs.AttackAttribute attackAttribute, Creature attacker)
    {
        base.BeAttacked(attackAttribute, attacker);
        if(playerStateNow.ePlayerState == Enums.EPlayerState.Defend)
        {
            if(player.IsInvisible_parry())
            {
                (playerStateNow as DollState_defend).Success_parry();
            }
            else
            {
                (playerStateNow as DollState_defend).Success_defend();
            }
        }
        else if(playerStateNow.ePlayerState == Enums.EPlayerState.Dash)
        {

        }
        else
        {
            Debug.Log("Error playerState in BeAttacked function");
        }
    }
}
