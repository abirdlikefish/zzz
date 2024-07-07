using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDistroyGameObject : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
