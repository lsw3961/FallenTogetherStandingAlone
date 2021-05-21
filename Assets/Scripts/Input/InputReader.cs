using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
[CreateAssetMenu(fileName ="Input Reader",menuName = "Input/Input Reader")]
public class InputReader : ScriptableObject, InputController.IPlayerActions
{

    public event UnityAction<Vector2> moveEvent = delegate { };
    public event UnityAction interactEvent = delegate { };
    public event UnityAction LeftClick = delegate { };
    public event UnityAction RightClick = delegate { };
    public event UnityAction Space = delegate { };

    private InputController gameInput;
    private Vector2 mousePosition;

    public Vector2 MousePosition
    {
        get
        {
            return mousePosition;
        }
    }

    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new InputController();
            gameInput.Player.SetCallbacks(this);
        }
        EnablePlayerInput();
    }

    public void EnablePlayerInput()
    {
        gameInput.Player.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            interactEvent.Invoke();
        }
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && context.ReadValueAsButton())
        {
            LeftClick.Invoke();
        }
    }

    public void OnDrag(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            RightClick.Invoke();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Space.Invoke();
        }
    }
}
