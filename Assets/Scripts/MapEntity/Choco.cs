using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choco : MonoBehaviour
{
    // 디버프 지속 시간(초)
    public float slowDuration = 3f;
    // 느려지는 비율 예)0.5f = 50% 속도
    public float slowAmount = 0.3f;

    // 아이템을 먹을 때
    private void OnTriggerEnter2D(Collider2D other)
    {

        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            // 플레이어에 디버프
            player.ApplySlowDebuff(slowDuration, slowAmount);

            // 아이템(초콜릿) 오브젝트 파괴
            Destroy(gameObject);
        }
    }
}
