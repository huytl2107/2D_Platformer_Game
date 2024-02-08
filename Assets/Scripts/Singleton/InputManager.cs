using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InputManager : Singleton<InputManager>
{
    private float _dirX;
    private float _xAxis;
    [SerializeField] private InputActionReference _moveAction;
    [SerializeField] private InputActionReference _Jump;
    [SerializeField] private InputActionReference _Dash;
    [SerializeField] private InputActionReference _LookDown;
    private float _jumpValue = 0f;
    private float _dashValue = 0f;
    private float _lookDownValue = 0f;

    public override void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        Vector2 moveInput = _moveAction.action.ReadValue<Vector2>();
        _jumpValue = _Jump.action.ReadValue<float>();
        _dashValue = _Dash.action.ReadValue<float>();
        _lookDownValue = _LookDown.action.ReadValue<float>();
        _xAxis = moveInput.x;
        _dirX = Input.GetAxisRaw("Horizontal");
    }

    public bool Jump()
    {
        _jumpValue = _Jump.action.ReadValue<float>();
        if (_jumpValue > 0)
            return true;
        if (Input.GetButtonDown("Jump"))
            return true;
        return false;
    }

    public bool Dash()
    {
        _dashValue = _Dash.action.ReadValue<float>();
        if (_dashValue > 0)
            return true;
        if (Input.GetKeyDown(KeyCode.LeftShift))
            return true;
        return false;
    }

    public bool Left()
    {
        if (_dirX < 0 || _xAxis < 0)
            return true;
        return false;
    }

    public bool Right()
    {
        if (_dirX > 0 || _xAxis > 0)
            return true;
        return false;
    }

    public bool Moving()
    {
        if (_dirX != 0 || _xAxis != 0)
            return true;
        return false;
    }

    public bool Down()
    {
        _lookDownValue = _LookDown.action.ReadValue<float>();
        if (_lookDownValue > 0)
            return true;
        if (Input.GetKeyDown(KeyCode.LeftShift))
            return true;
        return false;
    }
}
