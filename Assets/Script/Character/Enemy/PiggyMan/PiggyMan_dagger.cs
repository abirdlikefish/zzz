using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyMan_dagger : Enemy
{
    Structs.PiggyMan_daggerAttribute attribute ;
    Player player ;
    Team_enemy team ;
    bool isBeAttacked ;
    bool isAttacking ;
    bool isDie ;
    float currentRotateSpeed ;
    struct BehaviorState 
    {
        public Enums.EEnemyBehaviorState beAttacked ;
        public Enums.EEnemyBehaviorState attack ;
        public Enums.EEnemyBehaviorState run ;
        public Enums.EEnemyBehaviorState walk ;
        public Enums.EEnemyBehaviorState skillBeg ;
        public Enums.EEnemyBehaviorState skillOn ;
        public Enums.EEnemyBehaviorState skillEnd ;
        public Enums.EEnemyBehaviorState idle ;
        public void SetAll(Enums.EEnemyBehaviorState state)
        {
            beAttacked = state;
            attack = state;
            run = state;
            walk = state;
            skillBeg = state;
            skillOn = state;
            skillEnd = state;
            idle = state ;
        }
    }
    BehaviorState behaviorState ;

#region Init
    protected override void Awake()
    {
        base.Awake();
        isBeAttacked = false ;
        isAttacking = false ;
        isDie = false ;
        InitBTRoot();
        InitBehaviorState();
        // Debug.Log("enemy awake");
    }
    public override void InitAttribute(Structs.EnemyAttribute attribute , Team_enemy team)
    {
        this.attribute = attribute as Structs.PiggyMan_daggerAttribute;
        this.team = team ;
    }
    protected override void InitBTRoot()
    {
        this.BTroot = new BTBuilder_piggyMan_dagger().Build(this);
    }
    protected override void InitBehaviorState()
    {
        behaviorState = new BehaviorState();
        behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
    }
#endregion

#region BT
    protected BTNode BTroot ;
    protected override void Update() 
    {
        BTroot.Execute();
        myController.Move(Vector3.down * Time.deltaTime * 10);
    }

    public bool FindPlayer()
    {
        if(player == null || player.gameObject.activeSelf == false)
        {
            GameObject mid = GameObject.FindWithTag("Player");
            if(mid == null)
            {
                Debug.Log("can not find player");
                return false;
            }
            if((mid.transform.position - transform.position).sqrMagnitude > attribute.maxFindDistance * attribute.maxFindDistance)
            {
                return false ;
            }
            player = mid.GetComponent<Player>();
        }
        // else
        // {
        //     Debug.Log(player.gameObject.name);
        // }
        return player != null && player.gameObject.activeSelf;
    }

    #region judge
    public bool IfBeAttacked()
    {
        if(isBeAttacked)
        {
            isBeAttacked = false;
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IfNeedWalkToPlayer()
    {
        if(player == null)
        {
            Debug.Log("Player is null");
        }
        // else
        // {
        //     Debug.Log(player.name);
        // }
        if(attribute == null)
        {
            Debug.Log("attribute is null");
        }
        return (player.transform.position - transform.position).sqrMagnitude > attribute.runRange * attribute.runRange ;
    }
    public bool IfNearPlayer()
    {
        return (player.transform.position - transform.position).sqrMagnitude < attribute.attackDistance * attribute.attackDistance ;
    }
    public bool IfSkillOnCD()
    {
        return Time.time - attribute.CD_begTime < attribute.CD_skill;
    }
    #endregion

    #region animation
    public Enums.EBTNodeState AnimationBeg_die()
    {
        if(isDie)
        {
            return Enums.EBTNodeState.Success ;
        }

        if(attribute.hp > 0)
        {
            return Enums.EBTNodeState.Failure;
        }
        else
        {
            isAttacking = false ;
            isDie = true ;
            myAnimator.SetBool("Trigger_die" , true);
            return Enums.EBTNodeState.Success;
        }
    }
    public Enums.EBTNodeState AnimationBeg_beAttacked()
    {
        isAttacking = false ;
        if(behaviorState.beAttacked == Enums.EEnemyBehaviorState.Waiting)
        {
            behaviorState.SetAll(Enums.EEnemyBehaviorState.ForceQuit);
            behaviorState.beAttacked = Enums.EEnemyBehaviorState.Doing ;
            myAnimator.SetBool("Trigger_beAttacked" , true);
        }
        else if(behaviorState.beAttacked == Enums.EEnemyBehaviorState.End)
        {
            behaviorState.beAttacked = Enums.EEnemyBehaviorState.Waiting ;
            return Enums.EBTNodeState.Success;
        }
        return Enums.EBTNodeState.Running;
    }
    public Enums.EBTNodeState AnimationBeg_run()
    {
        isAttacking = false ;
        if(behaviorState.run == Enums.EEnemyBehaviorState.Waiting)
        {
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            myAnimator.SetBool("Trigger_run" , true);
            behaviorState.run = Enums.EEnemyBehaviorState.Doing ;
        }
        else if(behaviorState.run == Enums.EEnemyBehaviorState.ForceQuit)
        {
            behaviorState.run = Enums.EEnemyBehaviorState.Waiting;
            return Enums.EBTNodeState.Failure;
        }
        else if(behaviorState.run == Enums.EEnemyBehaviorState.End)
        {
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            return Enums.EBTNodeState.Success;
        }
        float currentAngle = transform.eulerAngles.y;
        Vector3 directionToTarget = player.transform.position - transform.position;
        float targetAngle = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg;
        float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate);
        transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        myController.Move(attribute.speed_run * transform.forward * Time.deltaTime);
        return Enums.EBTNodeState.Running;
    }
    public Enums.EBTNodeState AnimationBeg_walk()
    {
        isAttacking = false ;
        if(behaviorState.walk == Enums.EEnemyBehaviorState.Waiting)
        {
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            myAnimator.SetBool("Trigger_walk" , true);
            behaviorState.walk = Enums.EEnemyBehaviorState.Doing ;
        }
        else if(behaviorState.walk == Enums.EEnemyBehaviorState.ForceQuit)
        {
            behaviorState.walk = Enums.EEnemyBehaviorState.Waiting;
            return Enums.EBTNodeState.Failure;
        }
        else if(behaviorState.walk == Enums.EEnemyBehaviorState.End)
        {
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            return Enums.EBTNodeState.Success;
        }
        float currentAngle = transform.eulerAngles.y;
        Vector3 directionToTarget = player.transform.position - transform.position;
        float targetAngle = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg;
        float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate);
        transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
        myController.Move(attribute.speed_walk * transform.forward * Time.deltaTime);
        return Enums.EBTNodeState.Running;
    }
    public Enums.EBTNodeState AnimationBeg_attack()
    {
        // isAttacking = false ;
        if(behaviorState.attack == Enums.EEnemyBehaviorState.Waiting)
        {
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            myAnimator.SetBool("Trigger_attack" , true);
            behaviorState.attack = Enums.EEnemyBehaviorState.Doing ;
            return Enums.EBTNodeState.Running;
        }
        else if(behaviorState.attack == Enums.EEnemyBehaviorState.ForceQuit)
        {
            behaviorState.attack = Enums.EEnemyBehaviorState.Waiting;
            return Enums.EBTNodeState.Failure;
        }
        else if(behaviorState.attack == Enums.EEnemyBehaviorState.End)
        {
            // Debug.Log("piggy man attack end");
            // state_attack = Enums.EEnemyBehaviorState.Waiting ;
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            return Enums.EBTNodeState.Success;
        }
        else
        {
            float currentAngle = transform.eulerAngles.y;
            Vector3 directionToTarget = player.transform.position - transform.position;
            float targetAngle = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg;
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
            return Enums.EBTNodeState.Running;
        }
    }
    public Enums.EBTNodeState AnimationBeg_skillBeg()
    {
        isAttacking = false ;
        if(behaviorState.skillBeg == Enums.EEnemyBehaviorState.Waiting)
        {
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            myAnimator.SetBool("Trigger_skillBeg" , true);
            behaviorState.skillBeg = Enums.EEnemyBehaviorState.Doing ;
            return Enums.EBTNodeState.Running;
        }
        else if(behaviorState.skillBeg == Enums.EEnemyBehaviorState.ForceQuit)
        {
            behaviorState.skillBeg = Enums.EEnemyBehaviorState.Waiting;
            return Enums.EBTNodeState.Failure;
        }
        else if(behaviorState.skillBeg == Enums.EEnemyBehaviorState.End)
        {
            attribute.CD_begTime = Time.time ;
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            return Enums.EBTNodeState.Success;
        }
        else
        {
            return Enums.EBTNodeState.Running;
        }
    }
    public Enums.EBTNodeState AnimationBeg_skillOn()
    {
        // isAttacking = false ;
        if(behaviorState.skillOn == Enums.EEnemyBehaviorState.Waiting)
        {
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            myAnimator.SetBool("Trigger_skillOn" , true);
            behaviorState.skillOn = Enums.EEnemyBehaviorState.Doing ;
            return Enums.EBTNodeState.Running;
        }
        else if(behaviorState.skillOn == Enums.EEnemyBehaviorState.ForceQuit)
        {
            behaviorState.skillOn = Enums.EEnemyBehaviorState.Waiting;
            return Enums.EBTNodeState.Failure;
        }
        else if(behaviorState.skillOn == Enums.EEnemyBehaviorState.End)
        {
            // state_skillOn = Enums.EEnemyBehaviorState.Waiting ;
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            return Enums.EBTNodeState.Success;
        }
        else
        {

            float currentAngle = transform.eulerAngles.y;
            Vector3 directionToTarget = player.transform.position - transform.position;
            float targetAngle = Mathf.Atan2(directionToTarget.x, directionToTarget.z) * Mathf.Rad2Deg;
            float smoothAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentRotateSpeed, attribute.time_rotate);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
            myController.Move(attribute.speed_skill * transform.forward * Time.deltaTime);

            return Enums.EBTNodeState.Running;
        }
    }
    public Enums.EBTNodeState AnimationBeg_skillEnd()
    {
        isAttacking = false ;
        if(behaviorState.skillEnd == Enums.EEnemyBehaviorState.Waiting)
        {
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            myAnimator.SetBool("Trigger_skillEnd" , true);
            behaviorState.skillEnd = Enums.EEnemyBehaviorState.Doing ;
            return Enums.EBTNodeState.Running;
        }
        else if(behaviorState.skillEnd == Enums.EEnemyBehaviorState.ForceQuit)
        {
            behaviorState.skillEnd = Enums.EEnemyBehaviorState.Waiting;
            return Enums.EBTNodeState.Failure;
        }
        else if(behaviorState.skillEnd == Enums.EEnemyBehaviorState.End)
        {
            // state_skillEnd = Enums.EEnemyBehaviorState.Waiting ;
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            return Enums.EBTNodeState.Success;
        }
        else
        {
            return Enums.EBTNodeState.Running;
        }
    }
    public Enums.EBTNodeState AnimationBeg_idle()
    {
        isAttacking = false ;
        if(behaviorState.idle == Enums.EEnemyBehaviorState.Waiting)
        {
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            myAnimator.SetBool("Trigger_idle" , true);
            behaviorState.idle = Enums.EEnemyBehaviorState.Doing ;
            return Enums.EBTNodeState.Running;
        }
        else if(behaviorState.idle == Enums.EEnemyBehaviorState.ForceQuit)
        {
            behaviorState.idle = Enums.EEnemyBehaviorState.Waiting;
            return Enums.EBTNodeState.Failure;
        }
        else if(behaviorState.idle == Enums.EEnemyBehaviorState.End)
        {
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            return Enums.EBTNodeState.Success;
        }
        else
        {
            return Enums.EBTNodeState.Running;
        }
    }
    #endregion
