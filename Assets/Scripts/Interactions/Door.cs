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
    private float totalDistance = 0;
    private float startTime = 0;
    private bool check = false;
    private bool finished = true;


    public void Awake()
    {
        finalLocation = (Vector2)transform.position + distanceToMove;
        // Debug.Log("Final Location is: " + finalLocation);
        totalDistance =  Vector3.Distance(transform.position, finalLocation);
    }
    public void FixedUpdate()
    {
        if (finished)
        {

            if (check)
            {
                Move();
            }
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
                    startTime = Time.time;
                }
            }

        }
    }

    public void Move()
    {
        float distCovered = (Time.time - startTime) * timeToMove;
        float fractionOfJourney = distCovered / totalDistance;

        if ((Vector2)transform.position != finalLocation)
        {
            transform.position = Vector3.Lerp(transform.position, finalLocation, fractionOfJourney);
            if (Vector3.Distance(transform.position,finalLocation)<.05)
            {
                transform.position = finalLocation;
            }
        }
        else { finished = false; }
        

    }

}
