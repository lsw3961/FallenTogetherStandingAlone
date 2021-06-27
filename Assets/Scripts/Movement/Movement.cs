using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    [Header("Basics")]
    [Tooltip("These are the basic varaibles that are needed for movement")]
    public Rigidbody2D rb = null;
    public InputReader reader = null;
    [SerializeField]
    private float jumpForce = 1;
    [SerializeField]
    private float moveSpeed = 5;
    private float airSpeed = 0;
    private float groundSpeed = 0;
    [Header("Offsets")]
    [Tooltip("These are offsets for different functions")]
    [SerializeField]
    private float grabBoxDistance = 0;
    [SerializeField]
    private Vector3 offsetForGrabBox = Vector3.zero;
    [SerializeField]
    private float heightToHead = 0;
    [SerializeField]
    private float playerToGroundDistance = 0;


    [Header("Layer Masks")]
    [Tooltip("Layer Masks for ")]
    [SerializeField]
    private LayerMask dragable = 0;
    [SerializeField]
    private LayerMask interactableMask = 0;
    [SerializeField]
    private LayerMask groundLayer = 0;


    [Header("External")]
    [Tooltip("External Objects")]
    public GameObject BoxBeingDragged;


    private Vector2 dir = Vector2.zero;
    private Vector2 lastDirection = Vector2.zero;
    private Animator animator;
    private List<Interactable> interactables;



    #region Enable & Disable
    private void OnEnable()
    {
        groundSpeed = moveSpeed;
        animator = GetComponent<Animator>();
        airSpeed = moveSpeed / 2;
        reader.MoveEvent += Move;
        reader.JumpEvent += Jump;
        reader.RightClick += PushAndPull;
        reader.InteractEvent += Interact;
        reader.Press += LMBPress;


    }

    private void OnDisable()
    {
        reader.MoveEvent -= Move;
        reader.JumpEvent -= Jump;
        reader.RightClick -= PushAndPull;
        reader.InteractEvent -= Interact;
        reader.RightReleaseEvent -= Released;
    }

    #endregion

    #region Unity Methods
    public void Update()
    {
        dir.y = rb.velocity.y;
        rb.velocity = dir;

        if (IsGrounded())
        {
            moveSpeed = groundSpeed;
        }
        else
        {
            moveSpeed = airSpeed;
        }



    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position+offsetForGrabBox, lastDirection);
        Gizmos.DrawRay(this.transform.position, Vector2.down);
    }

    #endregion

    #region Interact(E)
    public void Interact()
    {
        Debug.Log("Interact1");
        RaycastHit2D hit = Physics2D.Raycast((Vector2)this.transform.position+(Vector2)offsetForGrabBox, lastDirection, .75f, interactableMask);

        if (hit.collider != null)
        {
            Debug.Log("Interact2");

            Interactable i = hit.collider.gameObject.GetComponent<Interactable>();
            if (i != null)
            {
                i.Event.Invoke(this);
            }
        }
    }
    #endregion

    #region Movement(WASD)
    public void Move(Vector2 direction)
    {
        dir.x = direction.x * moveSpeed;
        if (direction != Vector2.zero)
        {
            lastDirection = direction;

        }
        if (dir.x == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (direction.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }


    }
    #endregion

    #region Jump(Spacebar)
    public void Jump()
    {
        if (IsGrounded())
        {
            animator.SetTrigger("takeOff");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public bool IsGrounded()
    {
        if (Physics2D.Raycast(this.transform.position, Vector2.down, playerToGroundDistance,groundLayer.value)|| Physics2D.Raycast(this.transform.position, Vector2.down, playerToGroundDistance, dragable.value))
        {
            animator.SetBool("isJumping", false);
            return true;
        }
        else
        {
            animator.SetBool("isJumping", true);
            return false;
        }
    }

    #endregion

    #region Drag(RMB)
    public void PushAndPull()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position+offsetForGrabBox, lastDirection, grabBoxDistance, dragable);

        if (hit.collider != null)
        {
            //Debug.Log("get I get here?");
            BoxBeingDragged = hit.collider.gameObject;
            Vector3 temp = this.transform.position;
            temp.y = temp.y + heightToHead;
            BoxBeingDragged.transform.position = temp;
            BoxBeingDragged.GetComponent<FixedJoint2D>().enabled = true;
            BoxBeingDragged.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            reader.RightReleaseEvent += Released;
            jumpForce *= 2;
        }
    }

    public void Released()
    {
        //Debug.Log("Testing");
        if (BoxBeingDragged != null)
        {
            jumpForce /= 2;
            BoxBeingDragged.GetComponent<FixedJoint2D>().enabled = false;
            BoxBeingDragged = null;
        }

    }

    #endregion

    #region Continue(LMB)
    public void LMBPress()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)this.transform.position+(Vector2)offsetForGrabBox, lastDirection, 1f, interactableMask);
        Debug.Log("continie");
        if (hit.collider != null)
        {
            Interactable i = hit.collider.gameObject.GetComponent<Interactable>();
            if (i != null)
            {
                i.Event.Invoke(this);
            }
        }
    }
    #endregion

}



