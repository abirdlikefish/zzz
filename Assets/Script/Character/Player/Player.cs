using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character
{
    protected Vector3 forwardDirection;
    protected Vector3 inputDirection;
    // public enum EPlayerState
    // {
    //     idle ,
    //     run ,
    //     walk ,
    //     attack
    // }
    // public Enums.EPlayerState ePlayerState ;
    public PlayerStateMachine playerStateMachine ;
    // public PlayerState playerState_idle;
    // public PlayerState playerState_run ;
    // public PlayerState playerState_walk ;
    // public PlayerState playerState_attack ;

    protected struct InputBuffer
    {
        public float E ;
        public float Q ;
        public float Space;
        public float Mouse_lef ;
        public float Mouse_rig ;
        public float W;
        public float A ;
        public float S;
        public float D ;
    }

    InputBuffer inputBuffer ;


    protected override void Awake()
    {
        base.Awake();
        InitPlayerStateMachine();
        InitInputBuffer();
    }
    protected override void Update()
    {
        base.Update();
        HandleInput();
        HandleDirection();
        playerStateMachine.Update();
    }


    protected virtual void HandleInput()
    {
        
        if(Input.GetKey(KeyCode.W))
        {
            inputBuffer.W = Time.time;
            inputDirection.z = 1;
            // Debug.Log("move forward");
        }
        else if(Input.GetKey(KeyCode.S))
        {
            inputBuffer.S = Time.time;
            inputDirection.z = -1;
            // Debug.Log("move backward");
        }
        else
        {
            inputDirection.z = 0;
        }

        if(Input.GetKey(KeyCode.A))
        {
            inputBuffer.A = Time.time;
            // Debug.Log("move forward");
            inputDirection.x = -1;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            inputBuffer.D = Time.time;
            // Debug.Log("move forward");
            inputDirection.x = 1;
        }
        else
        {
            inputDirection.x = 0;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            inputBuffer.Space = Time.time;
            Debug.Log("space paused");
        }
        if(Input.GetKey(KeyCode.E))
        {
            inputBuffer.E = Time.time;
        }
        if(Input.GetKey(KeyCode.Q))
        {
            inputBuffer.Q = Time.time;
        }
        if(Input.GetMouseButtonDown(0))
        {
            inputBuffer.Mouse_lef = Time.time;
        }
        if(Input.GetMouseButtonDown(1))
        {
            inputBuffer.Mouse_rig = Time.time;
        }
    }
    protected virtual void HandleDirection()
    {
        forwardDirection = Camera.main.transform.TransformDirection(inputDirection);
        forwardDirection = new Vector3(forwardDirection.x, 0 , forwardDirection.z);
        forwardDirection = forwardDirection.normalized;
        // Debug.Log(forwardDirection);
        transform.LookAt(forwardDirection + transform.position);
    }
    // protected abstract void InitPlayerStateMachine();
    protected virtual void InitPlayerStateMachine()
    {
        // ePlayerState = 
        // playerStateMachine = 
        // playerState_ =
    }
    private void InitInputBuffer()
    {
        inputBuffer = new InputBuffer
        {
            E = -1,
            Q = -1,
            Space = -1,
            Mouse_lef = -1,
            Mouse_rig = -1,
            W = -1,
            S = -1
        };

    }

    public void AnimationBeg_run()
    {
        Debug.Log("Animation Run Beg");
        myAnimator.SetFloat("Speed", 1f);
    }
    public void AnimationEnd_run()
    {
        Debug.Log("Animation Run End");
        myAnimator.SetFloat("Speed", 0f);
    }
    // public void AnimationBeg_idle()
    // {
    // }
    // public void AnimationEnd_idle()
    // {
    // }
    public void AnimationBeg_attack()
    {
        Debug.Log("Animation Attack Beg");
        myAnimator.SetBool("IsAttack", true);
        myAnimator.SetBool("IsCombo", true);
    }
    public void AnimationEnd_attack()
    {
        Debug.Log("Animation Attack Beg");
        myAnimator.SetBool("IsAttack", false);
        myAnimator.SetBool("IsCombo", false);
    }


    public void Animator_endCombo()
    {
        Debug.Log("Animator End Attack");
        myAnimator.SetBool("IsAttack", false);
        myAnimator.SetBool("IsCombo", false);
    }
    public void Animator_backToIdle()
    {
        playerStateMachine.BackToIdle();
    }

    public void MoveForward_run()
    {
        myController.Move(forwardDirection * Time.deltaTime);
    }
    // public void MoveBackward_run()
    // {
    //     myController.Move(-1 * forwardDirection * Time.deltaTime);
    // }


    public bool IsRun()
    {
        if(inputDirection == Vector3.zero)
        {
            return false;
        }
        return true;
    }
    public bool IsAttack()
    {
        if(Time.time - inputBuffer.Mouse_lef < 0.05)
        {
            inputBuffer.Mouse_lef = -1;
            return true;
        }
        return false;
    }
}
