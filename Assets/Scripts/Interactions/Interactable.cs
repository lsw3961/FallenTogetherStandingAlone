using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Interactable : MonoBehaviour
{
    [SerializeField]
    public UnityCollisionEvent Event = new UnityCollisionEvent();

    public void DebugLog(Movement player)
    {
        Debug.Log("I have been hit, attach me to event to begin something.");
    }


}
[Serializable]
public class UnityCollisionEvent : UnityEvent<Movement>
{

}
