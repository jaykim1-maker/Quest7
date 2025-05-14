using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choco : MonoBehaviour
{
    public GameObject spring;
    public float minX, maxX;
    // 디버프 지속 시간(초)
    public float slowDuration = 3f;
    // 느려지는 비율 예)0.5f = 50% 속도
    public float slowAmount = 0.3f;

    private void Start()
    {
        minX = -10; maxX = 10;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                //플레이어에게 디버프
                player.ApplySlowDebuff(slowDuration, slowAmount);
            }
            Debug.Log("Choco On Trigger " + other.name);
            //아이템을 먹으면 해당 아이템 위치에서 랜덤으로 다음맵에 스폰
            Vector2 randomplace = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(this.transform.position.y + 34, this.transform.position.y + 68)
            );
            this.transform.position = randomplace;
        }
        else if (other.CompareTag("Looper")) //루퍼에 닿으면 랜덤 위치로 스폰
        {
            Debug.Log("Choco On Trigger " + other.name);
            Vector2 randomplace = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(this.transform.position.y + 68, this.transform.position.y + 102)
            );
            this.transform.position = randomplace;
        }
    }
}
