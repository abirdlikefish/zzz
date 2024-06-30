using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCommand_skill_Q : IPlayerCommand
{
    public Enums.EPlayerCommand ePlayerCommand { get; set; }
    public Vector3 direction { get; set; }

    public void Execute(Creature creature)
    {
        (creature as Player).BegSkill_Q(direction);
    }
    public PlayerCommand_skill_Q()
    {
        ePlayerCommand = Enums.EPlayerCommand.Skill_Q;
    }
}
