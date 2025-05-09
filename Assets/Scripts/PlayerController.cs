using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : BaseController
{
    // ���� ī�޶� ������ ����
    private Camera camera;

    // ���� ���� �� �����
    protected override void Start()
    {
        base.Start(); // BaseController�� Start ����
        camera = Camera.main; // ���� �ִ� ���� ī�޶� ��������
    }

    // �Է��� ó���ϴ� �Լ� (BaseController���� ȣ���)
    protected override void HandleAction()
    {
        // 1. Ű���� ����Ű (�Ǵ� WASD) �Է� �ޱ�
        float horizontal = Input.GetAxisRaw("Horizontal"); // �¿�
        float vertical = Input.GetAxisRaw("Vertical");     // ����

        // ���� ���� ����� ����ȭ(�ӵ� �����ϰ�)
        movementDirection = new Vector2(horizontal, vertical).normalized;

        // �ʹ� ������ ������ 0���� ó��
        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            // ���� ���͸� ����ȭ (���� 1�� �����)
            lookDirection = lookDirection.normalized;
        }
    }
}