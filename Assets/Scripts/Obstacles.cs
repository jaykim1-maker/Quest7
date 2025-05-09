using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    GameManager gameManager;
    public bool isDead;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private bool DeadUpdate()
    {
        if (isDead) return true;
        else return false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Triggerd Player is Dead");

        if (collision.CompareTag("Player"))
        {
            isDead = true;
            return;
        }

        else return;
    }

    
}
