using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choco : MonoBehaviour
{
    // ����� ���� �ð�(��)
    public float slowDuration = 3f;
    // �������� ���� ��)0.5f = 50% �ӵ�
    public float slowAmount = 0.3f;

    // �������� ���� ��
    private void OnTriggerEnter2D(Collider2D other)
    {

        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            // �÷��̾ �����
            player.ApplySlowDebuff(slowDuration, slowAmount);

            // ������(���ݸ�) ������Ʈ �ı�
            Destroy(gameObject);
        }
    }
}
