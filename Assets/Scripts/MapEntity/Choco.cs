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

    // 아이템을 먹을 때
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            // 플레이어에 디버프
            player.ApplySlowDebuff(slowDuration, slowAmount);

            // 아이템(초콜릿) 오브젝트 파괴
            //Destroy(gameObject);
            Debug.Log("Choco On Trigger " + other.name);
            Vector2 randomplace = new Vector2
                (Random.Range(minX, maxX), Random.Range(this.transform.position.y + 34, this.transform.position.y + 68));
            this.transform.position = randomplace;
        }

        if (other.CompareTag("Looper") || other.CompareTag("Player"))
        {
            Debug.Log("Choco On Trigger "+ other.name);
            Vector2 randomplace = new Vector2
                (Random.Range(minX, maxX), Random.Range(this.transform.position.y + 34, this.transform.position.y + 68));
            this.transform.position = randomplace;
        }
    }
}
