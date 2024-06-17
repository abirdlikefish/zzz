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
        playerState_idle = new DollState_idle(this , Enums.EPlayerState.idle);
        playerState_run = new DollState_run(this , Enums.EPlayerState.run);
        playerState_attack = new DollState_attack(this , Enums.EPlayerState.attack);
    }
}
