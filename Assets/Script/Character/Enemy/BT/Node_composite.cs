using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Node_composite : BTNode
{
    protected List<BTNode> children ;
    protected int currentNodeID ;
    protected abstract void Init();
    public override void AddNode(BTNode child)
    {
        if(children == null)
        {
            children = new List<BTNode>();
        }
        children.Add(child);
    }
}
