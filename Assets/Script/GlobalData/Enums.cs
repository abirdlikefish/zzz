using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Enums
{
    public enum EPlayerState
    {
        Idle ,
        Run ,
        Walk ,
        Attack ,
        // Defend ,
        Parry ,
        Support ,
        Skill_E ,
        Skill_Q ,
        Dash ,
        BeAttacked ,
        BackEnd
    }


    public enum EPlayerCommand
    {
        Move ,      //p1
        Attack ,    //p2
        Skill_E,    //p3
        Skill_Q ,   //p4
        // Defend ,    //p5
        Dash ,      //p5
        Support ,    //p6
        ChangeCharacter ,   //p10
    }

    public enum EGameState
    {
        LevelOn ,
        LevelSelection ,
        StartMenu 
    }

    public enum EBTNodeState
    {
        Success ,
        Failure ,
        Running 
        // ForceQuit
    }

    public enum EEnemyBehaviorState
    {
        Doing ,
        End ,
        Waiting ,
        ForceQuit
    }
}
