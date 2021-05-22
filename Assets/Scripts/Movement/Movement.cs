using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public float moveSpeed = 5;
    [SerializeField]
    private float distance;
    public Rigidbody2D rb;
    //public Animator animator;
    public InputReader reader;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float playerToGroundDistance;
    private Vector2 dir = Vector2.zero;
    private Vector2 lastDirection = Vector2.zero;
    [SerializeField]
    private LayerMask layer;
    [SerializeField]
    private LayerMask dragable;
    public LayerMask groundLayer;

    public GameObject BoxBeingDragged;
    private void OnEnable()
    {
        reader.moveEvent += Move;
        reader.jumpEvent += Jump;
        reader.RightClick += PushAndPull;


    }
    private void OnDisable()
    {
        reader.moveEvent -= Move;
        reader.jumpEvent -= Jump;
        reader.RightClick -= PushAndPull;

        reader.releaseEvent -= Released;
    }

    public void Update()
    {
        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

    public void Move(Vector2 direction)
    {
        dir.x = direction.x * moveSpeed;

        if (direction != Vector2.zero)
        {
            lastDirection = direction;
        }



        if (direction != Vector2.zero)
        {
            //animator.SetFloat("Horizontal", direction.x);
            //animator.SetFloat("Vertical", direction.y);
        }

        //animator.SetFloat("Speed", direction.sqrMagnitude);



    }

    public void Jump()
    {
        Debug.Log("Jump");
        if (IsGrounded())
        {
            
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }



    public bool IsGrounded()
    {
        Debug.Log("Jump2");

        if (Physics2D.Raycast(this.transform.position, Vector2.down, playerToGroundDistance, groundLayer.value))
        {
            Debug.Log("jump3");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void PushAndPull()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, lastDirection, distance, dragable);

        if (hit.collider != null)
        {
            Debug.Log("get I get here?");
            BoxBeingDragged = hit.collider.gameObject;

            BoxBeingDragged.GetComponent<FixedJoint2D>().enabled = true;
            BoxBeingDragged.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            reader.releaseEvent += Released;

        }
    }
    public void Released()
    {
        Debug.Log("Testing");
        BoxBeingDragged.GetComponent<FixedJoint2D>().enabled = false;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position,lastDirection);
    }
}



