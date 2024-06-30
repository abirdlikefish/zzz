using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_sequence : Node_composite
{
    public override Enums.EBTNodeState Execute()
    {
        while(true)
        {
            // Debug.Log(currentNodeID);
            Enums.EBTNodeState midState = children[currentNodeID].Execute();
            if(midState == Enums.EBTNodeState.Failure)
            {
                Init();
                return Enums.EBTNodeState.Failure;
            }
            else if(midState == Enums.EBTNodeState.Success)
            {
                currentNodeID ++;
                if(currentNodeID >= children.Count)
                {
                    Init();
                    return Enums.EBTNodeState.Success ;
                }
                continue;
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
