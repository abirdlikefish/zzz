using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAttribute
{
    public int ID { get; set; }
    public float hp{ get; set; }
    public float hp_max{ get; set; }

    public float poise{get ; set ;}
    public float poise_max{get ; set ;}

    public Vector3 direction{get; set; }
    public float speed_run{get; set; }
    public float speed_walk{get; set; }

    public List<float> damage_hp_attack{ get; set; }
    public List<float> damage_poise_attack{ get; set; }
    public List<float> damage_hp_skill{ get; set; }
    public List<float> damage_poise_skill{ get; set; }
}
