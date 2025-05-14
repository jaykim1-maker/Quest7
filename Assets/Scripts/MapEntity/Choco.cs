using System.Collections.Generic;
using UnityEngine;
public class Choco : MonoBehaviour
{
    public float minX = -8f, maxX = 8f;    // 재배치 시 x좌표 범위
    public float slowDuration = 3f;         // 디버프 지속 시간(초)
    public float slowAmount = 0.3f;         // 느려지는 비율

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 플레이어와 충돌 시
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.ApplySlowDebuff(slowDuration, slowAmount);
            }
            // 초코를 맵 위쪽의 랜덤 위치로 이동(재배치)
            Vector2 randomplace = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(transform.position.y + 34, transform.position.y + 68)
            );
            transform.position = randomplace;
        }
        // 루퍼와 충돌 시
        else if (other.CompareTag("Looper"))
        {
            Destroy(gameObject); // 초코 오브젝트 파괴
        }
    }
}
