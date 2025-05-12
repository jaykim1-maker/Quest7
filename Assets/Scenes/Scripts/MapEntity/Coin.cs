using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Coin : MonoBehaviour
{
    GameManager gameManager;

    
    private void Start()
    {
        gameObject.GetComponentInChildren<Collider2D>();
        
        gameManager = GameManager.Instance;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Add Score");

            //GameManager.uimanager.AddScore();

            //Destroy(gameObject);

            Vector3 pos = this.transform.position;

            pos.y += 68f;
            this.transform.position = pos;

            //return
        }
    }
}
