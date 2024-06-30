using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Creature
{
    

#region attribute

    // private Vector3 forwardDirection ;
    
    // protected Vector3 ForwardDirection 
    // { 
    //     get {return forwardDirection ;} 
    //     set {forwardDirection = value;FixForwardDirection();}
    // }
    protected Structs.PlayerAttribute attribute ;
    private Vector3 GetWorldDirection()
    {
        // Vector3 direction = Camera.main.transform.TransformDirection(forwardDirection).normalized;
        Vector3 direction = Camera.main.transform.TransformDirection(attribute.direction).normalized;
        direction = new Vector3(direction.x, 0, direction.z).normalized;
        return direction;
    }
    private void FixForwardDirection(Vector3 direction)
    {
        attribute.direction = direction;
        transform.LookAt(GetWorldDirection() + transform.position);
    }
    public void ChangeDirection_run()
    {
        Vector3 midDirection = InputBuffer.Instance.GetDirection();
        if(midDirection == Vector3.zero)
        {
            playerStateMachine.BackToIdle();
        }
        else
        {
            // ForwardDirection = direction;
            FixForwardDirection(midDirection);
        }
    }
    public void SetInvisibleBeg_dash(bool flag)
    {
        if(flag)
        {
            attribute.isInvisible_dash = Time.time + attribute.prepareTime_dash;
        }
        else
        {
            attribute.isInvisible_dash = -1;
        }
    }
    public void SetInvisible_defend(bool flag)
    {
        attribute.isInvisible_defend = flag ;
    }
    public void SetInvisibleBeg_parry(bool flag)
    {
        if(flag)
        {
            attribute.isInvisible_parry = Time.time + attribute.prepareTime_parry;
        }
        else
        {
            attribute.isInvisible_parry = -1;
        }
    }

    public bool IsInvisible_dash()
    {
        return attribute.isInvisible_dash < Time.time && Time.time < attribute.isInvisible_dash + attribute.invisibleTime_dash;
    }

    public bool IsInvisible_parry()
    {
        return attribute.isInvisible_parry < Time.time && Time.time < attribute.isInvisible_parry + attribute.invisibleTime_parry;
    }

#endregion 


    protected override void Update()
    {
        base.Update();
        playerStateMachine.Update();
    }
    public PlayerStateMachine playerStateMachine ;

#region Init
    protected override void Awake()
    {
        base.Awake();
        InitPlayerStateMachine();
//Test----------------
// attribute = new Structs.PlayerAttribute();
// attribute.direction = new Vector3(0, 0,1) ;
//Test----------------

    }
    protected virtual void InitPlayerStateMachine()
    {
    }

    public virtual void InitPlayerAttribute(Structs.PlayerAttribute attribute)
    {
        this.attribute = attribute;
        Debug.Log("load player attribute");
    }
#endregion

#region animation control function

    #region idle
    public void AnimationBeg_idle()
    {
        myAnimator.SetTrigger(AnimatorParameters.Trigger_idle);
    }
    public void AnimationEnd_idle()
    {
        myAnimator.SetBool("Trigger_idle" , false);
        myAnimator.SetBool("IsIdle" , false);
    }
    #endregion idle

    #region  run
    public void AnimationBeg_run()
    {
        myAnimator.SetFloat("Speed", 1f);
        myAnimator.SetTrigger("Trigger_run");
    }
    public void AnimationEnd_run()
    {
        myAnimator.SetFloat("Speed", 0f);
        myAnimator.SetBool("Trigger_run", false);
        myAnimator.SetBool("IsRun" , false);
    }
    #endregion run

    #region attack
    public void AnimationBeg_attack()
    {
        // myAnimator.SetTrigger("Trigger_attack");
        myAnimator.SetBool("Trigger_attack" , true);
    }
    public void AnimationEnd_attack()
    {
        myAnimator.SetBool("IsAttack", false);
        myAnimator.SetBool("Trigger_attack", false);
    }
    #endregion attack

    #region defend
    public void AnimationBeg_defend()
    {
        myAnimator.SetBool("Trigger_defend" , true);
    }
    public void AnimationEnd_defend()
    {
        myAnimator.SetBool("IsDefend" , false);
        myAnimator.SetBool("Trigger_defend" , false);
    }
    public void AnimationBeg_defendSuccess_light()
    {
        myAnimator.SetBool("Trigger_defendSuccess_light" , true);
    }
    public void AnimationBeg_defendSuccess_heavy()
    {
        myAnimator.SetBool("Trigger_defendSuccess_heavy" , true);
    }
    public void AnimationBeg_parrySuccess()
    {
        myAnimator.SetBool("Trigger_parrySuccess" , true);
    }
    #endregion defend

    #region skill_E
    public void AnimationBeg_skill_E()
    {
        myAnimator.SetBool("Trigger_skill_E" , true);
    }
    public void AnimationEnd_skill_E()
    {
        myAnimator.SetBool("IsSkill_E" , false);
        myAnimator.SetBool("IsSkill_EFinished" , false);
        myAnimator.SetBool("IsSkill_EPrepared" , false);
        myAnimator.SetBool("Trigger_skill_E" , false);
    }
    #endregion skill_E

    #region dash
    public void AnimationBeg_dash()
    {
        myAnimator.SetBool("Trigger_dash" , true);
    }
    public void AnimationEnd_dash()
    {
        myAnimator.SetBool("IsDash" , false);
        myAnimator.SetBool("Trigger_dash" , false );
    }
    #endregion dash

    #region beAttack
    public void AnimationBeg_beAttacked()
    {
        myAnimator.SetBool("Trigger_beAttacked" , true);
        myAnimator.SetBool("IsBeAttacked" , true);
    }
    public void AnimationEnd_beAttacked()
    {
        myAnimator.SetBool("IsBeAttacked" , false);
    }
    #endregion

#endregion

#region animator function

    #region idle
    public virtual bool Animator_idleBeg()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Idle) return false;
        myAnimator.SetBool("IsIdle", true);
        return true;
    }
    public virtual void Animator_backToIdle()
    {
        playerStateMachine.BackToIdle();
    }
    #endregion idle

    #region attack
    public virtual bool Animator_attackBeg()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Attack) return false;
        myAnimator.SetBool("IsAttack", true);
        myAnimator.SetBool("IsAttackFinished" , false);
        playerStateMachine.AddCombo();
        return true;
    }
    public virtual bool Animator_attackFinished()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Attack) return false;
        myAnimator.SetBool("Trigger_attack", false);
        myAnimator.SetBool("IsAttackFinished" , true);
        playerStateMachine.AddNeedCombo();
        return true;
    }
    public virtual bool  Animator_attackEnd()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Attack) return false;
        if( playerStateMachine.IsComboContinue() == false)
        {
            playerStateMachine.BackToIdle();
        }
        return true;
    }
    #endregion attack

    #region run
    public virtual bool Animator_runBeg()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Run) return false;
        myAnimator.SetBool("IsRun", true);
        return true;
    }
    #endregion run

    #region defend
    public virtual bool Animator_defendBeg()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Defend) return false;
        myAnimator.SetBool("IsDefend", true);
        return true;
    }
    public virtual bool Animator_defendPrepared()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Defend) return false;
        myAnimator.SetBool("Trigger_defend", false);
        playerStateMachine.Prepared(Enums.EPlayerState.Defend);
        return true;
    }
    #endregion defend

    #region skill_E
    public virtual bool Animator_skill_EBeg()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Skill_E) return false;
        myAnimator.SetBool("IsSkill_E", true);
        return true;
    }
    public virtual bool Animator_skill_EPrepared()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Skill_E) return false;
        myAnimator.SetBool("Trigger_skill_E", false);
        myAnimator.SetBool("IsSkill_EPrepared", true);
        playerStateMachine.Prepared(Enums.EPlayerState.Skill_E);
        return true;
    }    
    public virtual bool Animator_skill_EBeg_2()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Skill_E) return false;
        myAnimator.SetBool("IsSkill_E", true);
        myAnimator.SetBool("IsSkill_EFinished", false);
        myAnimator.SetBool("IsSkill_EPrepared", false);
        playerStateMachine.AddCombo();
        return true;
    }
    public virtual bool Animator_skill_EFinished()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Skill_E) return false;
        myAnimator.SetBool("Trigger_skill_E", false);
        myAnimator.SetBool("IsSkill_EFinished" , true);
        playerStateMachine.AddNeedCombo();
        return true;
    }
    public virtual bool  Animator_skill_EEnd()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Skill_E) return false;
        if( playerStateMachine.IsComboContinue() == false)
        {
            playerStateMachine.BackToIdle();
        }
        return true;
    }

    #endregion skill_E

    #region dash
    public virtual bool Animator_dashBeg()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Dash) return false;
        myAnimator.SetBool("IsDash", true);
        return true;
    }
    public virtual bool Animator_dashFinished()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Dash) return false;
        myAnimator.SetBool("Trigger_dash", false);
        myAnimator.SetBool("IsDash", false);
        playerStateMachine.Prepared(Enums.EPlayerState.Dash);
        return true;
    }
    #endregion

    #region beAttacked
    public virtual bool Animator_beAttackedEnd()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.BeAttacked) return false;
        playerStateMachine.BackToIdle();
        return true;
    }
    #endregion beAttacked

