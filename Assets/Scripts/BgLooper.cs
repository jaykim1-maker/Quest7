using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;
    public int mapCount = 0;
    public Vector3 mapLastPosition = Vector3.zero;

    private void Start()
    {
        GameObject[] map = GameObject.FindObjectsOfType<GameObject>();
        mapLastPosition = map[0].transform.position;
        mapCount = map.Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered" + collision.name);

        if (collision.CompareTag("Map"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

    }
}
