using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand_dash : IPlayerCommand
{
    public Enums.EPlayerCommand ePlayerCommand { get; set; }
    public Vector3 direction { get; set; }

    public void Execute(Creature creature)
    {
        (creature as Player).BegDash(direction);
    }
    public PlayerCommand_dash()
    {
        ePlayerCommand = Enums.EPlayerCommand.Dash;
    }
}
