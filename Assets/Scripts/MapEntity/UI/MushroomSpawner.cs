using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSpawner : MonoBehaviour
{
    public GameObject mushroomPrefab;   // ������ ���� ������
    public Transform player;            // �÷��̾� Transform
    public float minX = -8f, maxX = 8f; // ���� ���� X����
    public float spawnGapY = 5f;        // ���� ���� ����(����)
    public float baseMushroomsPerLevel = 2f; // �⺻ ���� ��
    public float mushroomsIncreasePer100Y = 1f; // 100 �ö� ������ �߰� ���� ��

    private float nextSpawnY = 0f;

    void Start()
    {
        nextSpawnY = player.position.y + spawnGapY;
    }

    void Update()
    {
        // �÷��̾ ���� ���� �̻� �ö󰡸� ���� ����
        while (player.position.y > nextSpawnY - spawnGapY)
        {
            int mushroomCount = CalculateMushroomCount(nextSpawnY);
            SpawnMushroomsAtHeight(nextSpawnY, mushroomCount);
            nextSpawnY += spawnGapY;
        }
    }

    int CalculateMushroomCount(float y)
    {
        // ��: 100�� �ö� ������ ���� �� ����
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
