using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField]
    private InputReader reader;
    private GameObject newShot;
    public GameObject shot;
    public float launchForce;
    public Transform shotPoint;

    public void FixedUpdate()
    {
        Vector2 SlingshotPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(reader.MousePosition);
        Vector2 direction = mousePosition - SlingshotPosition;

        transform.right = direction;
    }

    private void OnEnable()
    {
        reader.LeftClick += Aim;
        reader.leftReleaseEvent += Fire;
    }
    public void OnDisable()
    {
        reader.LeftClick -= Aim;
        reader.leftReleaseEvent -= Fire;
    }

    public void Aim()
    {
        newShot = Instantiate(shot, shotPoint.position, shotPoint.rotation);
        newShot.GetComponent<HingeJoint2D>().enabled = true;
    }

    public void Fire()
    {
        if (newShot != null)
        {
            newShot.GetComponent<HingeJoint2D>().enabled = false;
            newShot.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            newShot = null;
        }
        return;

    }

}
