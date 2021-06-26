using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public InputReader reader;

    [SerializeField]
    private float distance;
    public float moveSpeed = 5;
    [SerializeField]
    private float yOffset;
    private Vector2 dir = Vector2.zero;
    private Vector2 lastDirection = Vector2.zero;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float playerToGroundDistance;

    [SerializeField]
    private LayerMask dragable;
    [SerializeField]
    public LayerMask interactableMask;
    public LayerMask groundLayer;

    private Animator animator;
    private List<Interactable> interactables;
    public GameObject BoxBeingDragged;

    #region Enable & Disable
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        reader.MoveEvent += Move;
        reader.JumpEvent += Jump;
        reader.RightClick += PushAndPull;
        reader.InteractEvent += Interact;
        //reader.Press += LMBPress;


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



    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, lastDirection);
    }

    #endregion

    #region Interact(E)
    public void Interact()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)this.transform.position, lastDirection, .75f, interactableMask);

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

    #region Movement(WASD)
    public void Move(Vector2 direction)
    {
        dir.x = direction.x * moveSpeed;

        if (direction != Vector2.zero)
        {
            lastDirection = direction;
            animator.SetFloat("Horizontal", direction.x);

        }
        animator.SetFloat("Speed", direction.sqrMagnitude);




    }
    #endregion

    #region Jump(Spacebar)
    public void Jump()
    {
        //Debug.Log("Jump");
        if (IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public bool IsGrounded()
    {
        //Debug.Log("Jump2");

        if (Physics2D.Raycast(this.transform.position, Vector2.down, playerToGroundDistance, groundLayer.value)|| Physics2D.Raycast(this.transform.position, Vector2.down, playerToGroundDistance, dragable.value))
        {
            //Debug.Log("jump3");
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

    #region Drag(RMB)
    public void PushAndPull()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, distance, dragable);

        if (hit.collider != null)
        {
            Debug.Log("get I get here?");
            BoxBeingDragged = hit.collider.gameObject;
            Vector3 temp = this.transform.position;
            temp.y = temp.y + yOffset;
            BoxBeingDragged.transform.position = temp;
            BoxBeingDragged.GetComponent<FixedJoint2D>().enabled = true;
            BoxBeingDragged.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            reader.RightReleaseEvent += Released;

        }
    }

    public void Released()
    {
        Debug.Log("Testing");
        BoxBeingDragged.GetComponent<FixedJoint2D>().enabled = false;
    }

    #endregion

    #region Continue(LMB)
    public void LMBPress()
    {
        RaycastHit2D hit = Physics2D.Raycast((Vector2)this.transform.position, lastDirection, 1f, interactableMask);

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



