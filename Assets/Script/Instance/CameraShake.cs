using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance ;
    private CinemachineImpulseSource source ;
    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        source = gameObject.GetComponent<CinemachineImpulseSource>();
    }

    public void Shake_light()
    {
        source.GenerateImpulse(0.15f);
        // Debug.Log("shake begin");
    }
    public void Shake_heavy()
    {
        source.GenerateImpulse(0.4f);

    }
}
