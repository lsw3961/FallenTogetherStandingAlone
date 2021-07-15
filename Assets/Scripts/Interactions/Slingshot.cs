using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    [SerializeField]
    private InputReader reader = null;
    public GameObject shot;
    public float launchForce;
    public Transform shotPoint;

    public Transform target;
    float lookAngle = 0;
    public void FixedUpdate()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(reader.MousePosition);
        Vector2 lookDir = mousePosition - (Vector2)shotPoint.position;
        lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        shotPoint.rotation = Quaternion.Euler(0, 0, lookAngle);
        //target.right = mousePosition;
    }

    private void OnEnable()
    {
        reader.LeftReleaseEvent += Fire;
    }
    public void OnDisable()
    {
        reader.LeftReleaseEvent -= Fire;
    }
    public void Fire()
    {
        GameObject newShot = Instantiate(shot, shotPoint.position, Quaternion.Euler(0, 0, lookAngle));
        newShot.GetComponent<Rigidbody2D>().velocity = shotPoint.right * launchForce;
    }

}
