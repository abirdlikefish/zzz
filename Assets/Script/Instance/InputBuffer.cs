using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputBuffer : MonoBehaviour , InputController.IGamePlayActions , InputController.IUIActions ,InputController.IStopMenuActions , InputController.ISelectMenuActions
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
        _controller.StopMenu.SetCallbacks(this);
        _controller.SelectMenu.SetCallbacks(this);
        // UseGamePlayActionMap();
        UseUIActionMap();
    }

#endregion init _controller

#region init inputBuffer

    #region GamePlay
    private float minBufferTime ;
    private Vector3 _inputDirection ;
    // private Vector3 _direction ;
    private float _skill_E ;
    private float _skill_E_cancel ;
    private float _skill_Q ;
    private float _skill_Q_cancel ;
    private float _attack ;
    private float _attack_cancel ;
    private float _changeCharacter ;
    private float _changeCharacter_cancel ;
    private float _dash ;
    private float _support ;
    private float _stop ;
    #endregion

    #region StopMenu
    private float _continue ;
    private float _return ;
    #endregion
    
    #region UI
    private float _beginGame ;
    private float _exitGame ;
    #endregion

    #region SelectMenu
    private float _addPiggyMan_dagger ;
    private float _addPiggyMan_bow ;
    private float _loadGame ;
    #endregion

    private void InitInputBuffer()
    {
        minBufferTime = 0.05f;
        _inputDirection = new Vector3(0f, 0f , 0f);
        _skill_E = -1f;
        _skill_E_cancel = -1f;
        _skill_Q = -1f;
        _skill_Q_cancel = -1f;
        _attack = -1f;
        _attack_cancel = -1f;
        _changeCharacter = -1f;
        _changeCharacter_cancel = -1f;
        _dash = -1f;
        _support = -1f;
        _stop = -1f;
        _continue = -1f;
        _return = -1f;
        _beginGame = -1f;
        _exitGame = -1f;
        _addPiggyMan_bow = -1f;
        _addPiggyMan_dagger = -1f;
        _loadGame = -1f;
    }
#endregion

#region change action map function
    public void UseGamePlayActionMap () 
    {
        _controller.GamePlay.Enable();
        _controller.UI.Disable();
        _controller.StopMenu.Disable();
        _controller.SelectMenu.Disable();
    }

    public void UseUIActionMap () 
    {
        _controller.UI.Enable();
        _controller.GamePlay.Disable();
        _controller.StopMenu.Disable();
        _controller.SelectMenu.Disable();
    }
    public void UseStopMenuMap()
    {
        _controller.StopMenu.Enable();
        _controller.UI.Disable();
        _controller.GamePlay.Disable();
        _controller.SelectMenu.Disable();
    }
    public void UseSelectMenuMap()
    {
        _controller.SelectMenu.Enable();
        _controller.StopMenu.Disable();
        _controller.UI.Disable();
        _controller.GamePlay.Disable();
    }
#endregion change action map function

#region GamePlayAction input 
    public void OnMove(InputAction.CallbackContext context)
    {        
        _inputDirection = new Vector3(context.ReadValue<Vector2>().x , 0 , context.ReadValue<Vector2>().y);
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

    public void OnChangeCharacter(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)
        {
            _changeCharacter_cancel = Time.time ;

        }
        else if(context.phase == InputActionPhase.Started)
        {
            _changeCharacter = Time.time ;
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        _dash = Time.time ;
    }

    public void OnSupport(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        _support = Time.time ;
    }

    public void OnStop(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        _stop = 1 ;
    }

#endregion GamePlayAction function

#region StopMenuAction input
    public void OnContinue(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        _continue = 1 ;
    }
    public void OnReturn(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        _return = 1 ;
    }
#endregion StopMenuAction input

#region UIAction input
    public void OnExitGame(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        _exitGame = 1 ;
    }
    public void OnBeginGame(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        _beginGame = 1 ;
    }
#endregion UIAction input


#region SelectMenu
    public void OnAddPiggyMan_dagger(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        _addPiggyMan_dagger = 1 ;
    }
    public void OnAddPiggyMan_bow(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        _addPiggyMan_bow = 1 ;
    }
    public void OnLoadGame(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Canceled)  return ;
        _loadGame = 1 ;
    }
#endregion SelectMenu

