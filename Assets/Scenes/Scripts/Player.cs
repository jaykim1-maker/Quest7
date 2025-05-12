using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flapForce = 8f;
    public float forwardSpeed = 4f;
    public bool isDead = false;
    float deathCooldown = 0f;

    bool isFlap = false;

    public bool godMode = false;
    public float moveSpeed = 3f;

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
    }

    void Update()
    {
        if (isDead) return;

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
}
