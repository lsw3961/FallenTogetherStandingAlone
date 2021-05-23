using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D col;

    [SerializeField]
    private LayerMask mask;
    void FixedUpdate()
    {
        if (col.IsTouchingLayers(mask))
        {
            Destroy(this.gameObject);
        }
    }
}
