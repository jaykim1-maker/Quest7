using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCoinOnAndOff : MonoBehaviour
{
    [SerializeField] private GameObject coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Looper"))
        { 
            for (int i = 0; i<coins.transform.childCount; i++)
            {
                coins.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
