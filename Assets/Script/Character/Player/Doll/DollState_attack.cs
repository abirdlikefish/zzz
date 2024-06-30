using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollState_attack : PlayerState
{
    private int _comboNum ;
    private int _needComboNum ;
    public DollState_attack(PlayerStateMachine playerStateMachine , Enums.EPlayerState ePlayerState) : base(playerStateMachine , ePlayerState)
    {
        _comboNum = 0 ;
        _needComboNum = 1;
    }
    

    public override void EnterState()
    {
        base.EnterState();
        _comboNum = 0 ;
        playerStateMachine.player.AnimationBeg_attack();
    }

    public override void ExitState()
    {
        base.ExitState();
        _comboNum = 0 ;
        _needComboNum = 1;
        playerStateMachine.player.AnimationEnd_attack();
    }

    public override void Update()
    {
        base.Update();
        IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Attack]);
        if(playerCommand != null)
        {
            playerCommand.Execute(playerStateMachine.player);
        }

        if(IsContinue() == false&&InputBuffer.Instance.IsAttackCombo() )
        {
            playerStateMachine.player.AnimationBeg_attack();
        }
    }

    public void AddCombo()
    {
        _comboNum ++;
        // Debug.Log("attack combo num: " + _comboNum);
        // Debug.Log("need combo num: " + _needComboNum);
    }

    public bool IsContinue()
    {
        return _comboNum == _needComboNum;
    }

    public void AddNeedComboNum()
    {
        _needComboNum ++;;
    }

}
