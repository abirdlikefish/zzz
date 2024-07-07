using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doll : Player
{
    public GameObject mid;
    public override void InitPlayerStateMachine(Enums.EPlayerState eState)
    {
        base.InitPlayerStateMachine(eState);
        playerStateMachine = new DollStateMachine();
        playerStateMachine.Init(this , eState);
    }

    protected override void HitEffect(Vector3 position)
    {
        VFX.Instance.HitEffect(position , 0);
        CameraShake.Instance.Shake_light();
        StartCoroutine(FreezeFrame());
        // Sound.Instance.Sword_light();
    }

    public override void Animator_attackDetectBeg()
    {
        base.Animator_attackDetectBeg(); 
        mid.SetActive(true);
        // Debug.Log("Attack detected");
    }

    public override void Animator_attackDetectEnd()
    {
        base.Animator_attackDetectEnd();
        // mid.SetActive(false);
    }

    public void Animator_parryAttackDetect()
    {
        Structs.AttackAttribute mid = new Structs.AttackAttribute(attribute.damage_hp_parry , attribute.damage_poise_parry);
        VFX.Instance.ParryAttack_light(transform.position , transform.forward , mid);
    }
}

