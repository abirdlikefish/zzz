using System.Collections;
using System.Collections.Generic;


// using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : Creature
{
    
    protected Team team;
    protected PlayerWeapon weapon;
    protected Enemy lockedEnemy;
    protected Vector3 beAttackedDirection ;
#region attribute

    public Structs.PlayerAttribute attribute ;
    public void Move(Vector3 x)
    {
        myController.Move(transform.TransformDirection(x));
    }

    protected float currentRotateSpeed;
    public virtual void FixForwardDirection(Vector3 direction , Enums.EPlayerState state)
    {
        if(direction == Vector3.zero) return;
        
        float currentAngle = transform.eulerAngles.y;
        float targetAngle = Mathf.Atan2(Camera.main.transform.forward.x, Camera.main.transform.forward.z) * Mathf.Rad2Deg;
        targetAngle += Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg ;
        if(state == Enums.EPlayerState.Run)
        {
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate_run);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
        else if(state == Enums.EPlayerState.Attack)
        {
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate_attack);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
        else if(state == Enums.EPlayerState.Skill_E)
        {
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate_skill_E);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
        else if(state == Enums.EPlayerState.Skill_Q)
        {
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate_skill_Q);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
        else if(state == Enums.EPlayerState.Dash)
        {
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate_dash);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
        else
        {
            Debug.Log("error : no state " + state + " rotate time");
        }
    }
    
    protected float currentRotateSpeed_lock;
    public virtual void FixForwardDirection_lock(Enums.EPlayerState state)
    {
        if(lockedEnemy == null)
        {
            Debug.Log("locked enemy is null");
            return;
        } 
        
        Vector3 targetDirection = lockedEnemy.transform.position - transform.position;
        float currentAngle = transform.eulerAngles.y;
        float targetAngle = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;
        
        
        if(state == Enums.EPlayerState.Run)
        {
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed_lock, attribute.time_rotate_run);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
            // float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate_run);
            // transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
        else if(state == Enums.EPlayerState.Attack)
        {
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed_lock, attribute.time_rotate_attack);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
            // float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate_attack);
            // transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
        else if(state == Enums.EPlayerState.Skill_E)
        {
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate_skill_E);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
        else if(state == Enums.EPlayerState.Skill_Q)
        {
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate_skill_Q);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
        else if(state == Enums.EPlayerState.Dash)
        {
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate_dash);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        }
        else
        {
            Debug.Log("error : no state " + state + " rotate time");
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
    public void SetInvisible(bool flag)
    {
        attribute.isInvisible = flag;
    }

    public bool IsInvisible_dash()
    {
        return attribute.isInvisible_dash < Time.time && Time.time < attribute.isInvisible_dash + attribute.invisibleTime_dash;
    }
    public bool IsInvisible()
    {
        return attribute.isInvisible;
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

    }
    public virtual void InitPlayerStateMachine(Enums.EPlayerState estate)
    {
    }
    public virtual void InitTeam(Team team)
    {
        this.team = team;
    }
    public virtual void InitPlayerAttribute(Structs.PlayerAttribute attribute)
    {
        this.attribute = attribute;
        // Debug.Log("load player attribute");
    }
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
// Debug.Log("Animator_attackBeg");
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Attack) return false;
        myAnimator.SetBool("IsAttack", true);
        // myAnimator.SetBool("IsAttackFinished" , false);
        // playerStateMachine.AddCombo();
        playerStateMachine.isComboContinue = true ;
        playerStateMachine.AddCombo(Enums.EPlayerState.Attack);
        return true;
    }
    public virtual bool Animator_attackFinished()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Attack) return false;
        myAnimator.SetBool("Trigger_attack", false);
        // myAnimator.SetBool("IsAttackFinished" , true);
        playerStateMachine.isComboContinue = false ;
        playerStateMachine.Finished(Enums.EPlayerState.Attack);
        // playerStateMachine.AddNeedCombo();
        return true;
    }
    public virtual bool  Animator_attackEnd()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Attack) return false;
        if( playerStateMachine.isComboContinue == true)   return false;
        playerStateMachine.BackToIdle();
        return true;
    }
    #endregion attack

    #region run
    public virtual bool Animator_runBeg()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Run) return false;
        weapon.WeaponOff();
        myAnimator.SetBool("IsRun", true);
        return true;
    }
    #endregion run

    #region skill_E
    public virtual bool Animator_skill_EBeg()
    {
        weapon.WeaponOff();
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Skill_E) return false;
        myAnimator.SetBool("IsSkill_E", true);
        return true;
    }
    public virtual bool  Animator_skill_EEnd()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Skill_E) return false;
        // if( playerStateMachine.IsComboContinue() == false)
        // {
            // playerStateMachine.BackToIdle();
        // }
        playerStateMachine.BackToIdle();
        return true;
    }

    #endregion skill_E

    #region skill_Q
    public virtual bool Animator_skill_QBeg()
    {
        weapon.WeaponOff();
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Skill_Q) return false;
        myAnimator.SetBool("IsSkill_Q", true);
        return true;
    }
    public virtual bool Animator_skill_QEnd()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Skill_Q) return false;
        playerStateMachine.BackToIdle();
        return true;
    }
    #endregion

    #region parry
    public virtual bool Animator_parryBeg()
    {
        weapon.WeaponOff();
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Parry) return false;
        myAnimator.SetBool("IsParry", true);
        return true;
    }
    public virtual bool Animator_parryEnd()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Parry) return false;
        playerStateMachine.BackToIdle();
        return true;
    }
    #endregion

    #region dash
    public virtual bool Animator_dashBeg()
    {
        weapon.WeaponOff();
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Dash) return false;
        myAnimator.SetBool("IsDash", true);
        playerStateMachine.isComboContinue = true ;
        playerStateMachine.AddCombo(Enums.EPlayerState.Dash);
        return true;
    }
    public virtual bool Animator_dashPrepared()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Dash) return false;
        playerStateMachine.isComboContinue = false ;
        playerStateMachine.Prepared(Enums.EPlayerState.Dash);
        // Debug.Log("dash finish");
        return true;
    }
    public virtual bool  Animator_dashEnd()
    {
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Dash) return false;
        if( playerStateMachine.isComboContinue == true)   return false;
        // Debug.Log("dash end");
        playerStateMachine.BackToIdle();
        return true;
    }

    // public virtual bool Animator_dashFinished()
    // {
    //     if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.Dash) return false;
    //     myAnimator.SetBool("Trigger_dash", false);
    //     myAnimator.SetBool("IsDash", false);
    //     playerStateMachine.Prepared(Enums.EPlayerState.Dash);
    //     return true;
    // }
    #endregion

    #region beAttacked
    public virtual bool Animator_beAttackedBeg()
    {
        // Debug.Log("animator beg: " + transform.eulerAngles.y);
        weapon.WeaponOff();
        // myController.enabled = false;
        // FixForwardDirectionNow(Vector3.forward);
        // myController.enabled = true;
        return true ;
    }
    public virtual bool Animator_beAttackedEnd()
    {
        // Debug.Log("animator end: " + transform.eulerAngles.y);
        if(playerStateMachine.playerStateNow.ePlayerState != Enums.EPlayerState.BeAttacked) return false;
        playerStateMachine.BackToIdle();
        // Debug.Log("beAttacked end");
        return true;
    }
    #endregion beAttacked
    
    #region  attackDetect
    public virtual void Animator_attackDetectBeg()
    {
        weapon.WeaponOn();
    }
    public virtual void Animator_attackDetectEnd()
    {
        weapon.WeaponOff();
    }
    #endregion

