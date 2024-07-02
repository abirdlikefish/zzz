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

    GameObject hitEffect ;
    private void InitPrefab()
    {
        // hitEffect = Resources.Load<GameObject>("VFX/HitEffect");
        // hitEffect = Resources.Load<GameObject>("VFX/BasicHit");
        // hitEffect = Resources.Load<GameObject>("VFX/BasicHit2");
        hitEffect = Resources.Load<GameObject>("VFX/IceHit");
        if(hitEffect == null)
        {
            Debug.Log("load hit effect failed");
        }
    }

    public void HitEffect(Vector3 position)
    {
        GameObject mid = Instantiate(hitEffect, position ,Quaternion.Euler(0 , 0 , 0));
        usedVFX.Enqueue(mid);
    }

    public void Update()
    {
        if(usedVFX.Count != 0 && usedVFX.Peek().GetComponent<ParticleSystem>().IsAlive() == false)
        {
            Destroy(usedVFX.Peek());
            usedVFX.Dequeue();
        }
    }
}
