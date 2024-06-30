using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBuilder 
{
    // protected Creature creature ;
    protected BTNode root ;
    protected Stack<BTNode> nodeStack;
    public BTBuilder()
    {
        root = null ;
        nodeStack = new Stack<BTNode> ();
    }
    public void AddNode(BTNode node )
    {
        if(nodeStack.Count == 0)
        {
            root = node ;
            nodeStack.Push(node) ;
            return ;
        }

        nodeStack.Peek().AddNode(node);
        nodeStack.Push(node);
    }
    public void AddNode_creature(Node_creature node)
    {
        if(nodeStack.Count == 0)
        {
            root = node ;
            return ;
        }
        nodeStack.Peek().AddNode(node);
    }

    public void Back()
    {
        nodeStack.Pop();
    }

    public virtual BTNode Build(Creature creature)
    {
        nodeStack.Clear();
        return null;
    }
}
