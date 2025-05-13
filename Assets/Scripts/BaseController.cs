using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

using UnityEngine;

public class BaseController : MonoBehaviour
{
    // 캐릭터에 붙은 Rigidbody2D (물리 이동용)
    protected Rigidbody2D rigidbody;

    // 캐릭터의 모습(스프라이트)와 무기 회전축
    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;

    // 이동 방향
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    // 바라보는 방향
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    // 넉백 방향과 지속 시간
    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0f;

    // 게임 시작 전에 실행되는 함수 (Rigidbody 가져오기)
    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // 게임이 시작되면 실행됨 (자식 클래스에서 사용 가능)
    protected virtual void Start()
    {
    }

    // 매 프레임마다 실행됨 (입력 처리 등)
    protected virtual void Update()
    {
        HandleAction();                 // 키 입력 등 처리
        Rotate(LookDirection);         // 바라보는 방향에 따라 캐릭터 회전asda
    }

    // 고정된 시간마다 실행됨 (물리 연산에 적합)
    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);   // 실제 물리 이동

        // 넉백 지속 시간 감소시키기
        if (knockbackDuration > 0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    // 자식 클래스에서 오버라이드 할 수 있는 행동 처리 함수
    protected virtual void HandleAction()
    {
    }

    // 이동 처리 함수
    private void Movement(Vector2 direction)
    {
        // 방향 벡터에 속도값 곱하기
        direction *= 5f;

        // 넉백 중이면, 이동 방향을 줄이고 넉백 방향 더함
        if (knockbackDuration > 0f)
        {
            direction *= 0.2f;         // 이동 줄이기
            direction += knockback;   // 넉백 추가
        }

        // 실제 물리 이동
        rigidbody.velocity = direction;
    }

    // 캐릭터가 바라보는 방향에 따라 회전시킴
    private void Rotate(Vector2 direction)
    {
        // 방향 벡터 → 각도로 변환 (라디안 → 도)
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 왼쪽을 보는지 판단
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        // 캐릭터 스프라이트 반전
        characterRenderer.flipX = isLeft;

    }

    // 넉백(밀려나는 힘)을 적용하는 함수
    public void ApplyKnockback(Transform other, float power, float duration)
    {
        // 넉백 지속 시간 설정
        knockbackDuration = duration;

        // 나와 상대 사이 방향 계산 후 힘을 곱함
        float knockbackPower = Mathf.Clamp(power, 0f, 5f); // 최대 세기 제한
        knockback = (transform.position - other.position).normalized * knockbackPower;
    }
}