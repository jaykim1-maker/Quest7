using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController

{
    public float moveSpeed = 5f;     // 현재 이동 속도
    private float originalSpeed;     // 원래 이동 속도 (복구용)
    private float debuffTimer = 0f;  // 디버프 지속 시간 타이머
    private Camera camera;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
        originalSpeed = moveSpeed;   // 시작 시 원래 속도 저장
    }
    protected override void Update()
    {
        base.Update();

        // 디버프 타이머가 남아있으면 시간 감소
        if (debuffTimer > 0f)
        {
            debuffTimer -= Time.deltaTime;
            if (debuffTimer <= 0f)
            {
                moveSpeed = originalSpeed; // 디버프 종료 시 원래 속도로 복구
            }
        }
    }
    public void ApplySlowDebuff(float duration, float slowAmount)
    {
        moveSpeed = originalSpeed * slowAmount; // 속도 감소 적용
        debuffTimer = duration;                  // 디버프 지속 시간 설정
    }
    //------------------------------------------------------------------------
    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(horizontal, vertical).normalized;

        if (Mathf.Abs(horizontal) > 0.01f)
        {
            //좌우 방향에 따라 lookDirection 값을 설정한다.
            //(1,0), (-1,0)
            lookDirection = new Vector2(horizontal, 0).normalized;
        }
    }

}
