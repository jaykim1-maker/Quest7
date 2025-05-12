using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Coin : MonoBehaviour
{
    GameManager gameManager;
    public float mapLenth = 34f;  //��ũ��
    public int mapCount = 2;  //�� ����

    
    private void Start()
    {
        gameObject.GetComponentInChildren<Collider2D>();
        
        gameManager = GameManager.Instance;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  //�÷��̾�� �浹��
        {
            Debug.Log("Add Score");

            //GameManager.uimanager.AddScore();

            //Destroy(gameObject);

            Vector3 pos = this.transform.position;  //�� ������Ʈ�� ��ġ����

            pos.y += (mapLenth * mapCount);  //y��ǥ�� ��ũ��*�ʰ�����ŭ �ø���
            this.transform.position = pos;  //����

            //return
        }
    }
}
