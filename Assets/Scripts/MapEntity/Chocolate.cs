using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ݸ� ������: �÷��̾ ������ ���� �ð� ���� �������� ������� �ο��մϴ�.
public class Chocolate : MonoBehaviour
{
    // ����� ���� �ð�(��)
    public float slowDuration = 3f;
    // �������� ���� ��)0.5f = 50% �ӵ�
    public float slowAmount = 0.3f;

    // �������� ���� ��
    private void OnTriggerEnter2D(Collider2D other)
    {

        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            // �÷��̾ �����
            player.ApplySlowDebuff(slowDuration, slowAmount);

            // ������(���ݸ�) ������Ʈ �ı�
            Destroy(gameObject);

            //���� ���ݸ� ������Ʈ�� ����
        }
    }
}
