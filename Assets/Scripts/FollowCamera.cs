using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    float offsetX;
    float offsetY;

    // ī�޶� ���󰡴� �ӵ�
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
        // ���� ��ġ ��������
        Vector3 pos = transform.position;

        // Y�� �������� �ӵ���ŭ ����
        pos.y += followSpeed * Time.deltaTime;

        // ��ġ ����
        transform.position = pos;



    }
}