#endregion animator function


#region animation control function

    #region idle
    public void AnimationBeg_idle()
    {
        // myAnimator.SetTrigger(AnimatorParameters.Trigger_idle);
        myAnimator.SetTrigger("Trigger_idle");
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
        // myAnimator.SetFloat("Speed", 1f);
        myAnimator.SetTrigger("Trigger_run");
    }
    public void AnimationEnd_run()
    {
        // myAnimator.SetFloat("Speed", 0f);
        myAnimator.SetBool("Trigger_run", false);
        myAnimator.SetBool("IsRun" , false);
        // myAnimator.SetBool("Trigger_runEnd" , true);
        // Debug.Log("run end");
    }
    public void Animation_setRunSpeed()
    {
        myAnimator.SetFloat("Speed", attribute.speed);
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
        // myAnimator.SetBool("IsAttackFinished", false);
        myAnimator.SetBool("Trigger_attack", false);
    }
    #endregion attack

    #region skill_E
    public void AnimationBeg_skill_E()
    {
        myAnimator.SetBool("Trigger_skill_E" , true);
    }
    public void AnimationEnd_skill_E()
    {
        myAnimator.SetBool("IsSkill_E" , false);
        myAnimator.SetBool("Trigger_skill_E" , false);
        // myAnimator.SetBool("IsSkill_EFinished" , false);
        // myAnimator.SetBool("IsSkill_EPrepared" , false);
    }
    
    #endregion skill_E

    #region skill_Q
    public void AnimationBeg_skill_Q()
    {
        myAnimator.SetBool("Trigger_skill_Q" , true);
    }
    public void AnimationEnd_skill_Q()
    {
        myAnimator.SetBool("IsSkill_Q" , false);
        myAnimator.SetBool("Trigger_skill_Q" , false);
    }
    #endregion skill_Q

    #region parry
    public void AnimationBeg_parry()
    {
        myAnimator.SetBool("Trigger_parry" , true);
    }
    public void AnimationEnd_parry()
    {
        myAnimator.SetBool("IsParry" , false);
        myAnimator.SetBool("Trigger_parry" , false);
    }
    
    #endregion

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
        
        Vector3 mid = transform.InverseTransformDirection(beAttackedDirection);
        myAnimator.SetFloat("BeAttacked_y" , mid.z);
        myAnimator.SetFloat("BeAttacked_x" , mid.x);
    }
    public void AnimationEnd_beAttacked()
    {
        myAnimator.SetBool("IsBeAttacked" , false);
    }
    #endregion

