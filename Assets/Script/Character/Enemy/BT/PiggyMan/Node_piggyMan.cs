using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_piggyMan_ifBeAttacked : Node_creature
{
    public Node_piggyMan_ifBeAttacked(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).IfBeAttacked() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }
}
public class Node_piggyMan_beAttacked : Node_creature
{
    public Node_piggyMan_beAttacked(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_beAttacked();
    }
}
public class Node_piggyMan_findPlayer : Node_creature
{
    public Node_piggyMan_findPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).FindPlayer() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }
}
public class Node_piggyMan_ifNeedWalkToPlayer : Node_creature
{
    public Node_piggyMan_ifNeedWalkToPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).IfNeedWalkToPlayer() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }
}
public class Node_piggyMan_ifNearPlayer : Node_creature
{
    public Node_piggyMan_ifNearPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).IfNearPlayer() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }

}
public class Node_piggyMan_runToPlayer : Node_creature
{
    public Node_piggyMan_runToPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_run();
    }
}
public class Node_piggyMan_walkToPlayer : Node_creature
{
    public Node_piggyMan_walkToPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_walk();
    }
}
public class Node_piggyMan_ifSkillOnCD : Node_creature
{
    public Node_piggyMan_ifSkillOnCD(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).IfSkillOnCD() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }
}
public class Node_piggyMan_attack : Node_creature
{
    public Node_piggyMan_attack(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_attack();
    }
}
public class Node_piggyMan_skillBeg : Node_creature
{
    public Node_piggyMan_skillBeg(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_skillBeg();
    }
}
public class Node_piggyMan_skillOn : Node_creature
{
    public Node_piggyMan_skillOn(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_skillOn();
    }
}
public class Node_piggyMan_skillEnd : Node_creature
{
    public Node_piggyMan_skillEnd(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_dagger).AnimationBeg_skillEnd();
    }
}


