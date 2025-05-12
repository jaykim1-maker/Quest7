using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocolate : MonoBehaviour
{
    GameManager gameManager;
    float timer;
    int waitingTime;

    private void Start()
    {
        GetComponentInChildren<Chocolate>();
        gameManager = GameManager.Instance;

        timer = 0.0f;
        waitingTime = 2;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("GameManager.player.Speed = 1.5f");

            /*
            GameManager.player.Speed = 1.5f; 

            timer += Time.deltaTime;

            if(timer > waitingTime)
                timer = 0;

            GameManager.player.Speed = 3.0f;
            */

            Destroy(gameObject);
        }
    }
}
