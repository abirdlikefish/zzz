using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : Player
{
    public override void InitPlayerStateMachine(Enums.EPlayerState eState)
    {
        base.InitPlayerStateMachine(eState);
        playerStateMachine = new DollStateMachine();
        playerStateMachine.Init(this , eState);
    }

    protected override void HitEffect(Vector3 position)
    {
        VFX.Instance.HitEffect(position);
        CameraShake.Instance.Shake_light();
        StartCoroutine(FreezeFrame());
        // Sound.Instance.Sword_light();
    }

}

