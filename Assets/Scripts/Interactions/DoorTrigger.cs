using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    private bool open = false;

    public bool Open
    {
        get { return open; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        open = true;
    }
}