#region outside request

    #region GamePlay
    public bool IsStop()
    {
        if(_stop > 0)
        {
            _stop = -1;
            return true ;
        }
        return false ;
    }
    public bool IsSupport()
    {
        if(Time.time - _support < minBufferTime )
        {
            _support = -1;
            return true ;
        }
        return false ;
    }
    public bool IsChangeCharacter()
    {
        if(Time.time - _changeCharacter < minBufferTime )
        {
            _changeCharacter = -1;
            return true ;
        }
        return false ;
    }
    public bool IsDash()
    {
        if(Time.time - _dash < minBufferTime )
        {
            _dash = -1;
            return true ;
        }
        return false ;
    }
    public bool IsSkill_E()
    {
        if(Time.time - _skill_E < minBufferTime )
        {
            _skill_E = -1;
            return true ;
        }
        return false ;
    }
    public bool IsSkill_Q()
    {
        if(Time.time - _skill_Q < minBufferTime )
        {
            _skill_Q = -1;
            return true ;
        }
        return false ;
    }
    public bool IsAttack()
    {
        if(Time.time - _attack < minBufferTime )
        {
            _attack = -1;
            return true ;
        }
        return false ;
    }
    public IPlayerCommand GetCommand(int minPriority, int maxPriority = 15)
    {
        if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.Support] && IsSupport() )
        {
            // _support = -1;
            PlayerCommand_support playerCommand_support = new PlayerCommand_support();
            playerCommand_support.direction = _inputDirection;
            return playerCommand_support;
        }
        if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.ChangeCharacter] && IsChangeCharacter() )
        {
            // _changeCharacter = -1;
            PlayerCommand_changeCharacter playerCommand_changeCharacter = new PlayerCommand_changeCharacter();
            playerCommand_changeCharacter.direction = _inputDirection;
            return playerCommand_changeCharacter;
        }
        if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.Dash] && IsDash() )
        {
            // _dash = -1;
            PlayerCommand_dash playerCommand_dash = new PlayerCommand_dash();
            playerCommand_dash.direction = _inputDirection;
            return playerCommand_dash;
        }
        if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.Skill_Q] && IsSkill_Q() )
        {
            // _skill_Q = -1;
            PlayerCommand_skill_Q playerCommand_skill_Q = new PlayerCommand_skill_Q();
            playerCommand_skill_Q.direction = _inputDirection;
            return playerCommand_skill_Q;
        }
        if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.Skill_E] && IsSkill_E() )
        {
            // _skill_E = -1;
            PlayerCommand_skill_E playerCommand_skill_E = new PlayerCommand_skill_E();
            playerCommand_skill_E.direction = _inputDirection;
            return playerCommand_skill_E;
        }
        if(minPriority < Priority.playerCommand[(int)Enums.EPlayerCommand.Attack] && IsAttack() )
        {
            // _attack = -1;
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
            // case Enums.EPlayerCommand.ChangeCharacter:
            //     ans = Time.time - _changeCharacter_cancel < minBufferTime ;
            //     _changeCharacter_cancel = -1;
            //     return ans ;
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

    #endregion GamePlay

    #region UI
    public bool IsBeginGame()
    {
        if(_beginGame > 0)
        {
            _beginGame = -1;
            return true;
        }
        return false ;
    }
    public bool IsExitGame()
    {
        if(_exitGame > 0)
        {
            _exitGame = -1;
            return true;
        }
        return false ;
    }
    #endregion UI

    #region StopMenu
    public bool IsContinue()
    {
        if(_continue > 0)
        {
            _continue = -1;
            return true;
        }
        return false ;
    }
    public bool IsReturn()
    {
        if(_return > 0)
        {
            _return = -1;
            return true;
        }
        return false ;
    }
    #endregion StopMenu

    #region SelectMenu
    public bool IsAddPiggyMan_dagger()
    {
        if(_addPiggyMan_dagger > 0)
        {
            _addPiggyMan_dagger = -1;
            return true;
        }
        return false ;
    }
    public bool IsAddPiggyMan_bow()
    {
        if(_addPiggyMan_bow > 0)
        {
            _addPiggyMan_bow = -1;
            return true;
        }
        return false ;
    }
    public bool IsLoadGame()
    {
        if(_loadGame > 0)
        {
            _loadGame = -1;
            return true;
        }
        return false ;
    }

    #endregion SelectMenu

#endregion outside request

}
