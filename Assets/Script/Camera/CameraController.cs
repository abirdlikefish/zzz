using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine ;
using Unity.Mathematics;

public class CameraController 
{
    public CinemachineFreeLook  camera ;
    public CameraController()
    {
        camera = GameObject.FindObjectOfType<CinemachineFreeLook>();
        if(camera == null)
        {
            Debug.LogError("failed to find camera");
        }
    }

    public void SetTarget(Transform target)
    {
        camera.LookAt = target;
        camera.Follow = target;
    }

    public void SetFOV(float targetFov)
    {
        camera.m_Lens.FieldOfView = targetFov;
    }
    public float GetFOV()
    {
        return camera.m_Lens.FieldOfView;
    }
}
