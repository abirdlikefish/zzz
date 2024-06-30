using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_selector : Node_composite
{
    public override Enums.EBTNodeState Execute()
    {
        while(true)
        {
            Enums.EBTNodeState midState = children[currentNodeID].Execute();
            if(midState == Enums.EBTNodeState.Failure)
            {
                currentNodeID ++;
                if(currentNodeID >= children.Count)
                {
                    currentNodeID = 0;
                    return Enums.EBTNodeState.Failure;
                }
                continue;
            }
            else if(midState == Enums.EBTNodeState.Success)
            {
                Init();
                return Enums.EBTNodeState.Success;
            }
            else if(midState == Enums.EBTNodeState.Running)
            {
                return Enums.EBTNodeState.Running;
            }
            else
            {
                Debug.Log("error EBTNodeState");
                break;
            }
        }
        return Enums.EBTNodeState.Failure;
    }
    protected override void Init()
    {
        currentNodeID = 0;
    }
}