using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEmission : MonoBehaviour
{
    public ParticleSystem poof;
    public void OnEnable()
    {
        poof.Play();
        Destroy(this.gameObject, poof.main.duration+poof.main.startLifetimeMultiplier);
    }
    public void FixedUpdate()
    {
    }
}
