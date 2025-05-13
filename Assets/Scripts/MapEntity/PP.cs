using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP : MonoBehaviour
{


// 무한으로 위로 올라가는 맵에서 발판을 계속 생성하는 스크립트입니다.
public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;      // 발판 프리팹을 연결하세요.
    public Transform playerTransform;      // 플레이어의 위치를 연결하세요.

    public float startPlatformWidth = 3f;  // 발판의 시작 너비
    public float minPlatformWidth = 1f;    // 발판의 최소 너비
    public float platformWidthDecrease = 0.05f; // 발판이 생성될 때마다 줄어드는 양

    public float platformGapY = 2.5f;      // 발판 사이의 높이 간격
    public float platformXRange = 4f;      // 발판의 x 위치 랜덤 범위

    private float nextPlatformY = 0f;      // 다음 발판이 생성될 y좌표
    private float currentPlatformWidth;    // 현재 발판 너비

    void Start()
    {
        // 첫 발판 너비를 시작값으로 설정
        currentPlatformWidth = startPlatformWidth;

        // 맨 처음 발판 여러 개 미리 생성 (플레이어가 떨어지지 않게)
        for (int i = 0; i < 10; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // 플레이어가 위로 올라갈 때마다, 위쪽에 발판을 계속 생성
        // (플레이어보다 일정 높이 위에 발판이 없으면 새로 생성)
        while (nextPlatformY < playerTransform.position.y + 10f)
        {
            SpawnPlatform();
        }
    }

    // 발판을 생성하는 함수
    void SpawnPlatform()
    {
        // 발판의 x 위치를 랜덤으로 정합니다.
        float x = Random.Range(-platformXRange, platformXRange);

        // 발판 생성
        GameObject platform = Instantiate(platformPrefab, new Vector3(x, nextPlatformY, 0), Quaternion.identity);

        // 발판의 크기를 조정합니다.
        platform.transform.localScale = new Vector3(currentPlatformWidth, 0.5f, 1f);

        // 다음 발판이 생성될 y좌표를 계산합니다.
        nextPlatformY += platformGapY;

        // 발판의 너비를 줄입니다. 최소값 이하로는 안 내려가게 합니다.
        currentPlatformWidth -= platformWidthDecrease;
        if (currentPlatformWidth < minPlatformWidth)
        {
            currentPlatformWidth = minPlatformWidth;
        }
    }
}

}
