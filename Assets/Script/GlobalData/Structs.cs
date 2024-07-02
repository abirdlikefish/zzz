using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Structs
{
    // private static Vector3 zero = Vector3.zero;
#region attackAttribute
    public struct AttackAttribute
    {
        public bool isNull ;
        public float damage_poise ;
        public float damage_hp;
        public Vector3 direction ;

        public AttackAttribute(float damage_hp = 0, float damage_pose = 0, Vector3 direction = default,bool isNull = false )
        {
            this.isNull = isNull ;
            this.damage_poise = damage_pose;
            this.damage_hp = damage_hp;
            this.direction = direction;
        }
    }
    public static AttackAttribute attackAttribute_null = new AttackAttribute(0 , 0 , default, true);
    #endregion

    public class CreatureAttribute
    {
        
    }

#region  playerAttribute
    public class PlayerAttribute : CreatureAttribute
    {
        public int ID { get; set; }
        public bool isBackEnd{ get; set; }
        public float hp { get ; set ; }
        public float hp_max { get ; set ; }
        public float poise { get ; set ; }
        public float poise_max { get ; set ; }
        public float speed { get ; set ; }
        public float time_rotate_run { get ; set ; }
        public float time_rotate_attack { get ; set ; }
        public float time_rotate_skill_E { get ; set ; }
        public float time_rotate_skill_Q { get ; set ; }
        public float time_rotate_dash { get ; set ; }
        public float lockDistance { get ; set ; }
        public float angle_lock { get ; set ; }
        public float parryDistance { get ; set ; }
        public float time_parry{ get ; set ; }
        public Vector3 velocity_parry { get ; set ; }
        public float time_dash{ get ; set ;}
        public Vector3 velocity_dash { get ; set ; }
        public bool isInvisible { get ; set ; }
        public float isInvisible_dash { get; set; }
        public float invisibleTime_dash { get ; set ; }
        public float prepareTime_dash { get ; set ; }
        public float[] damage_hp_attack { get ; set ; }
        public float[] damage_poise_attack { get ; set ; }
        public float freezeFrameSpeed { get ; set ; }
        public float freezeFrameTime { get ; set ; }
        public float freezeTimeTime { get ; set ; }
    }

    public class DollAttribute : PlayerAttribute
    {
        public float time_skill_Q{ get ; set ;}
        public Vector3 velocity_skill_Q { get ; set ; }
        public float time_dashAttack_1{ get ; set ;}
        public Vector3 velocity_dashAttack1 { get ; set ; }
        public float damage_hp_skill_E { get ; set ; }
        public float damage_poise_skill_E { get ; set ; }
        public float damage_hp_skill_Q { get ; set ; }
        public float damage_poise_skill_Q { get ; set ; }
        public float[] damage_hp_dash { get ; set ; }
        public float[] damage_poise_dash { get ; set ; }
    }

    public class BigAttribute : PlayerAttribute
    {
        public float time_skill_Q{ get ; set ;}
        public Vector3 velocity_skill_Q { get ; set ; }
        public float time_dashAttack_1{ get ; set ;}
        public Vector3 velocity_dashAttack1 { get ; set ; }
        public float damage_hp_skill_E { get ; set ; }
        public float damage_poise_skill_E { get ; set ; }
        public float damage_hp_skill_Q { get ; set ; }
        public float damage_poise_skill_Q { get ; set ; }
        public float[] damage_hp_dash { get ; set ; }
        public float[] damage_poise_dash { get ; set ; }
    }
    #endregion

#region enemyAttribute
    // public class EnemyAttribute : IEnemyAttribute
    public class EnemyAttribute : CreatureAttribute
    {
        public int ID { get ; set ; }
        public float hp { get ; set ; }
        public float hp_max { get ; set ; }
        public float poise { get ; set ; }
        public float poise_max { get ; set ; }
        public float speed_run { get ; set ; }
        public float speed_walk { get ; set ; }
        public float time_rotate { get ; set ; }

    }
    public class PiggyMan_daggerAttribute : EnemyAttribute
    {
        public float attackDistance { get ; set ; }
        public float attackAngle { get ; set ; }
        public float skillDistance { get ; set ; }
        public float skillAngle { get ; set ; }
        public float speed_skill { get ; set ; }
        public float runRange { get ; set ; }
        public float CD_skill { get ; set ; }
        public float CD_begTime { get ; set ; }
        public float damage_hp_attack { get ; set ; }
        public float damage_poise_attack { get ; set ; }
        public float damage_hp_skill { get ; set ; }
        public float damage_poise_skill { get ; set ; }
    }
#endregion

}
