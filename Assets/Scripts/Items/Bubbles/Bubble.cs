using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private Vector2 bounceForce;
    public GameObject poofSystem;
    [SerializeField] private Transform bubbleTransform;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(bounceForce,ForceMode2D.Impulse);
            Instantiate(poofSystem, transform.position, Quaternion.identity);
            Destroy(this.gameObject,.1f);
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {

    }
}
