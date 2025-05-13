using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float followSpeed = 0.2f;         // 카메라가 따라가는 기본 속도
    public float speedMultiplier = 1.05f;    // 속도가 증가하는 비율
    public float maxSpeed = 1.0f;            // 최대 속도 (현재 코드에서는 사용되지 않음)
    public float interval = 5f;              // 속도가 증가하는 시간 간격(초)
    private float timer = 0f;                // 시간 누적용 변수
    private Vector3 initialPosition;         // 카메라의 시작 위치를 저장

    void Start()
    {
        // 카메라 위치와 스케일을 강제로 지정
        transform.position = new Vector3(0f, 0f, -10f);
        transform.localScale = new Vector3(1f, 1f, 1f);

        // 초기 위치 저장 (게임 오버 시 복구용)
        initialPosition = transform.position;
    }

    void Update()
    {
        // 매 프레임마다 시간 누적
        timer += Time.deltaTime;

        // interval(예: 5초)마다 속도를 증가시킴
        if (timer >= interval)
        {
            followSpeed *= speedMultiplier;  // 속도 증가
            timer = 0f;                      // 타이머 초기화
        }

        // 현재 위치를 가져와서 y축으로 이동
        Vector3 pos = transform.position;
        pos.y += followSpeed * Time.deltaTime;
        transform.position = pos;
    }


    /// 게임이 끝났을 때 호출: 카메라 위치, 스케일, 속도, 타이머를 모두 초기화
    public void ResetCameraOnGameOver()
    {
        transform.position = initialPosition;           // 위치 초기화
        transform.localScale = new Vector3(1f, 1f, 1f); // 스케일 초기화
        followSpeed = 0.2f;                             // 속도 초기화
        timer = 0f;                                     // 타이머 초기화
    }
}
