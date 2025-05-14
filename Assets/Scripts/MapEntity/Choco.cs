using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choco : MonoBehaviour
{
    public float minX = -10f, maxX = 10f;
    public float slowDuration = 3f;
    public float slowAmount = 0.3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(
            $"[4] �浹 �߻�! �̸�: {other.gameObject.name}, �±�: {other.gameObject.tag}, " +
            $"Ȱ��ȭ: {other.gameObject.activeSelf}, �ð�: {Time.time}"
        );

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.ApplySlowDebuff(slowDuration, slowAmount);
            }
            Debug.Log("Choco On Trigger " + other.name);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Looper"))
        {
            Debug.Log("Choco On Trigger " + other.name);
            Destroy(gameObject);
            Debug.Log("�ı�");
        }
    }
}