#endregion

#region animator
    public void Animator_die()
    {
        team.EnemyDie();
        Destroy(gameObject);
    }
    public void Animator_beAttackedEnd()
    {
        behaviorState.beAttacked = Enums.EEnemyBehaviorState.End ;
        isBeAttacked = false ;
    }
    public void Animator_attackEnd()
    {
        behaviorState.attack = Enums.EEnemyBehaviorState.End ;
    }
    public void Animator_skillBegEnd()
    {
        behaviorState.skillBeg = Enums.EEnemyBehaviorState.End ;
    }
    public void Animator_skillOnEnd()
    {
        behaviorState.skillOn = Enums.EEnemyBehaviorState.End ;
    }
    public void Animator_skillEndEnd()
    {
        behaviorState.skillEnd = Enums.EEnemyBehaviorState.End ;
    }
    public void Animator_attackDetect()
    {
        isAttacking = false ;
        Collider[] colliders = Physics.OverlapSphere(transform.position, attribute.attackDistance);
        foreach(Collider collider in colliders)
        {
            if(collider.tag != "Player") continue;
            Vector3 directionToCollider = collider.transform.position - transform.position;
            directionToCollider.y = 0;
            float angle = Vector3.Angle(transform.forward, directionToCollider);
            if(angle > attribute.attackAngle/2) continue;
            Structs.AttackAttribute attackAttribute = new Structs.AttackAttribute(attribute.damage_hp_attack , attribute.damage_poise_attack , directionToCollider.normalized);
            collider.GetComponent<Creature>().BeAttacked( attackAttribute, this);
            // Debug.Log("attack on");
        }
    }
    public void Animator_skillDetect()
    {
        isAttacking = false ;
        Collider[] colliders = Physics.OverlapSphere(transform.position, attribute.skillDistance);
        foreach(Collider collider in colliders)
        {
            if(collider.tag != "Player") continue;
            Vector3 directionToCollider = collider.transform.position - transform.position;
            directionToCollider.y = 0;
            float angle = Vector3.Angle(transform.forward, directionToCollider);
            if(angle > attribute.skillAngle/2) continue;
            Structs.AttackAttribute attackAttribute = new Structs.AttackAttribute(attribute.damage_hp_skill , attribute.damage_poise_skill , directionToCollider.normalized);
            collider.GetComponent<Creature>().BeAttacked( attackAttribute, this);
            // Debug.Log("skill on");
        }
    }

    public void Animator_isParry()
    {
        isAttacking = true ;
    }
