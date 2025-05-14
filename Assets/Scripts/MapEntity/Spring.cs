using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    GameManager gameManager;

    public GameObject spring;
    public float minX, maxX;

    private void Start()
    {
        minX = -10; maxX = 10;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Looper"))
        {
            Vector2 randomplace = new Vector2
                (Random.Range(minX,maxX), Random.Range(this.transform.position.y + 34, this.transform.position.y + 68));
            this.transform.position = randomplace;
        }

        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(Vector2.up * 500f);
            }
        }
    }



}
