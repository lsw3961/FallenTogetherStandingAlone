using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<GameObject> triggers;

    [SerializeField]
    private float timeToMove = 0;
    [SerializeField]
    private Vector2 distanceToMove = Vector2.zero;
    private Vector2 finalLocation = Vector2.zero;
    private bool check;
    private bool finished = true;


    public void Awake()
    {
        finalLocation = (Vector2)transform.position + distanceToMove;
       // Debug.Log("Final Location is: " + finalLocation);
    }
    public void FixedUpdate()
    {
        if (finished)
        {
            for (int i = 0; i < triggers.Count; i++)
            {
                if (triggers[i].GetComponent<DoorTrigger>().Open == false)
                {
                    return;
                }
                else
                {
                    //Debug.Log("Check is true");
                    check = true;
                }
            }

            if (check)
            {
                Move();
            }
        }
    }

    public void Move()
    {
        if ((Vector2)transform.position != finalLocation)
        {
            transform.position = Vector3.Lerp(transform.position, finalLocation, timeToMove);
        }
        else { finished = false; }
        

    }

}
