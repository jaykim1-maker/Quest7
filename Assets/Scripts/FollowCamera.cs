using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowCamera : MonoBehaviour
{
    // 따라갈 대상 (예: Player)
    public Transform target;

    // X, Y 방향으로 얼마나 떨어진 위치에서 따라갈지
    float offsetX;
    float offsetY;

    // 게임이 시작될 때 한 번 실행됨
    void Start()
    {
        // 따라갈 대상이 없으면 아무 것도 하지 않음
        if (target == null)
            return;

        // 처음 시작할 때 거리 차이를 기록해둠
        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    // 매 프레임마다 실행됨
    void Update()
    {
        // 따라갈 대상이 없으면 아무 것도 하지 않음
        if (target == null)
            return;

        // 현재 카메라 위치를 가져옴
        Vector3 pos = transform.position;

        // 대상 위치에 X, Y 오프셋을 더해서 새 위치를 만듬
        pos.x = target.position.x + offsetX;
        pos.y = target.position.y + offsetY;

        // 카메라 위치 업데이트
        transform.position = pos;
    }
}