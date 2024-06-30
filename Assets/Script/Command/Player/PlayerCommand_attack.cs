using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand_attack : IPlayerCommand
{
    public Enums.EPlayerCommand ePlayerCommand { get; set; }
    public Vector3 direction { get; set; }

    public void Execute(Creature creature)
    {
        (creature as Player).BegAttack(direction);
    }
    public PlayerCommand_attack()
    {
        ePlayerCommand = Enums.EPlayerCommand.Attack;
    }
}