#endregion animator function


#region playerCommand function
    public void BegMove(Vector3 direction)
    {
        // ForwardDirection = direction;
        FixForwardDirection(direction);
        
        playerStateMachine.ChangeState(playerStateMachine.playerState_run);
    }

    public void BegAttack(Vector3 direction)
    {
        // ForwardDirection = direction;
        FixForwardDirection(direction);

        playerStateMachine.ChangeState(playerStateMachine.playerState_attack);
    }

    public void BegSkill_E(Vector3 direction)
    {
        // ForwardDirection = direction;
        FixForwardDirection(direction);

        playerStateMachine.ChangeState(playerStateMachine.playerState_skill_E);
    }
    public void BegSkill_Q(Vector3 direction)
    {
        // ForwardDirection = direction;
        FixForwardDirection(direction);

        playerStateMachine.ChangeState(playerStateMachine.playerState_skill_Q);
    }

    public void BegDefend(Vector3 direction)
    {
        // ForwardDirection = direction;
        FixForwardDirection(direction);

        playerStateMachine.ChangeState(playerStateMachine.playerState_defend);
    }

    public void BegDash(Vector3 direction)
    {
        // ForwardDirection = direction;
        FixForwardDirection(direction);

        playerStateMachine.ChangeState(playerStateMachine.playerState_dash);
    }

    public void BegChangeCharacter(Vector3 direction)
    {
        Debug.Log("begin change character");
    }

    #endregion


