using System.Collections.Generic;
using UnityEngine;
public class Choco : MonoBehaviour
{
    public float minX = -8f, maxX = 8f;    // ���ġ �� x��ǥ ����
    public float slowDuration = 3f;         // ����� ���� �ð�(��)
    public float slowAmount = 0.3f;         // �������� ����

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �÷��̾�� �浹 ��
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.ApplySlowDebuff(slowDuration, slowAmount);
            }
            // ���ڸ� �� ������ ���� ��ġ�� �̵�(���ġ)
            Vector2 randomplace = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(transform.position.y + 34, transform.position.y + 68)
            );
            transform.position = randomplace;
        }
        // ���ۿ� �浹 ��
        else if (other.CompareTag("Looper"))
        {
            Destroy(gameObject); // ���� ������Ʈ �ı�
        }
    }
}