#endregion

#region fight
    // public override Structs.AttackAttribute BeAttacked(Structs.AttackAttribute attackAttribute, Creature attacker)
    public override void BeAttacked(Structs.AttackAttribute attackAttribute, Creature attacker)
    {
        attribute.hp -= attackAttribute.damage_hp ;
        attribute.poise -= attackAttribute.damage_poise;
        if(attribute.poise <= 0)
        {
            attribute.poise = attribute.poise_max;
            isBeAttacked = true ;
        }
        // return Structs.attackAttribute_null;
    }

    public override bool IsParry(Vector3 position)
    {
        // Debug.Log("parry :" + isAttacking);
        if(isAttacking)
        {
            // return true ;
            // if((position - transform.position).sqrMagnitude > attribute.attackDistance * attribute.attackDistance * 4)
            //     return false ;
// return true ;
            Vector3 directionToCollider = position - transform.position;
            directionToCollider.y = 0;
            float angle = Vector3.Angle(transform.forward, directionToCollider);
            // Debug.Log(angle);
            // if(angle < attribute.attackAngle/2)
            if(angle < 90)
            {
                return true;
            }
        }

        return false ;
    }
    public override Vector3 GetParryPosition(Vector3 position)
    {
        Vector3 direction = position - transform.position;
        return direction.normalized * attribute.attackDistance * 0.9f + transform.position ;
    }
    #endregion

}
