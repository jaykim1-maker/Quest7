using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

using UnityEngine;

public class BaseController : MonoBehaviour
{
    // ĳ���Ϳ� ���� Rigidbody2D (���� �̵���)
    protected Rigidbody2D rigidbody;

    // ĳ������ ���(��������Ʈ)�� ���� ȸ����
    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;

    // �̵� ����
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    // �ٶ󺸴� ����
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection { get { return lookDirection; } }

    // �˹� ����� ���� �ð�
    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0f;

    // ���� ���� ���� ����Ǵ� �Լ� (Rigidbody ��������)
    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // ������ ���۵Ǹ� ����� (�ڽ� Ŭ�������� ��� ����)
    protected virtual void Start()
    {
    }

    // �� �����Ӹ��� ����� (�Է� ó�� ��)
    protected virtual void Update()
    {
        HandleAction();                 // Ű �Է� �� ó��
        Rotate(LookDirection);         // �ٶ󺸴� ���⿡ ���� ĳ���� ȸ��asda
    }

    // ������ �ð����� ����� (���� ���꿡 ����)
    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);   // ���� ���� �̵�

        // �˹� ���� �ð� ���ҽ�Ű��
        if (knockbackDuration > 0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    // �ڽ� Ŭ�������� �������̵� �� �� �ִ� �ൿ ó�� �Լ�
    protected virtual void HandleAction()
    {
    }

    // �̵� ó�� �Լ�
    private void Movement(Vector2 direction)
    {
        // ���� ���Ϳ� �ӵ��� ���ϱ�
        direction *= 5f;

        // �˹� ���̸�, �̵� ������ ���̰� �˹� ���� ����
        if (knockbackDuration > 0f)
        {
            direction *= 0.2f;         // �̵� ���̱�
            direction += knockback;   // �˹� �߰�
        }

        // ���� ���� �̵�
        rigidbody.velocity = direction;
    }

    // ĳ���Ͱ� �ٶ󺸴� ���⿡ ���� ȸ����Ŵ
    private void Rotate(Vector2 direction)
    {
        // ���� ���� �� ������ ��ȯ (���� �� ��)
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ������ ������ �Ǵ�
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        // ĳ���� ��������Ʈ ����
        characterRenderer.flipX = isLeft;

    }

    // �˹�(�з����� ��)�� �����ϴ� �Լ�
    public void ApplyKnockback(Transform other, float power, float duration)
    {
        // �˹� ���� �ð� ����
        knockbackDuration = duration;

        // ���� ��� ���� ���� ��� �� ���� ����
        float knockbackPower = Mathf.Clamp(power, 0f, 5f); // �ִ� ���� ����
        knockback = (transform.position - other.position).normalized * knockbackPower;
    }
}