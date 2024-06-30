using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public GameStateMachine gameStateMachine ;
    public Enums.EGameState eGameState ;

    public GameState(GameStateMachine gameStateMachine , Enums.EGameState eGameState)
    {
        this.gameStateMachine = gameStateMachine ;
        this.eGameState = eGameState;
    }
    public virtual void EnterState()
    {

    }

    public virtual void ExitState()
    {

    }

    public virtual void Update()
    {
        
    }
}
