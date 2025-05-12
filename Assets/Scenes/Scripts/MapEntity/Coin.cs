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

            //GameManager.uimanager.AddScore();

            //Destroy(gameObject);

            Vector3 pos = this.transform.position;  //이 오브젝트의 위치지정

            pos.y += (mapLenth * mapCount);  //y좌표를 맵크기*맵갯수만큼 올리기
            this.transform.position = pos;  //적용

            //return
        }
    }
}