#endregion


#region playerCommand function
    public void BegMove(Vector3 direction)
    {
        // ForwardDirection = direction;
        // FixForwardDirection(direction);
        
        playerStateMachine.ChangeState(playerStateMachine.playerState_run);
    }

    public void BegAttack(Vector3 direction)
    {
        // ForwardDirection = direction;
        // FixForwardDirection(direction);

        playerStateMachine.ChangeState(playerStateMachine.playerState_attack);
    }

    public void BegSkill_E(Vector3 direction)
    {
        // ForwardDirection = direction;
        // FixForwardDirection(direction);

        playerStateMachine.ChangeState(playerStateMachine.playerState_skill_E);
    }
    public void BegSkill_Q(Vector3 direction)
    {
        // ForwardDirection = direction;
        // FixForwardDirection(direction);

        playerStateMachine.ChangeState(playerStateMachine.playerState_skill_Q);
    }
    public void BegDash(Vector3 direction)
    {
        // ForwardDirection = direction;
        // FixForwardDirection(direction);

        playerStateMachine.ChangeState(playerStateMachine.playerState_dash);
    }

    public void BegChangeCharacter(Vector3 direction)
    {
        if(team.CanChangeCharacter() == false)  return ;
        attribute.isInvisible = true ;
        Enemy enemy = JudgeParry();
        if(enemy == null)
        {
            team.ChangeCharacter(playerStateMachine.playerStateNow.ePlayerState , transform);
        
            if(playerStateMachine.playerStateNow.ePlayerState == Enums.EPlayerState.Idle )
            {
                playerStateMachine.ChangeState(playerStateMachine.playerState_backEnd);
            }
            else if(playerStateMachine.playerStateNow.ePlayerState == Enums.EPlayerState.Run )
            {
                playerStateMachine.ChangeState(playerStateMachine.playerState_backEnd);
            }
            else if(playerStateMachine.playerStateNow.ePlayerState == Enums.EPlayerState.Dash )
            {
                playerStateMachine.ChangeState(playerStateMachine.playerState_backEnd);
            }
            else
            {
                attribute.isBackEnd = true ;
            }
        }

        else
        {
            team.ChangeCharacter_Parry(enemy.GetParryPosition(transform.position) , enemy.transform.position - transform.position);
            playerStateMachine.ChangeState(playerStateMachine.playerState_backEnd);
        }

    }

    #endregion


