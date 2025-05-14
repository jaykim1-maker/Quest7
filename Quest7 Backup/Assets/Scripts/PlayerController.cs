using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        // 이동 처리
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        Debug.Log(rb.velocity.x);

        // 좌우 반전
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // 점프
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // 애니메이션 파라미터
        animator.SetBool("IsMove", Mathf.Abs(moveInput) > 0.01f);
        // animator.SetBool("IsJump", !isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }

    void LateUpdate()
    {
        // X 방향(flip 방향)은 그대로 두고, Y,Z만 1로 고정
        transform.localScale = new Vector3(transform.localScale.x, 1, 1);
    }


}
