using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Movement : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody2D rb;
    //public Animator animator;
    public InputReader reader;

    private Vector2 direction = Vector2.zero;
    private Vector2 lastDirection = Vector2.zero;
    [SerializeField]
    private LayerMask layer;
    private void OnEnable()
    {
        reader.moveEvent += Move;
        reader.interactEvent += Interact;
    }

    private void Interact()
    {
        /*
        if (interactables.Count == 0) return;
        Interactable i = interactables.OrderBy(x => (x.transform.position - this.transform.position).magnitude).First();
        */
        RaycastHit2D hit = Physics2D.Raycast((Vector2)this.transform.position, lastDirection, .75f, layer);

        Debug.DrawRay((Vector2)this.transform.position, lastDirection);
        if (hit.collider != null)
        {
        }
    }

    private void OnDisable()
    {
        reader.moveEvent -= Move;
        reader.interactEvent -= Interact;
    }

    public void Update()
    {
        rb.velocity = direction;
    }

    public void Move(Vector2 direction)
    {
        this.direction = direction * moveSpeed;

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

    public void Jump(Vector2 direction)
    {


    }

}
