using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class Coin : MonoBehaviour
{
    GameManager gameManager;
    public float mapLenth = 34f;  //맵크기
    public int mapCount = 2;  //맵 갯수

    
    private void Start()
    {
        gameObject.GetComponentInChildren<Collider2D>();
        gameManager = GameManager.Instance;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))  //플레이어와 충돌시
        {
            Debug.Log("Add Score");
            Debug.Log("Add HP");
            //GameManager.uimanager.AddScore();
            //GameManager.player.HP += CoinHP;

            this.gameObject.SetActive(false);  //코인 오브젝트 액티브 종료
        }
    }
}
