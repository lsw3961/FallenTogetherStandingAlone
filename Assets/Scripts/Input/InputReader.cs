using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


[CreateAssetMenu(fileName = "Input Reader", menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, InputController.IPlayerActions, InputController.IUIActions
{

    public event UnityAction<Vector2> MoveEvent = delegate { };
    public event UnityAction JumpEvent = delegate { };
    public event UnityAction LeftClick = delegate { };
    public event UnityAction LeftReleaseEvent = delegate { };
    public event UnityAction RightClick = delegate { };
    public event UnityAction RightReleaseEvent = delegate { };
    public event UnityAction InteractEvent = delegate { };
    public event UnityAction Press = delegate { };
    public event UnityAction JumpRelease = delegate { };
    public event UnityAction<float> Swap = delegate { };

    private InputController gameInput;
    private Vector2 mousePosition;

    public Vector2 MousePosition
    {
        get
        {
            return mousePosition;
        }
    }
    public void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new InputController();
            gameInput.Player.SetCallbacks(this);
            gameInput.UI.SetCallbacks(this);
        }
        EnablePlayerInput();
    }

    public void EnablePlayerInput()
    {
        gameInput.UI.Disable();
        gameInput.Player.Enable();
    }
    public void EnableDialogueInput()
    {
        gameInput.Player.Disable();
        gameInput.UI.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            JumpEvent.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            JumpRelease.Invoke();
        }
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            LeftClick.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            LeftReleaseEvent.Invoke();
        }
    }
    public void OnDrag(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            RightClick.Invoke();
        }
        if (context.phase == InputActionPhase.Canceled)
        {
            RightReleaseEvent.Invoke();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            InteractEvent.Invoke();
        }
    }

    public void OnLeftClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Press.Invoke();
        }
    }

    public void OnSwap(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Swap.Invoke(context.ReadValue<float>());
        }
    }
}
