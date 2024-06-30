using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand_defend : IPlayerCommand
{
    public Enums.EPlayerCommand ePlayerCommand { get; set; }
    public Vector3 direction { get; set; }

    public void Execute(Creature creature)
    {
        (creature as Player).BegDefend(direction);
    }
    public PlayerCommand_defend()
    {
        ePlayerCommand = Enums.EPlayerCommand.Defend;
    }
}
