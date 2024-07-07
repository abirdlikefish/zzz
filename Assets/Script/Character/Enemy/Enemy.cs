using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    public virtual bool IsParry(Vector3 position)
    {
        return false;
    }
    public virtual void InitAttribute(Structs.EnemyAttribute attribute , Team_enemy team)
    {
    }
    // public void InitBTRoot(BTNode root)
    protected virtual void InitBTRoot()
    {
    }
    protected virtual void InitBehaviorState()
    {
    }
    public virtual Vector3 GetParryPosition(Vector3 position)
    {
        return default;
    }
}
