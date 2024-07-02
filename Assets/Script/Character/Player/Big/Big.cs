using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big : Player
{
    public override void InitPlayerStateMachine(Enums.EPlayerState eState)
    {
        base.InitPlayerStateMachine(eState);
        playerStateMachine = new BigStateMachine();
        playerStateMachine.Init(this , eState);
    }

    protected override void HitEffect(Vector3 position)
    {
        VFX.Instance.HitEffect(position);
        CameraShake.Instance.Shake_heavy();
        StartCoroutine(FreezeFrame());
        // Sound.Instance.Sword_heavy();
    }

    // public override void Animator_attackDetectBeg()
    // {
    //     weapon.WeaponOn();
    //     Sound.Instance.Sword_heavy();
    // }
}