#region be attacked
    public override Structs.AttackAttribute BeAttacked(Structs.AttackAttribute attackAttribute, Creature attacker)
    {
        // if( attribute.isInvisible_dash < Time.time && Time.time < attribute.isInvisible_dash + attribute.invisibleTime_dash)
        if(IsInvisible_dash())
        {
            //dash success------

            //------------------
            return Structs.attackAttribute_null ;
        }
        // else if(Vector3.Dot(attackAttribute.direction , attribute.direction) * -1 > attribute.minAngleCos)
        else if(Vector3.Dot(attackAttribute.direction , transform.forward) * -1 > attribute.minAngleCos)
        {
            if(IsInvisible_parry())
            {
                //parry success------
                playerStateMachine.BeAttacked(attackAttribute , attacker);
                //------------------
                return new Structs.AttackAttribute(0 , attribute.damage_poise_parry);
            }
            else if(attribute.isInvisible_defend)
            {
                if(attribute.poise > attackAttribute.damage_pose)
                {
                //defend success------

                //------------------
                    playerStateMachine.BeAttacked(attackAttribute , attacker);
                }
                else
                {
                //defend failed------

                //------------------
                    playerStateMachine.ChangeState(playerStateMachine.playerState_beAttacked);
                }
                return Structs.attackAttribute_null ;
            }
        }
        playerStateMachine.ChangeState(playerStateMachine.playerState_beAttacked);
        return Structs.attackAttribute_null ;
    }

#endregion


}
