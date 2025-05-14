using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;
    public float flapForce = 8f; //점프 높이
    public float forwardSpeed = 4f; //이동속도
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;
    public float moveSpeed = 4f;         // 이동 속도
    private float originalSpeed;         // 디버프 복구
    private float debuffTimer = 3f;      // 남은 디버프 시간

    void Start()
    {
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }

        animator = transform.GetComponentInChildren<Animator>();
        if (animator == null)
        {
            Debug.LogError("Not Founded Animator");
        }

        originalSpeed = moveSpeed; // 시작 시 원래 속도 저장
    }
    public void ApplySlowDebuff(float duration, float slowAmount)
    {
        // duration: 디버프 지속 시간(초)
        // slowAmount: 느려지는 비율 (0.5f면 50%로 느려짐)
        moveSpeed = originalSpeed * slowAmount;
        debuffTimer = duration;
    }

    void Update()
    {
        if (isDead) return;

        // 디버프 타이머 관리
        if (debuffTimer > 0f)
        {
            debuffTimer -= Time.deltaTime;
            if (debuffTimer <= 0f)
            {
                moveSpeed = originalSpeed; // 디버프 끝나면 원래 속도로 복구
            }
        }

        // 걷기 입력
        float moveX = Input.GetAxisRaw("Horizontal");
        _rigidbody.velocity = new Vector2(moveX * moveSpeed, _rigidbody.velocity.y);

        // 점프 입력
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Flap키 입력됨");
            isFlap = true;
        }
    }

    public void FixedUpdate()
    {
        if (isDead) return;

        if (isFlap)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, flapForce);
            isFlap = false;
        }

        // 캐릭 방향 전환
        if (_rigidbody.velocity.x > 0.1f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (_rigidbody.velocity.x < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (isDead) return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;
    }
    //1
}

