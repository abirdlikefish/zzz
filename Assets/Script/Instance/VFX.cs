using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VFX : MonoBehaviour
{
    public static VFX Instance; 
    private Queue<GameObject> usedVFX;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        InitPrefab();
        usedVFX = new Queue<GameObject>();
    }

    GameObject hitEffect_ice ;
    GameObject hitEffect_fire ;
    GameObject parryAttack_light ;
    GameObject arrow;
    private void InitPrefab()
    {
        hitEffect_ice = Resources.Load<GameObject>("VFX/IceHit");
        hitEffect_fire = Resources.Load<GameObject>("VFX/FireHit");
        parryAttack_light = Resources.Load<GameObject>("VFX/ParryAttack_light");
        arrow = Resources.Load<GameObject>("VFX/Arrow");
        if(hitEffect_fire == null)
        {
            Debug.Log("load hit effect failed");
        }
    }

    public void HitEffect(Vector3 position , int id)
    {
        if(id == 0)
        {
            GameObject mid = Instantiate(hitEffect_ice, position ,Quaternion.Euler(0 , 0 , 0));
            usedVFX.Enqueue(mid);
        }
        else if(id == 1)
        {
            GameObject mid = Instantiate(hitEffect_fire, position ,Quaternion.Euler(0 , 0 , 0));
            usedVFX.Enqueue(mid);

        }
    }

    public void Update()
    {
        if(usedVFX.Count != 0 && usedVFX.Peek().GetComponent<ParticleSystem>().IsAlive() == false)
        {
            if(usedVFX.Peek() != null)
                Destroy(usedVFX.Peek());
            usedVFX.Dequeue();
        }
    }

    public void ParryAttack_light(Vector3 position , Vector3 direction , Structs.AttackAttribute attackAttribute)
    {
        GameObject mid = Instantiate(parryAttack_light, position ,Quaternion.Euler(0 , 0 , 0));
        DollParryAttack dollParryAttack = mid.GetComponent<DollParryAttack>();
        dollParryAttack.Init(position , direction, attackAttribute);
    }

    public void InsArrow(Vector3 position , Vector3 direction)
    {
        GameObject mid = Instantiate(arrow, position ,Quaternion.Euler(0 , 0 , 0));
        mid.GetComponent<Arrow>().Init(position , direction);

    }

    public void Clean()
    {
        usedVFX.Clear();
    }
}
