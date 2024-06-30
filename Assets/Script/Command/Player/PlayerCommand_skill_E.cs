using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand_skill_E : IPlayerCommand
{
    public Enums.EPlayerCommand ePlayerCommand { get; set; }
    public Vector3 direction { get; set; }

    public void Execute(Creature creature)
    {
        (creature as Player).BegSkill_E(direction);
    }
    public PlayerCommand_skill_E()
    {
        ePlayerCommand = Enums.EPlayerCommand.Skill_E;
    }
}
