using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : Player
{
    protected override void InitPlayerStateMachine()
    {
        base.InitPlayerStateMachine();
        playerStateMachine = new DollStateMachine();
        playerStateMachine.Init(this);
    }
}

