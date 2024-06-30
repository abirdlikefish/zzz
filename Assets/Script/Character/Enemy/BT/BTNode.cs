using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTNode 
{
    public abstract Enums.EBTNodeState Execute();
    public abstract void AddNode(BTNode node);

}
