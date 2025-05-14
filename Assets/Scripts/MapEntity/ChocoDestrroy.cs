using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 카메라가 이미 지나간(y값 이하) 자리에는 초코가 절대 다시 생성되지 않게 하는 스크립트
/// </summary>
public class ChocoDestrroy : MonoBehaviour
{
    // 생성할 초코 프리팹 (Inspector에서 연결)
    public GameObject chocoPrefab;

    // 초코가 생성될 수 있는 x, y 범위
    public float minX = -8f, maxX = 8f, minY = -10f, maxY = 120f;

    // 초코 오브젝트의 반지름 (겹침 방지용)
    public float chocoRadius = 0.5f;

    // 겹치면 안 되는 레이어 마스크 (초코끼리 겹침 방지)
    public LayerMask overlapMask;

    // 기본 초코 개수, 난이도 증가율
    public int baseChocoCount = 1;
    public int chocoIncreaseRate = 1;

    // 플레이어가 일정 높이만큼 올라갈 때마다 초코 생성
    public float spawnIntervalY = 200f;

    // 이 y값보다 아래로 내려가면 초코 파괴
    public float destroyBelowY = -10f;

    // 마지막으로 초코를 생성한 y값
    private float lastSpawnY = 0f;

    // 생성된 초코 오브젝트들을 저장하는 리스트
    private List<GameObject> spawnedChocos = new List<GameObject>();

    // 카메라가 올라간 최고 y값 (카메라가 이미 지나간 곳 체크용)
    private float maxCameraY = float.MinValue;

    void Update()
    {
        // 메인 카메라를 가져옴 (반드시 "MainCamera" 태그가 붙어 있어야 함)
        Camera cam = Camera.main;
        if (cam == null) return;

        // 카메라가 올라간 최고 y값을 계속 갱신
        if (cam.transform.position.y > maxCameraY)
            maxCameraY = cam.transform.position.y;

        // 플레이어 오브젝트를 태그로 찾음
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        float playerY = player.transform.position.y;

        // 플레이어가 일정 높이만큼 올라갈 때마다 초코 생성
        while (playerY - lastSpawnY > spawnIntervalY)
        {
            lastSpawnY += spawnIntervalY;
            // 초코 개수는 올라간 높이에 따라 증가
            int chocoCount = baseChocoCount + (int)(lastSpawnY / spawnIntervalY) * chocoIncreaseRate;
            SpawnChocos(chocoCount);
        }

        // 아래로 내려간 초코 파괴
        for (int i = spawnedChocos.Count - 1; i >= 0; i--)
        {
            GameObject choco = spawnedChocos[i];
            if (choco == null)
            {
                spawnedChocos.RemoveAt(i);
                continue;
            }
            // destroyBelowY보다 아래로 내려가면 파괴
            if (choco.transform.position.y < destroyBelowY)
            {
                Destroy(choco);
                spawnedChocos.RemoveAt(i);
            }
        }
    }

    // 초코 여러 개를 생성하는 함수
    void SpawnChocos(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 spawnPos = GetNonOverlappingPoint();
            GameObject choco = Instantiate(chocoPrefab, spawnPos, Quaternion.identity);
            spawnedChocos.Add(choco);
        }
    }

    // 겹치지 않고, 카메라가 이미 지나간(y <= maxCameraY) 곳에서는 생성하지 않음
    Vector2 GetNonOverlappingPoint()
    {
        int maxAttempts = 30; // 30번까지 시도
        Camera cam = Camera.main;
        if (cam == null) return Vector2.zero;

        for (int i = 0; i < maxAttempts; i++)
        {
            float x = Random.Range(minX, maxX);
            // 반드시 카메라가 올라간 곳보다 위쪽(y > maxCameraY)에서만 생성
            float y = Random.Range(maxCameraY + 1f, maxY);

            Vector2 pos = new Vector2(x, y);

            // Physics2D.OverlapCircle로 겹치는 오브젝트가 있는지 체크
            Collider2D hit = Physics2D.OverlapCircle(pos, chocoRadius, overlapMask);
            if (hit == null)
            {
                // 겹치지 않으면 이 위치에 생성
                return pos;
            }
        }
        // 30번 시도해도 못 찾으면 그냥 위쪽 아무 곳에 생성
        return new Vector2(Random.Range(minX, maxX), Mathf.Max(maxCameraY + 1f, maxY));
    }
}
