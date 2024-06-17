using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerState
{
    public void Update();
    public void EnterState();
    public void ExitState();
    public Enums.EPlayerState ePlayerState{ get; set; }
}
