using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    float offsetX;
    float offsetY;

    // 카메라가 따라가는 속도
    public float followSpeed = 0.05f;


    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    void Update()
    {
        // 현재 위치 가져오기
        Vector3 pos = transform.position;

        // Y축 방향으로 속도만큼 증가
        pos.y += followSpeed * Time.deltaTime;

        // 위치 적용
        transform.position = pos;



    }
}