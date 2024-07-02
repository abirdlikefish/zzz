using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Priority
{
    static Priority()
    {
        playerState = new int[30];
        playerState[(int)Enums.EPlayerState.Idle] = 0;
        playerState[(int)Enums.EPlayerState.Run] = 1;
        playerState[(int)Enums.EPlayerState.Attack] = 2;
        playerState[(int)Enums.EPlayerState.Skill_E] = 3;
        playerState[(int)Enums.EPlayerState.Skill_Q] = 4;
        playerState[(int)Enums.EPlayerState.Dash] = 5;
        playerState[(int)Enums.EPlayerState.Parry] = 5;
        // playerState[(int)Enums.EPlayerState.Defend] = 5;
        playerState[(int)Enums.EPlayerState.BeAttacked] = 5;
        playerState[(int)Enums.EPlayerState.Support] = 6;
        playerState[(int)Enums.EPlayerState.BackEnd] = 9;

        playerCommand = new int[30];
        playerCommand[(int)Enums.EPlayerCommand.Move] = 1;
        playerCommand[(int)Enums.EPlayerCommand.Attack] = 2;
        playerCommand[(int)Enums.EPlayerCommand.Skill_E] = 3;
        playerCommand[(int)Enums.EPlayerCommand.Skill_Q] = 4;
        // playerCommand[(int)Enums.EPlayerCommand.Defend] = 5;
        playerCommand[(int)Enums.EPlayerCommand.Dash] = 5;
        playerCommand[(int)Enums.EPlayerCommand.Support] = 6;
        playerCommand[(int)Enums.EPlayerCommand.ChangeCharacter] = 10;


    }

    public static int[] playerState;
    public static int[] playerCommand ;

}
