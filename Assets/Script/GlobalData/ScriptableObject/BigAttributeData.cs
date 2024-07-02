using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BigAttributeData", menuName = "SO/BigAttributeData", order = 0)]
public class BigAttributeData : AttributeData
{
    public bool isBackEnd;
    public int ID ;
    public float hp ;
    public float hp_max ;
    public float poise ;
    public float poise_max ;
    public float speed ;
    public float lockDistance ; 
    public float angle_lock ; 
    public float time_rotate_run ;
    public float time_rotate_attack ;
    public float time_rotate_skill_E ;
    public float time_rotate_skill_Q ;
    public float time_rotate_dash ;
    public float time_parry;
    public float parryDistance ;
    public Vector3 velocity_parry ;
    public float time_dash ;
    public Vector3 velocity_dash ;
    public bool isInvisible ;
    public float isInvisible_dash ;
    public float invisibleTime_dash ;
    public float freezeFrameSpeed ;
    public float freezeFrameTime ;
    public float freezeTimeTime ;
    public float prepareTime_dash ;
    public float[] damage_hp_attack ;
    public float[] damage_poise_attack ;
    public float time_skill_Q;
    public Vector3 velocity_skill_Q ;
    public float time_dashAttack_1;
    public Vector3 velocity_dashAttack1 ;
    public float damage_hp_skill_E ;
    public float damage_poise_skill_E ;
    public float damage_hp_skill_Q ;
    public float damage_poise_skill_Q ;
    public float[] damage_hp_dash ;
    public float[] damage_poise_dash ;
    public override Structs.CreatureAttribute CreateAttribute()
    {
        Structs.BigAttribute attribute = new Structs.BigAttribute
        {
            isBackEnd = isBackEnd,
            ID = ID,
            hp = hp,
            hp_max = hp_max,
            poise = poise,
            poise_max = poise_max,
            speed = speed,
            lockDistance = lockDistance, 
            angle_lock = angle_lock, 
            time_rotate_run = time_rotate_run,
            time_rotate_attack = time_rotate_attack,
            time_rotate_skill_E = time_rotate_skill_E,
            time_rotate_skill_Q = time_rotate_skill_Q,
            time_rotate_dash = time_rotate_dash,
            time_parry = time_parry,
            parryDistance = parryDistance ,
            velocity_parry = velocity_parry,
            time_dash = time_dash,
            velocity_dash = velocity_dash,
            isInvisible = isInvisible,
            isInvisible_dash = isInvisible_dash,
            invisibleTime_dash = invisibleTime_dash,
            freezeFrameSpeed = freezeFrameSpeed, 
            freezeFrameTime = freezeFrameTime, 
            freezeTimeTime = freezeTimeTime, 
            prepareTime_dash = prepareTime_dash,
            damage_hp_attack = damage_hp_attack,
            damage_poise_attack = damage_poise_attack,
            time_skill_Q = time_skill_Q,
            velocity_skill_Q = velocity_skill_Q,
            time_dashAttack_1 = time_dashAttack_1,
            velocity_dashAttack1 = velocity_dashAttack1,
            damage_hp_skill_E = damage_hp_skill_E,
            damage_poise_skill_E = damage_poise_skill_E,
            damage_hp_skill_Q = damage_hp_skill_Q,
            damage_poise_skill_Q = damage_poise_skill_Q,
            damage_hp_dash = damage_hp_dash,
            damage_poise_dash = damage_poise_dash,
        };
        return attribute;
    }
    public override Structs.CreatureAttribute ModifyAttribute(Structs.CreatureAttribute a)
    {
        Structs.BigAttribute attribute = (Structs.BigAttribute)a;
        attribute.hp_max = hp_max;
        attribute.poise_max = poise_max;
        attribute.speed = speed;
        attribute.lockDistance = lockDistance;
        attribute.angle_lock = angle_lock; 
        attribute.time_rotate_run = time_rotate_run;
        attribute.time_rotate_attack = time_rotate_attack;
        attribute.time_rotate_skill_E = time_rotate_skill_E;
        attribute.time_rotate_skill_Q = time_rotate_skill_Q;
        attribute.time_rotate_dash = time_rotate_dash;
        attribute.time_parry = time_parry;
        attribute.parryDistance = parryDistance;
        attribute.freezeFrameSpeed = freezeFrameSpeed; 
        attribute.freezeFrameTime = freezeFrameTime; 
        attribute.freezeTimeTime = freezeTimeTime; 
        attribute.velocity_parry = velocity_parry;
        attribute.time_dash = time_dash;
        attribute.velocity_dash = velocity_dash;
        attribute.invisibleTime_dash = invisibleTime_dash;
        attribute.prepareTime_dash = prepareTime_dash;
        attribute.damage_hp_attack = damage_hp_attack;
        attribute.damage_poise_attack= damage_poise_attack;
        attribute.time_skill_Q = time_skill_Q;
        attribute.velocity_skill_Q= velocity_skill_Q;
        attribute.time_dashAttack_1 = time_dashAttack_1;
        attribute.velocity_dashAttack1 = velocity_dashAttack1;
        attribute.damage_hp_skill_E = damage_hp_skill_E;
        attribute.damage_poise_skill_E = damage_poise_skill_E;
        attribute.damage_hp_skill_Q = damage_hp_skill_Q;
        attribute.damage_poise_skill_Q = damage_poise_skill_Q;
        attribute.damage_hp_dash = damage_hp_dash;
        attribute.damage_poise_dash = damage_poise_dash;
        return attribute;
    }
}
