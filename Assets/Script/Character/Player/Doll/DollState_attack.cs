using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollState_attack : PlayerState
{
    private int _comboNum ;
    private bool _isFinished ;
    // private int _needComboNum ;
    public DollState_attack(PlayerStateMachine playerStateMachine , Enums.EPlayerState ePlayerState) : base(playerStateMachine , ePlayerState)
    {
        _comboNum = 0 ;
    }
    

    public override void EnterState()
    {
        base.EnterState();
        _comboNum = 0 ;
        _isFinished = false ;
        playerStateMachine.player.AnimationBeg_attack();
    }

    public override void ExitState()
    {
        base.ExitState();
        _comboNum = 0 ;
        _isFinished = false ;
        // _needComboNum = 1;
        playerStateMachine.player.AnimationEnd_attack();
        // playerStateMachine.player.SetAnimatorSpeed(1);
    }

    public override void Update()
    {
        if(playerStateMachine.player.attribute.isBackEnd)
        {
            return ;
        }
        
        Vector3 midDirection = InputBuffer.Instance.GetDirection();
        if(midDirection == Vector3.zero || midDirection.z > 0.9f)
        {
            playerStateMachine.player.LockEnemy();
            // playerStateMachine.player.FixForwardDirection(midDirection);
            playerStateMachine.player.FixForwardDirection_lock(ePlayerState);
        }
        else
        {
            playerStateMachine.player.FixForwardDirection(midDirection , ePlayerState);
        }
        
        if(_isFinished == true)
        {
            if(InputBuffer.Instance.IsAttack() )
            {
                _isFinished = false ;
                playerStateMachine.player.AnimationBeg_attack();
            }
        }
        IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Attack]);
        if(playerCommand != null)
        {
            playerCommand.Execute(playerStateMachine.player);
        }

    }
    public void Finished()
    {
        _isFinished = true ;
    }

    public void AddCombo()
    {
        _comboNum ++;
    }

    public Structs.AttackAttribute GetAttackAttribute()
    {
        // playerStateMachine.player.SetAnimatorSpeed(playerStateMachine.player.attribute.freezeFrameSpeed);
        // StartCoroutine

        Structs.AttackAttribute attackAttribute = new Structs.AttackAttribute();
        attackAttribute.damage_hp = playerStateMachine.player.attribute.damage_hp_attack[_comboNum - 1];
        attackAttribute.damage_poise = playerStateMachine.player.attribute.damage_poise_attack[_comboNum - 1];
        return attackAttribute;
    }

    // IEnumerator reSetAnimatorSpeed()
    // {
    //     yield return new WaitForSeconds(playerStateMachine.player.attribute.freezeFrameTime);
    //     playerStateMachine.player.SetAnimatorSpeed(1);
    // }

}
