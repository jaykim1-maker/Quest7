using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 2;
    public int mapCount = 0;
    public Vector3 mapLastPosition = Vector3.zero;
    public string playerTag = "Player"; // �÷��̾� ������Ʈ�� ���� �±�


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
            // �÷��̾ ����� �� GameOver ȣ��
            GameManager.Instance.UpdateUI(); // UI �����
            GameManager.Instance.uimanager.ShowGameOver(); // ���ӿ��� UI �����ֱ�
            Time.timeScale = 0f; // ���� ����
        }

    }
}
