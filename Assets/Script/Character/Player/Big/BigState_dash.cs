using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigState_dash : PlayerState
{
    float remainingTime ;
    float totalTime ;
    int comboNum ;
    public BigState_dash(PlayerStateMachine playerStateMachine, Enums.EPlayerState ePlayerState) : base(playerStateMachine, ePlayerState)
    {
    }
    private bool isPrepared ;
    
    public override void EnterState()
    {
        base.EnterState();
        isPrepared = false;
        playerStateMachine.player.AnimationBeg_dash();
        playerStateMachine.player.SetInvisibleBeg_dash(true);
        remainingTime = (playerStateMachine.player.attribute as Structs.BigAttribute).time_dash;
        totalTime = (playerStateMachine.player.attribute as Structs.BigAttribute).time_dash;
        comboNum = 0;
    }
    public override void ExitState()
    {
        base.ExitState();
        playerStateMachine.player.AnimationEnd_dash();
        isPrepared = false;
        playerStateMachine.player.SetInvisibleBeg_dash(false);
    }
    public override void Update()
    {
        if(comboNum == 1)
        {
            if(remainingTime > 0)
            {
                float k = remainingTime / totalTime;
                // playerStateMachine.player.Move((playerStateMachine.player.attribute as Structs.BigAttribute).velocity_dash * k * Time.deltaTime);
                playerStateMachine.player.Move((playerStateMachine.player.attribute as Structs.BigAttribute).velocity_dash * Mathf.Pow(k , 3) * Time.deltaTime);
                remainingTime -= Time.deltaTime;
            }
        }
        else if(comboNum == 2)
        {
            if(remainingTime > 0)
            {
                playerStateMachine.player.Move((playerStateMachine.player.attribute as Structs.BigAttribute).velocity_dashAttack1 * remainingTime / totalTime * Time.deltaTime);
                remainingTime -= Time.deltaTime;
            }
            
            playerStateMachine.player.LockEnemy();
            playerStateMachine.player.FixForwardDirection_lock(ePlayerState);
        }
        else
        {
            Vector3 midDirection = InputBuffer.Instance.GetDirection();
            if(midDirection == Vector3.zero || midDirection.z > 0.9f)
            {
                playerStateMachine.player.LockEnemy();
                playerStateMachine.player.FixForwardDirection_lock(ePlayerState);
            }
            else
            {
                playerStateMachine.player.FixForwardDirection(midDirection , ePlayerState);
            }
        }

        if(playerStateMachine.player.attribute.isBackEnd)
        {
            return ;
        }

        if(isPrepared)
        {
            if(InputBuffer.Instance.IsAttack())
            {
    // Debug.Log("prepared");
                isPrepared = false;
                playerStateMachine.player.AnimationBeg_dash();
            }
        }

        IPlayerCommand playerCommand ;
        if(isFree)
        {
            playerCommand = InputBuffer.Instance.GetCommand(0);
        }
        else
        {
            playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Dash]);
        }

        // IPlayerCommand playerCommand = InputBuffer.Instance.GetCommand(Priority.playerState[(int)Enums.EPlayerState.Dash]);
        if(playerCommand != null)
        {
            playerCommand.Execute(playerStateMachine.player);
        }
    }
    public void Prepared()
    {
        isPrepared = true;
    }
    public void AddCombo()
    {
        comboNum ++;
        if(comboNum == 1)
        {
            remainingTime = (playerStateMachine.player.attribute as Structs.BigAttribute).time_dash;
            totalTime = (playerStateMachine.player.attribute as Structs.BigAttribute).time_dash;
        }
        else
        {
            remainingTime = (playerStateMachine.player.attribute as Structs.BigAttribute).time_dashAttack_1;
            totalTime = (playerStateMachine.player.attribute as Structs.BigAttribute).time_dashAttack_1;
        }

    }
    public Structs.AttackAttribute GetAttackAttribute()
    {
        Structs.AttackAttribute attackAttribute = new Structs.AttackAttribute();
        attackAttribute.damage_hp = (playerStateMachine.player.attribute as Structs.BigAttribute).damage_hp_dash[comboNum - 2];
        attackAttribute.damage_poise = (playerStateMachine.player.attribute as Structs.BigAttribute).damage_poise_dash[comboNum - 2];
        return attackAttribute;
    }
}
