using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputBuffer : MonoBehaviour , InputController.IGamePlayActions , InputController.IUIActions
{
    void Awake()
    {
        InitInstance();
        Init_controller();
        InitInputBuffer();
    }
#region init instance
    public static InputBuffer Instance {get ; private set;}
    private void InitInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
#endregion


#region init _controller
    private InputController _controller;
    private void Init_controller()
    {
        if(_controller == null)
        {
            _controller = new InputController();
        }
        _controller.GamePlay.SetCallbacks(this);
        _controller.UI.SetCallbacks(this);
        UseGamePlayActionMap();
    }

#endregion init _controller

#region init inputBuffer

    private float minBufferTime ;
    private Vector3 _inputDirection ;
    // private Vector3 _direction ;
    private float _skill_E ;
    private float _skill_E_cancel ;
    private float _skill_Q ;
    private float _skill_Q_cancel ;
    private float _attack ;
    private float _attack_cancel ;
    private float _defend ;
    private float _defend_cancel ;
    private float _dash ;
    private float _changeCharacter ;
    private float _stop ;
    private float _continue ;
    private void InitInputBuffer()
    {
        minBufferTime = 0.05f;
        _inputDirection = new Vector3(0f, 0f , 0f);
        // _direction = new Vector3(0f, 0f , 0f);
        _skill_E = -1f;
        _skill_E_cancel = -1f;
        _skill_Q = -1f;
        _skill_Q_cancel = -1f;
        _attack = -1f;
        _attack_cancel = -1f;
        _defend = -1f;
        _defend_cancel = -1f;
        _dash = -1f;
        _changeCharacter = -1f;
        _stop = -1f;
        _continue = -1f;
    }
#endregion

#region change action map function
    private void UseGamePlayActionMap () 
    {
        _controller.GamePlay.Enable();
        _controller.UI.Disable();
    }

    private void UseUIActionMap () 
    {
        _controller.UI.Enable();
        _controller.GamePlay.Disable();
    }
#endregion change action map function

#region GamePlayAction input 
    public void OnMove(InputAction.CallbackContext context)
    {        
        _inputDirection = new Vector3(context.ReadValue<Vector2>().x , 0 , context.ReadValue<Vector2>().y);
        // _direction = Camera.main.transform.TransformDirection(_inputDirection);
        // _direction = _direction.normalized;
    }

    public void OnSkill_E(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)
        {
            _skill_E_cancel = Time.time ;

        }
        else if(context.phase == InputActionPhase.Started)
        {
            _skill_E = Time.time ;
        }
    }

    public void OnSkill_Q(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)
        {
            _skill_Q_cancel = Time.time ;

        }
        else if(context.phase == InputActionPhase.Started)
        {
            _skill_Q = Time.time ;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)
        {
            _attack_cancel = Time.time ;

        }
        else if(context.phase == InputActionPhase.Started)
        {
            _attack = Time.time ;
        }
    }

    public void OnDefend(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)
        {
            _defend_cancel = Time.time ;

        }
        else if(context.phase == InputActionPhase.Started)
        {
            _defend = Time.time ;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        _dash = Time.time ;
    }

    public void OnChangeCharacter(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        _changeCharacter = Time.time ;
    }

    public void OnStop(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        throw new System.NotImplementedException();
    }

#endregion GamePlayAction function

#region UIAction input
    public void OnContinue(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
#endregion UIAction input


#region outside request

public IPlayerCommand GetCommand(int minPriority, int maxPriority = 15)
{
    if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.ChangeCharacter] && Time.time - _changeCharacter < minBufferTime )
    {
        _changeCharacter = -1;
        PlayerCommand_changeCharacter playerCommand_changeCharacter = new PlayerCommand_changeCharacter();
        playerCommand_changeCharacter.direction = _inputDirection;
        return playerCommand_changeCharacter;
    }
    if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.Dash] && Time.time - _dash < minBufferTime )
    {
        _dash = -1;
        PlayerCommand_dash playerCommand_dash = new PlayerCommand_dash();
        playerCommand_dash.direction = _inputDirection;
        return playerCommand_dash;
    }
    if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.Defend] && Time.time - _defend < minBufferTime )
    {
        _defend = -1;
        PlayerCommand_defend playerCommand_defend = new PlayerCommand_defend();
        playerCommand_defend.direction = _inputDirection;
        return playerCommand_defend;
    }
    if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.Skill_Q] && Time.time - _skill_Q < minBufferTime )
    {
        _skill_Q = -1;
        PlayerCommand_skill_Q playerCommand_skill_Q = new PlayerCommand_skill_Q();
        playerCommand_skill_Q.direction = _inputDirection;
        return playerCommand_skill_Q;
    }
    if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.Skill_E] && Time.time - _skill_E < minBufferTime )
    {
        _skill_E = -1;
        PlayerCommand_skill_E playerCommand_skill_E = new PlayerCommand_skill_E();
        playerCommand_skill_E.direction = _inputDirection;
        return playerCommand_skill_E;
    }
    if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.Attack] && Time.time - _attack < minBufferTime )
    {
        _attack = -1;
        PlayerCommand_attack playerCommand_attack = new PlayerCommand_attack();
        playerCommand_attack.direction = _inputDirection;
        return playerCommand_attack;
    }
    if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.Move] && _inputDirection != Vector3.zero)
    {
        PlayerCommand_move playerCommand_move = new PlayerCommand_move();
        playerCommand_move.direction = _inputDirection;
        return playerCommand_move;
    }
    return null;
}
public Vector3 GetDirection()
{
    return _inputDirection;
}

public bool IsAttackCombo()
{
    bool ans = Time.time - _attack < minBufferTime ;
    _attack = -1;
    return ans ;
}

public bool IsCommandCancelled(Enums.EPlayerCommand ePlayerCommand)
{
// Debug.Log(ePlayerCommand);
    bool ans ;
    switch(ePlayerCommand)
    {
        case Enums.EPlayerCommand.Attack: 
            ans = Time.time - _attack_cancel < minBufferTime ;
            _attack_cancel = -1;
            return ans ;
        case Enums.EPlayerCommand.Defend:
            ans = Time.time - _defend_cancel < minBufferTime ;
            _defend_cancel = -1;
            return ans ;
        case Enums.EPlayerCommand.Skill_E:
            ans = Time.time - _skill_E_cancel < minBufferTime ;
            _skill_E_cancel = -1;
            return ans;
        case Enums.EPlayerCommand.Skill_Q:
            ans = Time.time - _skill_Q_cancel < minBufferTime ;
            _skill_Q_cancel = -1;
            return ans;
        default:
            Debug.Log("error: IsCommandCancel function receive wrong ePlayerCommand");
            return false;
    }
}

#endregion outside request

}
