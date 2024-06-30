using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand_changeCharacter : IPlayerCommand
{
    public Enums.EPlayerCommand ePlayerCommand { get; set; }
    public Vector3 direction { get; set; }

    public void Execute(Creature creature)
    {
        (creature as Player).BegChangeCharacter(direction);
    }
    public PlayerCommand_changeCharacter()
    {
        ePlayerCommand = Enums.EPlayerCommand.ChangeCharacter;
    }
}
