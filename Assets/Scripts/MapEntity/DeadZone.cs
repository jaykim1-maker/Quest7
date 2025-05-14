using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    GameManager gameManager;
    public string playerTag = "Player"; // 플레이어 오브젝트에 붙은 태그

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
            // 플레이어에 닿았을 때 GameOver 호출
            GameManager.Instance.UpdateUI(); // UI 숨기고
            GameManager.Instance.uimanager.ShowGameOver(); // 게임오버 UI 보여주기
            Time.timeScale = 0f; // 게임 정지

        }

        if (collision.CompareTag(playerTag))
        {
            
        }
    }

}