#region fight
    // public override Structs.AttackAttribute BeAttacked(Structs.AttackAttribute attackAttribute, Creature attacker)
    public override void BeAttacked(Structs.AttackAttribute attackAttribute, Creature attacker)
    {
        if(playerStateMachine.playerStateNow.ePlayerState == Enums.EPlayerState.Parry)
        {
            playerStateMachine.BeAttacked(attackAttribute, attacker);
            return ;
        }
        if(IsInvisible())
        {
            // return Structs.attackAttribute_null ;
            return ;
        }
        else if(IsInvisible_dash())
        {
            // return Structs.attackAttribute_null ;
            return ;
        }
        playerStateMachine.ChangeState(playerStateMachine.playerState_beAttacked);
        beAttackedDirection = attackAttribute.direction;
        beAttackedDirection.y = 0;
        beAttackedDirection = beAttackedDirection.normalized;
        // myController.Move(beAttackedDirection * 0.1f);
        StartCoroutine(BeAttackedMove(beAttackedDirection , 0.5f));
        // return Structs.attackAttribute_null ;
        return ;
    }
    protected IEnumerator BeAttackedMove(Vector3 direction , float time)
    {
        while(time > 0)
        {
            myController.Move(direction * Time.deltaTime);
            time -= Time.deltaTime;
            yield return null;
        }

    }
    protected virtual void HitEffect(Vector3 position)
    {
        VFX.Instance.HitEffect(position);
        CameraShake.Instance.Shake_light();
        StartCoroutine(FreezeFrame());
        // Sound.Instance.Sword_light();
    }
    public virtual void ParryEffect()
    {
        CameraShake.Instance.Shake_heavy();
        StartCoroutine(FreezeTime());
        Sound.Instance.Sword_collide();
        // position = transform.position + transform.forward + Vector3.up;
    }
    public virtual void WeaponCollide(Collider collider)
    {
        if(collider.tag != "Enemy") return ;
        Structs.AttackAttribute attackAttribute = playerStateMachine.GetAttackAttribute();
        if(attackAttribute.direction == Vector3.zero)
        {
            attackAttribute.direction = collider.transform.position - transform.position ;
        }
        collider.GetComponent<Enemy>().BeAttacked(attackAttribute , this);
        Vector3 mid = collider.ClosestPoint(transform.position);
        HitEffect(mid);

    }
    protected IEnumerator FreezeTime()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(attribute.freezeTimeTime);
        Time.timeScale = 1;
    }
    protected IEnumerator FreezeFrame()
    {
        myAnimator.speed = attribute.freezeFrameSpeed;
        yield return new WaitForSeconds(attribute.freezeFrameTime);
        myAnimator.speed = 1;
    }
    public virtual void LockEnemy()
    {
        if(lockedEnemy != null)
        {
            Vector3 directionToLockedEnemy = lockedEnemy.transform.position - transform.position;
            directionToLockedEnemy.y = 0;
            if(Vector3.Angle(transform.forward, directionToLockedEnemy) > attribute.angle_lock/2)
            {
                lockedEnemy = null ;
            }
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, attribute.lockDistance);
        float minDistanceSqr = attribute.lockDistance * attribute.lockDistance + 1;
        foreach(Collider collider in colliders)
        {
            if(collider.tag != "Enemy") continue;
            Vector3 directionToCollider = collider.transform.position - transform.position;
            if(directionToCollider.sqrMagnitude > minDistanceSqr)   continue ;
            directionToCollider.y = 0;
            float angle = Vector3.Angle(transform.forward, directionToCollider);
            if(angle > attribute.angle_lock/2) continue;
            lockedEnemy = collider.GetComponent<Enemy>();
            minDistanceSqr = directionToCollider.sqrMagnitude ;
        }
    }
    public virtual void SetWeapon(PlayerWeapon weapon)
    {
        this.weapon = weapon;
    }
    public Enemy JudgeParry()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, attribute.parryDistance);
        foreach(Collider collider in colliders)
        {
            if(collider.tag != "Enemy") continue;
        // Debug.Log("finding enemy");
            if(collider.GetComponent<Enemy>().IsParry(transform.position) )
            {
        // Debug.Log("judge parry succeeded");
                return collider.GetComponent<Enemy>();
            }
        }
        return null;
    }
