using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimatorParameters
{

    public static int Speed = Animator.StringToHash("Speed");
    public static int IsIdle = Animator.StringToHash("IsIdle");
    public static int IsAttack = Animator.StringToHash("IsAttack");
    public static int IsAttackFinished = Animator.StringToHash("IsAttackFinished");
    public static int Trigger_attack = Animator.StringToHash("Trigger_attack");
    public static int IsRun = Animator.StringToHash("IsRun");
    public static int Trigger_run = Animator.StringToHash("Trigger_run");
    public static int Trigger_idle = Animator.StringToHash("Trigger_idle");
    public static int IsDefend = Animator.StringToHash("IsDefend");
    public static int Trigger_defend = Animator.StringToHash("Trigger_defend");
    public static int IsSkill_E = Animator.StringToHash("IsSkill_R");
    public static int Trigger_skill_E = Animator.StringToHash("Trigger_skill_E");
    public static int IsSkill_EPrepared = Animator.StringToHash("IsSkill_EPrepared");
    public static int IsSkill_EFinished = Animator.StringToHash("IsSkill_RFinished");
    public static int Trigger_dash = Animator.StringToHash("Trigger_dash");
    public static int IsDash = Animator.StringToHash("IsDash");
}
