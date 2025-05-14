using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choco : MonoBehaviour
{
    public GameObject spring;
    public float minX, maxX;
    // ����� ���� �ð�(��)
    public float slowDuration = 3f;
    // �������� ���� ��)0.5f = 50% �ӵ�
    public float slowAmount = 0.3f;

    private void Start()
    {
        minX = -10; maxX = 10;
    }

    // �������� ���� ��
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            // �÷��̾ �����
            player.ApplySlowDebuff(slowDuration, slowAmount);

            // ������(���ݸ�) ������Ʈ �ı�
            //Destroy(gameObject);
            Debug.Log("Choco On Trigger " + other.name);
            Vector2 randomplace = new Vector2
                (Random.Range(minX, maxX), Random.Range(this.transform.position.y + 34, this.transform.position.y + 68));
            this.transform.position = randomplace;
        }

        if (other.CompareTag("Looper") || other.CompareTag("Player"))
        {
            Debug.Log("Choco On Trigger "+ other.name);
            Vector2 randomplace = new Vector2
                (Random.Range(minX, maxX), Random.Range(this.transform.position.y + 34, this.transform.position.y + 68));
            this.transform.position = randomplace;
        }
    }
}
