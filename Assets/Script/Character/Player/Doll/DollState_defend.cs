using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DollState_defend : PlayerState
{
    bool isCommandCancelled ;
    bool isPrepared ;
    public DollState_defend(PlayerStateMachine playerStateMachine, Enums.EPlayerState ePlayerState) : base(playerStateMachine, ePlayerState)
    {
    }
    /*
    public override void EnterState()
    {
        base.EnterState();
        playerStateMachine.player.AnimationBeg_defend();
        isPrepared = false;
        isCommandCancelled = false;
        playerStateMachine.player.SetInvisible_defend(true);
        playerStateMachine.player.SetInvisibleBeg_parry(true);
    }
    public override void ExitState()
    {
        base.ExitState();
        playerStateMachine.player.AnimationEnd_defend();
        playerStateMachine.player.SetInvisible_defend(false);
        playerStateMachine.player.SetInvisibleBeg_parry(false);
    }
    public override void Update()
    {
        base.Update();
        IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Defend]);
        if(playerCommand != null)
        {
            playerCommand.Execute(playerStateMachine.player);
        }
        if(InputBuffer.Instance.IsCommandCancelled(Enums.EPlayerCommand.Defend))
        {
            isCommandCancelled = true ;
        }
        if(isCommandCancelled && isPrepared)
        {
            playerStateMachine.ChangeState(playerStateMachine.playerState_idle);
        }
        // Debug.Log("isCommandCancelled :" + isCommandCancelled + "isPrepared :" + isPrepared );
    }
    public void Prepared()
    {
        isPrepared = true;
    }
    public void Success_defend()
    {
        playerStateMachine.player.AnimationBeg_defendSuccess_heavy();
    }
    public void Success_parry()
    {
        playerStateMachine.player.AnimationBeg_parrySuccess();
    }
    */
}
