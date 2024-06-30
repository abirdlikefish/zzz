using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Structs
{
    private static Vector3 zero = Vector3.zero;
#region attackAttribute
    public struct AttackAttribute
    {
        public bool isNull ;
        public float damage_pose ;
        public float damage_hp;
        public Vector3 direction ;

        public AttackAttribute(float damage_hp = 0, float damage_pose = 0, Vector3 direction = default,bool isNull = false )
        {
            this.isNull = isNull ;
            this.damage_pose = damage_pose;
            this.damage_hp = damage_hp;
            this.direction = direction;
        }
    }
    public static AttackAttribute attackAttribute_null = new AttackAttribute(0 , 0 , default, true);
    #endregion

#region  playerAttribute
    public class PlayerAttribute : IPlayerAttribute
    {
        public int ID { get; set; }
        public float hp { get ; set ; }
        public float hp_max { get ; set ; }
        public float poise { get ; set ; }
        public float poise_max { get ; set ; }
        public float minAngleCos{get; set; }
        public Vector3 direction{get; set; }
        public bool isInvisible { get ; set ; }
        public float isInvisible_dash { get; set; }
        public float invisibleTime_dash { get ; set ; }
        public float prepareTime_dash { get ; set ; }
        public float isInvisible_parry { get ; set ; }
        public float invisibleTime_parry { get ; set ; }
        public float prepareTime_parry { get ; set ; }
        public float damage_poise_parry{ get; set; }
        public bool isInvisible_defend { get ; set ; }
        public List<float> damage_hp_attack { get ; set ; }
        public List<float> damage_poise_attack { get ; set ; }
        public List<float> damage_hp_skill_E { get ; set ; }
        public List<float> damage_poise_skill_E { get ; set ; }
        public List<float> damage_hp_skill_Q { get ; set ; }
        public List<float> damage_poise_skill_Q { get ; set ; }
    }

    #endregion

#region enemyAttribute
    // public class EnemyAttribute : IEnemyAttribute
    public class EnemyAttribute
    {
        public int ID { get ; set ; }
        public float hp { get ; set ; }
        public float hp_max { get ; set ; }
        public float poise { get ; set ; }
        public float poise_max { get ; set ; }
        public float speed_run { get ; set ; }
        public float speed_walk { get ; set ; }
        public float time_rotate { get ; set ; }
        public Vector3 direction { get ; set ; }

    }
    public class Attribute_PiggyMan_dagger : EnemyAttribute
    {
        public float attackDistance { get ; set ; }
        public float attackAngle { get ; set ; }
        public float skillDistance { get ; set ; }
        public float skillAngle { get ; set ; }
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
