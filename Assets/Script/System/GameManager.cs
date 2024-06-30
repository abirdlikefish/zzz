using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameStateMachine gameStateMachine ;

#region init
    void InitGameStateMachine()
    {
        gameStateMachine = new GameStateMachine(this , Enums.EGameState.StartMenu);
    }
#endregion

#region game state
    private void Update() 
    {
        gameStateMachine.Update();
    }
#endregion

#region archive
    public void SaveArchive()
    {

    }
    public void LoadArchive()
    {

    }
#endregion
    void Awake()
    {
        InitGameStateMachine();
    }
}
