using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instance{get ; set ;}
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
        // enemyPrefab[0] = Resources.Load<GameObject>("Prefab/PiggyMan_dagger");
        light = Resources.Load<AudioClip>("Sound/light");
        heavy = Resources.Load<AudioClip>("Sound/heavy");
        collide = Resources.Load<AudioClip>("Sound/collide");
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private AudioClip light;
    private AudioClip heavy;
    private AudioClip collide;
    private AudioSource audioSource ;

    public void Sword_light()
    {
        audioSource.clip = light;
        audioSource.Play();
    }
    public void Sword_heavy()
    {
        audioSource.clip = heavy;
        audioSource.Play();
    }
    public void Sword_collide()
    {
        audioSource.clip = collide;
        audioSource.Play();
    }
}
