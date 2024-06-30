using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Node_creature : BTNode
{
    public override Enums.EBTNodeState Execute()
    {
        Debug.Log("error : Node_piggyMan is used");
        return Enums.EBTNodeState.Failure ;
    }

    public override void AddNode(BTNode node)
    {
        Debug.Log("error : Node_creature cannot add node");
    }

    protected Creature creature;
    public Node_creature(Creature creature)
    {
        this.creature = creature ;
    }
}
