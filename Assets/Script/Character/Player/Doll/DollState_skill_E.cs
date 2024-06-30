using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollState_skill_E : PlayerState
{
    public DollState_skill_E(PlayerStateMachine playerStateMachine, Enums.EPlayerState ePlayerState) : base(playerStateMachine, ePlayerState)
    {
    }
    bool isCommandCancelled ;
    bool isPrepared ;
    int _comboNum;
    int _needComboNum;
    public override void EnterState()
    {
        base.EnterState();
        playerStateMachine.player.AnimationBeg_skill_E();
        isPrepared = false;
        isCommandCancelled = false;
        _comboNum = 0;
        _needComboNum = 1;
    }
    public override void ExitState()
    {
        base.ExitState();
        playerStateMachine.player.AnimationEnd_skill_E();
    }
    public override void Update()
    {
        base.Update();
        IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Skill_E]);
        if(playerCommand != null)
        {
            playerCommand.Execute(playerStateMachine.player);
        }

        if(_comboNum == 0)
        {
            if(InputBuffer.Instance.IsCommandCancelled(Enums.EPlayerCommand.Skill_E))
            {
                isCommandCancelled = true ;
            }
            if(isCommandCancelled && isPrepared)
            {
                playerStateMachine.ChangeState(playerStateMachine.playerState_idle);
            }
        }
        if(isPrepared && InputBuffer.Instance.IsAttackCombo())
        {
            playerStateMachine.player.AnimationBeg_skill_E();
        }
    }
    public void Prepared()
    {
        isPrepared = true;
    }

    public void AddCombo()
    {
        _comboNum ++;
    }
    public void AddNeedComboNum()
    {
        _needComboNum ++;
    }
    public bool IsContinue()
    {
        return _comboNum == _needComboNum ;
    }
}
