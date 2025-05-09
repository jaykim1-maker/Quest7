using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float followSpeed = 0.02f;         // ���� �ӵ�
    public float speedMultiplier = 1.02f;     // �� ��� ��������
    public float interval = 5f;              // �� �ʸ��� ��������
    public float maxSpeed = 1.0f;
    private float timer = 0f;                // �ð� ������

    void Update()
    {
        // �ð� ����
        timer += Time.deltaTime;

        // 5�ʸ��� �ӵ� ����
        if (timer >= interval)
        {
            followSpeed *= speedMultiplier;
            timer = 0f; // Ÿ�̸� �ʱ�ȭ
        }

        // ���� ��ġ ��������
        Vector3 pos = transform.position;

        // �ӵ� ����
        pos.y += followSpeed * Time.deltaTime;

        // ��ġ ����
        transform.position = pos;
    }
}
