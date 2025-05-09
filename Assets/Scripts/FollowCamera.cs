using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowCamera : MonoBehaviour
{
    // ���� ��� (��: Player)
    public Transform target;

    // X, Y �������� �󸶳� ������ ��ġ���� ������
    float offsetX;
    float offsetY;

    // ������ ���۵� �� �� �� �����
    void Start()
    {
        // ���� ����� ������ �ƹ� �͵� ���� ����
        if (target == null)
            return;

        // ó�� ������ �� �Ÿ� ���̸� ����ص�
        offsetX = transform.position.x - target.position.x;
        offsetY = transform.position.y - target.position.y;
    }

    // �� �����Ӹ��� �����
    void Update()
    {
        // ���� ����� ������ �ƹ� �͵� ���� ����
        if (target == null)
            return;

        // ���� ī�޶� ��ġ�� ������
        Vector3 pos = transform.position;

        // ��� ��ġ�� X, Y �������� ���ؼ� �� ��ġ�� ����
        pos.x = target.position.x + offsetX;
        pos.y = target.position.y + offsetY;

        // ī�޶� ��ġ ������Ʈ
        transform.position = pos;
    }
}