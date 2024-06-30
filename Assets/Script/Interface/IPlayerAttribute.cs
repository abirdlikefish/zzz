using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAttribute
{
    public int ID { get; set; }
    public float hp{ get; set; }
    public float hp_max{ get; set; }

    public float poise{get ; set ;}
    public float poise_max{get ; set ;}
    public float minAngleCos{get; set; }

    public Vector3 direction{get; set; }

    public bool isInvisible{ get; set; }

    public float isInvisible_dash{ get; set; }
    public float invisibleTime_dash{ get; set; }
    public float prepareTime_dash{ get; set; }

    public float isInvisible_parry{ get; set; }
    public float invisibleTime_parry{ get; set; }
    public float prepareTime_parry{ get; set; }

    public float damage_poise_parry{ get; set; }

    public bool isInvisible_defend { get ; set ; }

    public List<float> damage_hp_attack{ get; set; }
    public List<float> damage_poise_attack{ get; set; }
    public List<float> damage_hp_skill_E{ get; set; }
    public List<float> damage_poise_skill_E{ get; set; }
    public List<float> damage_hp_skill_Q{ get; set; }
    public List<float> damage_poise_skill_Q{ get; set; }
}
