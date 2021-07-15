using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDiesOnLayer : MonoBehaviour
{
    [SerializeField]
    private int lifeCounter = 3;
    [SerializeField]
    private Transform respawnPoint;
    [SerializeField]
    private Transform player;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (lifeCounter <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
                return;
            }
            lifeCounter--;
            player.transform.position = respawnPoint.transform.position;
            Physics2D.SyncTransforms();
        }
    }
}
