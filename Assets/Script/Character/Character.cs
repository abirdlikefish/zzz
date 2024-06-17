using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Awake()
    {
        InitComponent();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected Animator myAnimator ;
    protected CharacterController myController ;
    protected virtual void InitComponent()
    {
        myAnimator = GetComponent<Animator>();
        myController = GetComponent<CharacterController>();
    }
}
