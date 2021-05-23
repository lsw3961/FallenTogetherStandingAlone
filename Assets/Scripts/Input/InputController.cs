// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""06715cc1-4a76-48fc-a150-34c2ccfee8be"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3e818aa0-283a-4e6c-aa7d-dee63b3be3d1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drag"",
                    ""type"": ""Button"",
                    ""id"": ""d38066c8-b3c5-4d0b-be41-f84b00f9d16d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""DragRelease"",
                    ""type"": ""Button"",
                    ""id"": ""9a63c94d-b517-477c-902e-5c8aeac5b86f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""cd4e2369-4369-4a27-8a49-001e0de3d208"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShootRelease"",
                    ""type"": ""Button"",
                    ""id"": ""32fbda74-13bf-48cf-aa04-e82a43965e80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""38d172b4-6680-4da9-9424-9de73eaf346f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""8af381c8-3369-4b66-8eb8-664127961e2d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""be9783be-42ed-4207-ad41-1115d3f8ddda"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e54dc773-ef71-463d-88a6-1e1538571e53"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""83b6db73-e6f1-4e7e-aa98-eda94d0f2e83"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""5b3c8cb8-9c7d-4001-97eb-64d87a5ca8ab"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f01efdae-7cb2-48a1-9bdc-84e7de5cfb2a"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""053b6379-57db-42bc-87ad-187612d342bb"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""deb0a1ec-6853-48d9-838a-7d002fa22fb6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press,Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""996e374e-70bc-408c-affb-d184496f8fdd"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61f6557e-a5bf-4584-bdba-4f406546a554"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6bcc348a-7926-4a52-97cc-0963471357bc"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2a76985-ffad-4222-8855-4f5974734be5"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DragRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af80edce-de8d-4354-8b55-12124e5a96a7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShootRelease"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Drag = m_Player.FindAction("Drag", throwIfNotFound: true);
        m_Player_DragRelease = m_Player.FindAction("DragRelease", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_ShootRelease = m_Player.FindAction("ShootRelease", throwIfNotFound: true);
        m_Player_Point = m_Player.FindAction("Point", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Drag;
    private readonly InputAction m_Player_DragRelease;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_ShootRelease;
    private readonly InputAction m_Player_Point;
    private readonly InputAction m_Player_Jump;
    public struct PlayerActions
    {
        private @InputController m_Wrapper;
        public PlayerActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Drag => m_Wrapper.m_Player_Drag;
        public InputAction @DragRelease => m_Wrapper.m_Player_DragRelease;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @ShootRelease => m_Wrapper.m_Player_ShootRelease;
        public InputAction @Point => m_Wrapper.m_Player_Point;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Drag.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrag;
                @Drag.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrag;
                @Drag.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrag;
                @DragRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDragRelease;
                @DragRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDragRelease;
                @DragRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDragRelease;
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @ShootRelease.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootRelease;
                @ShootRelease.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootRelease;
                @ShootRelease.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShootRelease;
                @Point.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPoint;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Drag.started += instance.OnDrag;
                @Drag.performed += instance.OnDrag;
                @Drag.canceled += instance.OnDrag;
                @DragRelease.started += instance.OnDragRelease;
                @DragRelease.performed += instance.OnDragRelease;
                @DragRelease.canceled += instance.OnDragRelease;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @ShootRelease.started += instance.OnShootRelease;
                @ShootRelease.performed += instance.OnShootRelease;
                @ShootRelease.canceled += instance.OnShootRelease;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnDrag(InputAction.CallbackContext context);
        void OnDragRelease(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnShootRelease(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
