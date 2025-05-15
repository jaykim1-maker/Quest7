using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float followSpeed = 0.1f;         // 시작 속도
    public float speedMultiplier = 1.02f;     // 몇 배로 증가할지
    public float maxSpeed = 1.0f;         // 최대 속도
    public float interval = 30f;              // 몇 초마다 증가할지

    private float timer = 0f;                // 시간 누적용

    void Update()
    {
        // 시간 누적
        timer += Time.deltaTime;

        // 5초마다 속도 증가
        if (timer >= interval)
        {
            followSpeed *= speedMultiplier;
            timer = 0f; // 타이머 초기화
        }

        // 현재 위치 가져오기
        Vector3 pos = transform.position;

        // 속도 적용
        pos.y += followSpeed * Time.deltaTime;

        // 위치 적용
        transform.position = pos;
    }
}
