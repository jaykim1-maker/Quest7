using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 초콜릿 아이템: 플레이어가 먹으면 일정 시간 동안 느려지는 디버프를 부여합니다.
public class Chocolate : MonoBehaviour
{
    // 디버프 지속 시간(초)
    public float slowDuration = 3f;
    // 느려지는 비율 예)0.5f = 50% 속도
    public float slowAmount = 0.3f;

    // 아이템을 먹을 때
    private void OnTriggerEnter2D(Collider2D other)
    {

        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            // 플레이어에 디버프
            player.ApplySlowDebuff(slowDuration, slowAmount);

            // 아이템(초콜릿) 오브젝트 파괴
            Destroy(gameObject);

            //아직 초콜릿 오브젝트가 없음
        }
    }
}
