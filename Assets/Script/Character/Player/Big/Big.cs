using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big : Player
{
    public GameObject mid;
    public override void InitPlayerStateMachine(Enums.EPlayerState eState)
    {
        base.InitPlayerStateMachine(eState);
        playerStateMachine = new BigStateMachine();
        playerStateMachine.Init(this , eState);
    }

    protected override void HitEffect(Vector3 position)
    {
        VFX.Instance.HitEffect(position , 1);
        CameraShake.Instance.Shake_heavy();
        StartCoroutine(FreezeFrame());
        // Sound.Instance.Sword_heavy();
    }

    public override void Animator_attackDetectBeg()
    {
        base.Animator_attackDetectBeg(); 
        mid.SetActive(true);
        Debug.Log("Attack detected");
    }

    public override void Animator_attackDetectEnd()
    {
        base.Animator_attackDetectEnd();
        mid.SetActive(false);
    }
}
