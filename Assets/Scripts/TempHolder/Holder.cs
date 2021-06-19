//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.InputSystem;


//[CreateAssetMenu(fileName = "Input Reader", menuName = "Input/Input Reader")]
//public class InputReader : ScriptableObject, InputController.IPlayerActions, InputController.IUIActions
//{

//    public event UnityAction<Vector2> MoveEvent = delegate { };
//    public event UnityAction InteractEvent = delegate { };
//    public event UnityAction LeftClick = delegate { };
//    public event UnityAction RightClick = delegate { };
//    public event UnityAction JumpEvent = delegate { };
//    public event UnityAction RightReleaseEvent = delegate { };
//    public event UnityAction LeftReleaseEvent = delegate { };
//    public event UnityAction Press = delegate { };

//    private InputController gameInput;
//    private Vector2 mousePosition;

//    public Vector2 MousePosition
//    {
//        get
//        {
//            return mousePosition;
//        }
//    }
//    public void OnEnable()
//    {
//        if (gameInput == null)
//        {
//            gameInput = new InputController();
//            gameInput.Player.SetCallbacks(this);
//            gameInput.UI.SetCallbacks(this);
//            if (gameInput == null)
//            {
//                Debug.Log("Input reader is null.");
//            }
//        }
//        Debug.Log("Input reader has been made.");
//        EnablePlayerInput();
//        Debug.Log("input reader has enabled player Input");
//        //gameInput.UI.Enable();
//    }

//    public void EnablePlayerInput()
//    {
//        gameInput.Player.Enable();
//        gameInput.UI.Disable();
//    }
//    public void EnableDialogueInput()
//    {
//        gameInput.Player.Disable();
//        gameInput.UI.Enable();
//    }

//    public void OnMove(InputAction.CallbackContext context)
//    {
//        MoveEvent.Invoke(context.ReadValue<Vector2>());
//    }

//    public void OnJump(InputAction.CallbackContext context)
//    {
//        if (context.phase == InputActionPhase.Performed)
//        {
//            JumpEvent.Invoke();
//        }
//    }

//    public void OnInteract(InputAction.CallbackContext context)
//    {
//        if (context.phase == InputActionPhase.Performed)
//        {
//            InteractEvent.Invoke();
//        }
//    }

//    public void OnPoint(InputAction.CallbackContext context)
//    {
//        mousePosition = context.ReadValue<Vector2>();
//    }

//    public void OnShoot(InputAction.CallbackContext context)
//    {
//        if (context.phase == InputActionPhase.Performed)
//        {
//            LeftClick.Invoke();
//        }
//    }
//    public void OnShootRelease(InputAction.CallbackContext context)
//    {
//        if (context.phase == InputActionPhase.Performed)
//        {
//            LeftReleaseEvent.Invoke();
//        }
//    }

//    public void OnDrag(InputAction.CallbackContext context)
//    {
//        if (context.phase == InputActionPhase.Performed)
//        {
//            RightClick.Invoke();
//        }
//    }

//    public void OnDragRelease(InputAction.CallbackContext context)
//    {
//        if (context.phase == InputActionPhase.Performed)
//        {
//            RightReleaseEvent.Invoke();
//        }
//    }

//    public void OnLeftClick(InputAction.CallbackContext context)
//    {
//        if (context.phase == InputActionPhase.Performed)
//        {
//            Press.Invoke();
//        }
//    }
//}






//Movement Script *********************************************************************************************

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;
//public class Movement : MonoBehaviour
//{

//    public Rigidbody2D rb;
//    public InputReader reader;

//    [SerializeField]
//    private float distance;
//    public float moveSpeed = 5;
//    private Vector2 dir = Vector2.zero;
//    private Vector2 lastDirection = Vector2.zero;

//    [SerializeField]
//    private float jumpForce;
//    [SerializeField]
//    private float playerToGroundDistance;

//    [SerializeField]
//    private LayerMask dragable;
//    [SerializeField]
//    public LayerMask interactableMask;
//    public LayerMask groundLayer;


//    private List<Interactable> interactables;
//    public GameObject BoxBeingDragged;

//    #region Enable & Disable
//    private void OnEnable()
//    {
//        reader.MoveEvent += Move;
//        reader.JumpEvent += Jump;
//        reader.RightClick += PushAndPull;
//        reader.InteractEvent += Interact;
//        reader.Press += LMBPress;


//    }

//    private void OnDisable()
//    {
//        reader.MoveEvent -= Move;
//        reader.JumpEvent -= Jump;
//        reader.RightClick -= PushAndPull;
//        reader.InteractEvent -= Interact;
//        reader.RightReleaseEvent -= Released;
//    }

//    #endregion

//    #region Unity Methods
//    public void Update()
//    {
//        dir.y = rb.velocity.y;
//        rb.velocity = dir;



//    }

//    public void OnDrawGizmos()
//    {
//        Gizmos.color = Color.green;
//        Gizmos.DrawRay(transform.position, lastDirection);
//    }

//    #endregion

//    #region Interact(E)
//    public void Interact()
//    {
//        RaycastHit2D hit = Physics2D.Raycast((Vector2)this.transform.position, lastDirection, .75f, interactableMask);

//        if (hit.collider != null)
//        {
//            Interactable i = hit.collider.gameObject.GetComponent<Interactable>();
//            if (i != null)
//            {
//                i.Event.Invoke(this);
//            }
//        }
//    }
//    #endregion

//    #region Movement(WASD)
//    public void Move(Vector2 direction)
//    {
//        dir.x = direction.x * moveSpeed;

//        if (direction != Vector2.zero)
//        {
//            lastDirection = direction;
//        }



//        if (direction != Vector2.zero)
//        {
//            //animator.SetFloat("Horizontal", direction.x);
//            //animator.SetFloat("Vertical", direction.y);
//        }

//        //animator.SetFloat("Speed", direction.sqrMagnitude);



//    }
//    #endregion

//    #region Jump(Spacebar)
//    public void Jump()
//    {
//        //Debug.Log("Jump");
//        if (IsGrounded())
//        {
//            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
//        }
//    }

//    public bool IsGrounded()
//    {
//        //Debug.Log("Jump2");

//        if (Physics2D.Raycast(this.transform.position, Vector2.down, playerToGroundDistance, groundLayer.value) || Physics2D.Raycast(this.transform.position, Vector2.down, playerToGroundDistance, dragable.value))
//        {
//            //Debug.Log("jump3");
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }

//    #endregion

//    #region Drag(RMB)
//    public void PushAndPull()
//    {
//        Physics2D.queriesStartInColliders = false;
//        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, distance, dragable);

//        if (hit.collider != null)
//        {
//            Debug.Log("get I get here?");
//            BoxBeingDragged = hit.collider.gameObject;

//            BoxBeingDragged.GetComponent<FixedJoint2D>().enabled = true;
//            BoxBeingDragged.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
//            reader.RightReleaseEvent += Released;

//        }
//    }

//    public void Released()
//    {
//        Debug.Log("Testing");
//        BoxBeingDragged.GetComponent<FixedJoint2D>().enabled = false;
//    }

//    #endregion

//    #region Continue(LMB)
//    public void LMBPress()
//    {
//        RaycastHit2D hit = Physics2D.Raycast((Vector2)this.transform.position, lastDirection, 1f, interactableMask);

//        if (hit.collider != null)
//        {
//            Interactable i = hit.collider.gameObject.GetComponent<Interactable>();
//            if (i != null)
//            {
//                i.Event.Invoke(this);
//            }
//        }
//    }
//    #endregion

//}



