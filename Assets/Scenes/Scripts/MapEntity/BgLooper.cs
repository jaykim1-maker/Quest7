using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 2;
    public int mapCount = 0;
    public Vector3 mapLastPosition = Vector3.zero;
    public string playerTag = "Player"; // 플레이어 오브젝트에 붙은 태그


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
            float widthOfBgObject = ((BoxCollider2D)collision).size.y;
            Vector3 pos = collision.transform.position;

            pos.y += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        if (collision.CompareTag(playerTag))
        {
            // 플레이어에 닿았을 때 GameOver 호출
            GameManager.Instance.UpdateUI(); // UI 숨기고
            GameManager.Instance.uimanager.ShowGameOver(); // 게임오버 UI 보여주기
            Time.timeScale = 0f; // 게임 정지
        }

    }
}
