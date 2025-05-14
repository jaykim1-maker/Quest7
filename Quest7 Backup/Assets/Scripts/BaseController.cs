using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;

    [SerializeField] private SpriteRenderer characterRenderer;


    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0.0f;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    protected virtual void FixedUpdate()
    {
        Movment(movementDirection);
        if (knockbackDuration > 0.0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    protected virtual void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Debug.Log("horizontal: " + horizontal);

    }

    private void Movment(Vector2 direction)
    {
        direction = direction * 8;
        Debug.Log($"[이동] 방향: {direction}, 넉백 남은 시간: {knockbackDuration}");

        if (knockbackDuration > 0.0f)
        {
            direction *= 0.2f;
            direction += knockback;
        }

        _rigidbody.velocity = direction;
    }


    private void Rotate(Vector2 direction)
    {
        if (characterRenderer == null) return;

        // x 방향이 오른쪽(+)이면 false, 왼쪽(-)이면 true
        if (direction.x > 0.01f)
            characterRenderer.flipX = false;
        else if (direction.x < -0.01f)
            characterRenderer.flipX = true;
    }


    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        knockback = -(other.position - transform.position).normalized * power;
    }


}

