using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand_support : IPlayerCommand
{
    public Enums.EPlayerCommand ePlayerCommand { get; set; }
    public Vector3 direction { get; set; }

    public void Execute(Creature creature)
    {
        // (creature as Player).BegDefend(direction);
        Debug.Log("support");
    }
    public PlayerCommand_support()
    {
        ePlayerCommand = Enums.EPlayerCommand.Support;
    }
}
