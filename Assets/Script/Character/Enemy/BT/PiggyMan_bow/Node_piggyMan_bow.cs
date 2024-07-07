using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_piggyMan_bow_die : Node_creature
{
    public Node_piggyMan_bow_die(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_bow).AnimationBeg_die();
    }
}
public class Node_piggyMan_bow_ifBeAttacked : Node_creature
{
    public Node_piggyMan_bow_ifBeAttacked(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_bow).IfBeAttacked() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }
}
public class Node_piggyMan_bow_beAttacked : Node_creature
{
    public Node_piggyMan_bow_beAttacked(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_bow).AnimationBeg_beAttacked();
    }
}
public class Node_piggyMan_bow_findPlayer : Node_creature
{
    public Node_piggyMan_bow_findPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_bow).FindPlayer() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }
}
public class Node_piggyMan_bow_ifNeedWalkToPlayer : Node_creature
{
    public Node_piggyMan_bow_ifNeedWalkToPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_bow).IfNeedWalkToPlayer() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }
}
public class Node_piggyMan_bow_ifNearPlayer : Node_creature
{
    public Node_piggyMan_bow_ifNearPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_bow).IfNearPlayer() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }

}
public class Node_piggyMan_bow_runToPlayer : Node_creature
{
    public Node_piggyMan_bow_runToPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_bow).AnimationBeg_run();
    }
}
public class Node_piggyMan_bow_walkToPlayer : Node_creature
{
    public Node_piggyMan_bow_walkToPlayer(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_bow).AnimationBeg_walk();
    }
}
public class Node_piggyMan_bow_ifSkillOnCD : Node_creature
{
    public Node_piggyMan_bow_ifSkillOnCD(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_bow).IfSkillOnCD() ? Enums.EBTNodeState.Success : Enums.EBTNodeState.Failure;
    }
}
public class Node_piggyMan_bow_attack : Node_creature
{
    public Node_piggyMan_bow_attack(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_bow).AnimationBeg_attack();
    }
}
public class Node_piggyMan_bow_keepAway : Node_creature
{
    public Node_piggyMan_bow_keepAway(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_bow).AnimationBeg_keepAway();
    }
}

public class Node_piggyMan_bow_idle : Node_creature
{
    public Node_piggyMan_bow_idle(Creature creature) : base(creature){}
    public override Enums.EBTNodeState Execute()
    {
        return (creature as PiggyMan_bow).AnimationBeg_idle();
    }
}


