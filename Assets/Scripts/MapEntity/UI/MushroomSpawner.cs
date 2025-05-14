using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    public GameObject mushroomPrefab;   // 생성할 버섯 프리팹
    public Transform player;            // 플레이어 Transform
    public float minX = -8f, maxX = 8f; // 버섯 생성 X범위
    public float spawnGapY = 5f;        // 버섯 생성 간격(높이)
    public float baseMushroomsPerLevel = 2f; // 기본 버섯 수
    public float mushroomsIncreasePer100Y = 1f; // 100 올라갈 때마다 추가 버섯 수

    private float nextSpawnY = 0f;

    void Start()
    {
        nextSpawnY = player.position.y + spawnGapY;
    }

    void Update()
    {
        // 플레이어가 일정 높이 이상 올라가면 버섯 생성
        while (player.position.y > nextSpawnY - spawnGapY)
        {
            int mushroomCount = CalculateMushroomCount(nextSpawnY);
            SpawnMushroomsAtHeight(nextSpawnY, mushroomCount);
            nextSpawnY += spawnGapY;
        }
    }

    int CalculateMushroomCount(float y)
    {
        // 예: 100씩 올라갈 때마다 버섯 수 증가
        return Mathf.RoundToInt(baseMushroomsPerLevel + (y / 100f) * mushroomsIncreasePer100Y);
    }

    void SpawnMushroomsAtHeight(float y, int count)
    {
        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(minX, maxX);
            Vector2 spawnPos = new Vector2(x, y + Random.Range(-1f, 1f));
            Instantiate(mushroomPrefab, spawnPos, Quaternion.identity);
        }
    }
}
