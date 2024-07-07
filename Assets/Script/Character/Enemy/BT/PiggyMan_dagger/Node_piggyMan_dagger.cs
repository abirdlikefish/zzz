using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_piggyMan_dagger_die : Node_creature
{
    public Node_piggyMan_dagger_die(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_die();
    }
}
public class Node_piggyMan_dagger_ifBeAttacked : Node_creature
{
    public Node_piggyMan_dagger_ifBeAttacked(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).IfBeAttacked() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }
}
public class Node_piggyMan_dagger_beAttacked : Node_creature
{
    public Node_piggyMan_dagger_beAttacked(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_beAttacked();
    }
}
public class Node_piggyMan_dagger_findPlayer : Node_creature
{
    public Node_piggyMan_dagger_findPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).FindPlayer() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }
}
public class Node_piggyMan_dagger_ifNeedWalkToPlayer : Node_creature
{
    public Node_piggyMan_dagger_ifNeedWalkToPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).IfNeedWalkToPlayer() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }
}
public class Node_piggyMan_dagger_ifNearPlayer : Node_creature
{
    public Node_piggyMan_dagger_ifNearPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).IfNearPlayer() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }

}
public class Node_piggyMan_dagger_runToPlayer : Node_creature
{
    public Node_piggyMan_dagger_runToPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_run();
    }
}
public class Node_piggyMan_dagger_walkToPlayer : Node_creature
{
    public Node_piggyMan_dagger_walkToPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_walk();
    }
}
public class Node_piggyMan_dagger_ifSkillOnCD : Node_creature
{
    public Node_piggyMan_dagger_ifSkillOnCD(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).IfSkillOnCD() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }
}
public class Node_piggyMan_dagger_attack : Node_creature
{
    public Node_piggyMan_dagger_attack(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_attack();
    }
}
public class Node_piggyMan_dagger_skillBeg : Node_creature
{
    public Node_piggyMan_dagger_skillBeg(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_skillBeg();
    }
}
public class Node_piggyMan_dagger_skillOn : Node_creature
{
    public Node_piggyMan_dagger_skillOn(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_skillOn();
    }
}
public class Node_piggyMan_dagger_skillEnd : Node_creature
{
    public Node_piggyMan_dagger_skillEnd(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_skillEnd();
    }
}

public class Node_piggyMan_dagger_idle : Node_creature
{
    public Node_piggyMan_dagger_idle(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_idle();
    }
}


