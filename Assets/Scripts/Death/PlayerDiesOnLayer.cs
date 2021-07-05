using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDiesOnLayer : MonoBehaviour
{
    [SerializeField]
    private LayerMask layer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(layer.value);
        Debug.Log(collision.gameObject.layer);
        if (collision.IsTouchingLayers(layer))
        {
            Debug.Log("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
        }
    }
}
