using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    GameManager gameManager;
    public string playerTag = "Player"; // �÷��̾� ������Ʈ�� ���� �±�

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player Dying was DeadZone");

            //GameManager.player.HP = 0;
            // �÷��̾ ����� �� GameOver ȣ��
            GameManager.Instance.UpdateUI(); // UI �����
            GameManager.Instance.uimanager.ShowGameOver(); // ���ӿ��� UI �����ֱ�
            Time.timeScale = 0f; // ���� ����

        }

        if (collision.CompareTag(playerTag))
        {
            
        }
    }

}
