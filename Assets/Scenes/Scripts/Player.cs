using UnityEngine;
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
        animator = GetComponentInChildren<Animator>();
        _rigidbody = transform.GetComponent<Rigidbody2D>();

        if (animator == null) Debug.LogError("Animator가 없음");
        if (_rigidbody == null) Debug.LogError("Rigidbody2D가 없음");

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody");
        }
    }

    void Update()
    {
        if (isDead) return;

        // 걷기 입력 감지
        float moveX = Input.GetAxisRaw("Horizontal");
        _rigidbody.velocity = new Vector2(moveX * moveSpeed, _rigidbody.velocity.y);

        if (moveX != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * (moveX > 0 ? 1 : -1);
            transform.localScale = scale;
        }


        if (animator != null)
            animator.SetBool("IsRun", moveX != 0);



        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Flap키 입력됨");
            isFlap = true;
        }



    }

    public void FixedUpdate()
    {
        if (isDead)
            return;


        if (isFlap)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, flapForce);
            isFlap = false;
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
            return;

        if (isDead)
            return;

        animator.SetInteger("IsDie", 1);
        isDead = true;
        deathCooldown = 1f;
    }


}