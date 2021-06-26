using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D col = null;

    [SerializeField]
    private LayerMask mask = 0;
    void FixedUpdate()
    {
        if (col.IsTouchingLayers(mask))
        {
            Destroy(this.gameObject);
        }
    }
}
