using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyMan_dagger : Creature 
{
    Structs.Attribute_PiggyMan_dagger attribute ;
    Player player ;
    bool isBeAttacked ;
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
        public void SetAll(Enums.EEnemyBehaviorState state)
        {
            beAttacked = state;
            attack = state;
            run = state;
            walk = state;
            skillBeg = state;
            skillOn = state;
            skillEnd = state;
        }
    }
    BehaviorState behaviorState ;

#region Init
    protected override void Awake()
    {
        base.Awake();
        InitAttribute(new Structs.Attribute_PiggyMan_dagger());
        BTBuilder_piggyMan midBuilder = new BTBuilder_piggyMan();
        InitBTRoot(midBuilder.Build(this));
        InitBehaviorState();
        isBeAttacked = false ;

// test -----------------------
attribute.hp_max = 10 ;
attribute.hp = 10 ;
attribute.poise_max = 3 ;
attribute.poise = 3 ;
attribute.CD_skill = 10 ;
attribute.attackAngle = 120 ;
attribute.attackDistance = 2f ;
attribute.skillAngle = 180 ;
attribute.skillDistance = 2f ;
attribute.damage_hp_attack = 1;
attribute.damage_poise_attack = 1;
attribute.damage_hp_skill = 1;
attribute.damage_poise_skill = 1;
attribute.runRange = 10 ;
attribute.time_rotate = 0.5f;
attribute.speed_run = 3 ;
attribute.speed_walk = 1 ;
// ----------------------------
    }
    public void InitAttribute(Structs.Attribute_PiggyMan_dagger attribute)
    {
        this.attribute = attribute;
    }
    public void InitBTRoot(BTNode root)
    {
        this.BTroot = root;
    }
    private void InitBehaviorState()
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
    }

    public bool FindPlayer()
    {
//------------------
//------------------
        player = GameObject.Find("Doll").GetComponent<Player>();
        return player != null ;
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
    public Enums.EBTNodeState AnimationBeg_beAttacked()
    {
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
            // state_attack = Enums.EEnemyBehaviorState.Waiting ;
            behaviorState.SetAll(Enums.EEnemyBehaviorState.Waiting);
            return Enums.EBTNodeState.Success;
        }
        else
        {
            return Enums.EBTNodeState.Running;
        }
    }
    public Enums.EBTNodeState AnimationBeg_skillBeg()
    {
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
            return Enums.EBTNodeState.Running;
        }
    }
    public Enums.EBTNodeState AnimationBeg_skillEnd()
    {
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
    #endregion
#endregion

#region animator
    public void Animator_beAttackedEnd()
    {
        behaviorState.beAttacked = Enums.EEnemyBehaviorState.End ;
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
            Debug.Log("attack on");
        }
    }
    public void Animator_skillDetect()
    {
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
            Debug.Log("skill on");
        }
    }
#endregion

    #region 
    public override Structs.AttackAttribute BeAttacked(Structs.AttackAttribute attackAttribute, Creature attacker)
    {
        attribute.hp -= attackAttribute.damage_hp ;
        attribute.poise -= attackAttribute.damage_pose;
        if(attribute.poise <= 0)
        {
            attribute.poise = attribute.poise_max;
            isBeAttacked = true ;
        }
        return Structs.attackAttribute_null;
    }
    #endregion

}
