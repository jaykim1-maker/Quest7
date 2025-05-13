using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP : MonoBehaviour
{


// �������� ���� �ö󰡴� �ʿ��� ������ ��� �����ϴ� ��ũ��Ʈ�Դϴ�.
public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;      // ���� �������� �����ϼ���.
    public Transform playerTransform;      // �÷��̾��� ��ġ�� �����ϼ���.

    public float startPlatformWidth = 3f;  // ������ ���� �ʺ�
    public float minPlatformWidth = 1f;    // ������ �ּ� �ʺ�
    public float platformWidthDecrease = 0.05f; // ������ ������ ������ �پ��� ��

    public float platformGapY = 2.5f;      // ���� ������ ���� ����
    public float platformXRange = 4f;      // ������ x ��ġ ���� ����

    private float nextPlatformY = 0f;      // ���� ������ ������ y��ǥ
    private float currentPlatformWidth;    // ���� ���� �ʺ�

    void Start()
    {
        // ù ���� �ʺ� ���۰����� ����
        currentPlatformWidth = startPlatformWidth;

        // �� ó�� ���� ���� �� �̸� ���� (�÷��̾ �������� �ʰ�)
        for (int i = 0; i < 10; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // �÷��̾ ���� �ö� ������, ���ʿ� ������ ��� ����
        // (�÷��̾�� ���� ���� ���� ������ ������ ���� ����)
        while (nextPlatformY < playerTransform.position.y + 10f)
        {
            SpawnPlatform();
        }
    }

    // ������ �����ϴ� �Լ�
    void SpawnPlatform()
    {
        // ������ x ��ġ�� �������� ���մϴ�.
        float x = Random.Range(-platformXRange, platformXRange);

        // ���� ����
        GameObject platform = Instantiate(platformPrefab, new Vector3(x, nextPlatformY, 0), Quaternion.identity);

        // ������ ũ�⸦ �����մϴ�.
        platform.transform.localScale = new Vector3(currentPlatformWidth, 0.5f, 1f);

        // ���� ������ ������ y��ǥ�� ����մϴ�.
        nextPlatformY += platformGapY;

        // ������ �ʺ� ���Դϴ�. �ּҰ� ���Ϸδ� �� �������� �մϴ�.
        currentPlatformWidth -= platformWidthDecrease;
        if (currentPlatformWidth < minPlatformWidth)
        {
            currentPlatformWidth = minPlatformWidth;
        }
    }
}

}
