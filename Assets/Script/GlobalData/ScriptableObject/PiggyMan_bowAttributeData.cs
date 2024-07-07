using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PiggyMan_bowAttributeData", menuName = "SO/PiggyMan_bowAttributeData", order = 0)]
public class PiggyMan_bowAttributeData : AttributeData
{
    public int ID ;
    public float hp ;
    public float hp_max ;
    public float poise ;
    public float poise_max ;
    public float speed_run ;
    public float speed_walk ;
    public float time_rotate ;
    public float maxFindDistance ;
    public float attackDistance ;
    public float runRange ;
    public float CD_skill ;
    public float CD_begTime ;
    public float damage_hp_attack ;
    public float damage_poise_attack ;
    public override Structs.CreatureAttribute CreateAttribute()
    {
        Structs.PiggyMan_bowAttribute attribute = new Structs.PiggyMan_bowAttribute
        {
            ID = ID ,
            hp = hp ,
            hp_max = hp_max ,
            poise = poise ,
            poise_max = poise_max ,
            speed_run = speed_run ,
            speed_walk = speed_walk ,
            time_rotate = time_rotate ,
            maxFindDistance = maxFindDistance ,
            attackDistance = attackDistance ,
            runRange = runRange ,
            CD_skill = CD_skill ,
            CD_begTime = CD_begTime ,
            damage_hp_attack = damage_hp_attack ,
            damage_poise_attack = damage_poise_attack ,
        };
        return attribute;
    }
    public override Structs.CreatureAttribute ModifyAttribute(Structs.CreatureAttribute a)
    {
        Structs.PiggyMan_bowAttribute attribute = (Structs.PiggyMan_bowAttribute)a;
        attribute.hp_max = hp_max ;
        attribute.poise_max = poise_max ;
        attribute.speed_run = speed_run ;
        attribute.speed_walk = speed_walk ;
        attribute.time_rotate = time_rotate ;
        attribute.maxFindDistance = maxFindDistance ;
        attribute.attackDistance = attackDistance ;
        attribute.runRange = runRange ;
        attribute.CD_skill = CD_skill ;
        attribute.damage_hp_attack = damage_hp_attack ;
        attribute.damage_poise_attack = damage_poise_attack ;
        return attribute;
    }
}