using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_repeat : BTNode
{
    int repeatTime;
    int repeatedTime;
    BTNode child ;
    public Node_repeat(int repeatTime)
    {
        this.repeatTime = repeatTime;
        this.repeatedTime = 0;
    }
    public override void AddNode(BTNode node)
    {
        child = node;
    }

    public override Enums.EBTNodeState Execute()
    {
        while(repeatedTime < repeatTime)
        {
            Enums.EBTNodeState midState = child.Execute();
            if(midState == Enums.EBTNodeState.Success)
            {
                repeatedTime ++;
                if(repeatedTime == repeatTime)
                {
                    repeatedTime = 0;
                    return Enums.EBTNodeState.Success;
                }
            }
            else if(midState == Enums.EBTNodeState.Running)
            {
                return Enums.EBTNodeState.Running;
            }
            else
            {
                return Enums.EBTNodeState.Failure;
            }
        }
        Debug.Log("error: get out of loop");
        return Enums.EBTNodeState.Failure;
    }
}
