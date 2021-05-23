using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public List<GameObject> triggers;
    [SerializeField]
    private Vector2 distanceToMove;
    private Vector2 finalLocation;
    [SerializeField]
    private Vector2 distance;
    private bool check;
    private bool finished = true;
    [SerializeField] [Range(-1,1)]
    private float direction;
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
           // Debug.Log("Final Location has not been reached");
            if (direction <= 0)
            {
                //Debug.Log("Moving Negativly");
                Vector3 temp = transform.position;
                temp.x -= distance.x;
                transform.position = temp;
            }
            else
            {
                //Debug.Log("Moving Positivly");
                Vector3 temp = transform.position;
                temp.x += distance.x;
                transform.position = temp;
            }
        }
        else { finished = false; }
        

    }

}
