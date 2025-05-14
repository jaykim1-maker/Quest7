using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ī�޶� �̹� ������(y�� ����) �ڸ����� ���ڰ� ���� �ٽ� �������� �ʰ� �ϴ� ��ũ��Ʈ
/// </summary>
public class ChocoDestrroy : MonoBehaviour
{
    // ������ ���� ������ (Inspector���� ����)
    public GameObject chocoPrefab;

    // ���ڰ� ������ �� �ִ� x, y ����
    public float minX = -8f, maxX = 8f, minY = -10f, maxY = 120f;

    // ���� ������Ʈ�� ������ (��ħ ������)
    public float chocoRadius = 0.5f;

    // ��ġ�� �� �Ǵ� ���̾� ����ũ (���ڳ��� ��ħ ����)
    public LayerMask overlapMask;

    // �⺻ ���� ����, ���̵� ������
    public int baseChocoCount = 1;
    public int chocoIncreaseRate = 1;

    // �÷��̾ ���� ���̸�ŭ �ö� ������ ���� ����
    public float spawnIntervalY = 200f;

    // �� y������ �Ʒ��� �������� ���� �ı�
    public float destroyBelowY = -10f;

    // ���������� ���ڸ� ������ y��
    private float lastSpawnY = 0f;

    // ������ ���� ������Ʈ���� �����ϴ� ����Ʈ
    private List<GameObject> spawnedChocos = new List<GameObject>();

    // ī�޶� �ö� �ְ� y�� (ī�޶� �̹� ������ �� üũ��)
    private float maxCameraY = float.MinValue;

    void Update()
    {
        // ���� ī�޶� ������ (�ݵ�� "MainCamera" �±װ� �پ� �־�� ��)
        Camera cam = Camera.main;
        if (cam == null) return;

        // ī�޶� �ö� �ְ� y���� ��� ����
        if (cam.transform.position.y > maxCameraY)
            maxCameraY = cam.transform.position.y;

        // �÷��̾� ������Ʈ�� �±׷� ã��
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        float playerY = player.transform.position.y;

        // �÷��̾ ���� ���̸�ŭ �ö� ������ ���� ����
        while (playerY - lastSpawnY > spawnIntervalY)
        {
            lastSpawnY += spawnIntervalY;
            // ���� ������ �ö� ���̿� ���� ����
            int chocoCount = baseChocoCount + (int)(lastSpawnY / spawnIntervalY) * chocoIncreaseRate;
            SpawnChocos(chocoCount);
        }

        // �Ʒ��� ������ ���� �ı�
        for (int i = spawnedChocos.Count - 1; i >= 0; i--)
        {
            GameObject choco = spawnedChocos[i];
            if (choco == null)
            {
                spawnedChocos.RemoveAt(i);
                continue;
            }
            // destroyBelowY���� �Ʒ��� �������� �ı�
            if (choco.transform.position.y < destroyBelowY)
            {
                Destroy(choco);
                spawnedChocos.RemoveAt(i);
            }
        }
    }

    // ���� ���� ���� �����ϴ� �Լ�
    void SpawnChocos(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 spawnPos = GetNonOverlappingPoint();
            GameObject choco = Instantiate(chocoPrefab, spawnPos, Quaternion.identity);
            spawnedChocos.Add(choco);
        }
    }

    // ��ġ�� �ʰ�, ī�޶� �̹� ������(y <= maxCameraY) �������� �������� ����
    Vector2 GetNonOverlappingPoint()
    {
        int maxAttempts = 30; // 30������ �õ�
        Camera cam = Camera.main;
        if (cam == null) return Vector2.zero;

        for (int i = 0; i < maxAttempts; i++)
        {
            float x = Random.Range(minX, maxX);
            // �ݵ�� ī�޶� �ö� ������ ����(y > maxCameraY)������ ����
            float y = Random.Range(maxCameraY + 1f, maxY);

            Vector2 pos = new Vector2(x, y);

            // Physics2D.OverlapCircle�� ��ġ�� ������Ʈ�� �ִ��� üũ
            Collider2D hit = Physics2D.OverlapCircle(pos, chocoRadius, overlapMask);
            if (hit == null)
            {
                // ��ġ�� ������ �� ��ġ�� ����
                return pos;
            }
        }
        // 30�� �õ��ص� �� ã���� �׳� ���� �ƹ� ���� ����
        return new Vector2(Random.Range(minX, maxX), Mathf.Max(maxCameraY + 1f, maxY));
    }
}
