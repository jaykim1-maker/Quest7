using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : BaseController
{
    // 메인 카메라를 저장할 변수
    private Camera camera;

    // 게임 시작 시 실행됨
    protected override void Start()
    {
        base.Start(); // BaseController의 Start 실행
        camera = Camera.main; // 씬에 있는 메인 카메라 가져오기
    }

    // 입력을 처리하는 함수 (BaseController에서 호출됨)
    protected override void HandleAction()
    {
        // 1. 키보드 방향키 (또는 WASD) 입력 받기
        float horizontal = Input.GetAxisRaw("Horizontal"); // 좌우
        float vertical = Input.GetAxisRaw("Vertical");     // 상하

        // 방향 벡터 만들고 정규화(속도 일정하게)
        movementDirection = new Vector2(horizontal, vertical).normalized;

        // 너무 가까우면 방향을 0으로 처리
        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            // 방향 벡터를 정규화 (길이 1로 만들기)
            lookDirection = lookDirection.normalized;
        }
    }
}