#endregion

#region  changeCharacter
    public virtual void Appear(Enums.EPlayerState eState , Transform midTransform)
    {
        attribute.isInvisible = false ;

        myController.enabled = false;
        transform.rotation = midTransform.rotation;
        transform.position = midTransform.position + transform.forward * -1 + transform.right * -1 ;
        myController.enabled = true;
        playerStateMachine.ChangeState(playerStateMachine.playerState_run);
        // playerStateMachine.ChangeState(playerStateMachine.playerState_dash);
        return;

        if(eState == Enums.EPlayerState.Idle)
        {
            playerStateMachine.ChangeState(playerStateMachine.playerState_idle);
        }
        else if(eState == Enums.EPlayerState.Attack)
        {
            playerStateMachine.ChangeState(playerStateMachine.playerState_idle);
        }
        else if(eState == Enums.EPlayerState.BeAttacked)
        {
            playerStateMachine.ChangeState(playerStateMachine.playerState_idle);
        }
        else if(eState == Enums.EPlayerState.Run)
        {
            // Debug.Log("running");
            playerStateMachine.ChangeState(playerStateMachine.playerState_run);
        }
        else if(eState == Enums.EPlayerState.Dash)
        {
            playerStateMachine.ChangeState(playerStateMachine.playerState_idle);
        }
        else if(eState == Enums.EPlayerState.Skill_E)
        {
            playerStateMachine.ChangeState(playerStateMachine.playerState_idle);
        }
        else if(eState == Enums.EPlayerState.Skill_Q)
        {
            playerStateMachine.ChangeState(playerStateMachine.playerState_idle);
        }
        else
        {
            Debug.Log("error: Unknown state : " + eState);
        }
    }
    public virtual void Appear(Vector3 position , Vector3 direction)
    {
        attribute.isInvisible = true ;

        myController.enabled = false;
        transform.position = position ;
        transform.LookAt(position + direction);
        myController.enabled = true;
        playerStateMachine.ChangeState(playerStateMachine.playerState_parry);
        Debug.Log("parry!!!");
        StartCoroutine(PullCloseCamera(25 , 20f , 50));
    }
    

    IEnumerator PullCamera(float beg, float end, float speed)
    {
        while(beg - end > 0.01)
        {
            beg = Mathf.Lerp(beg, end, speed * Time.deltaTime);
            team.cameraController.SetFOV(beg);
            // camera.m_Lens.FieldOfView = beg;
            yield return null;
        }
        team.cameraController.SetFOV(end);
        // camera.m_Lens.FieldOfView = end;
    }

    IEnumerator PushCamera(float beg, float end, float speed)
    {
        while(beg < end)
        {
            beg += speed * Time.deltaTime;
            // camera.m_Lens.FieldOfView = beg;
            team.cameraController.SetFOV(beg);
            yield return null;
        }
        // camera.m_Lens.FieldOfView = end;
        team.cameraController.SetFOV(end);
    }
    IEnumerator PullCloseCamera(float targetFov , float speed1 , float speed2)
    {
        float originFOV = team.cameraController.GetFOV();
        yield return StartCoroutine( PullCamera(originFOV, targetFov , speed1));
        yield return StartCoroutine( PushCamera(targetFov, originFOV , speed2));
    }
#endregion

}
