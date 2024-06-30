using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand_move : IPlayerCommand
{
    public Enums.EPlayerCommand ePlayerCommand { get; set; }
    public Vector3 direction { get; set; }

    public void Execute(Creature creature)
    {
        (creature as Player).BegMove(direction);
    }
    public PlayerCommand_move()
    {
        ePlayerCommand = Enums.EPlayerCommand.Move;
    }
}
