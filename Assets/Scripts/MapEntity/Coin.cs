using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Coin : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Add Score");

            Destroy(gameObject);
        }
        
    }
}
