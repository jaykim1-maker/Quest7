using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float followSpeed = 0.2f;         // ī�޶� ���󰡴� �⺻ �ӵ�
    public float speedMultiplier = 1.05f;    // �ӵ��� �����ϴ� ����
    public float maxSpeed = 1.0f;            // �ִ� �ӵ� (���� �ڵ忡���� ������ ����)
    public float interval = 5f;              // �ӵ��� �����ϴ� �ð� ����(��)
    private float timer = 0f;                // �ð� ������ ����
    private Vector3 initialPosition;         // ī�޶��� ���� ��ġ�� ����

    void Start()
    {
        // ī�޶� ��ġ�� �������� ������ ����
        transform.position = new Vector3(0f, 0f, -10f);
        transform.localScale = new Vector3(1f, 1f, 1f);

        // �ʱ� ��ġ ���� (���� ���� �� ������)
        initialPosition = transform.position;
    }

    void Update()
    {
        // �� �����Ӹ��� �ð� ����
        timer += Time.deltaTime;

        // interval(��: 5��)���� �ӵ��� ������Ŵ
        if (timer >= interval)
        {
            followSpeed *= speedMultiplier;  // �ӵ� ����
            timer = 0f;                      // Ÿ�̸� �ʱ�ȭ
        }

        // ���� ��ġ�� �����ͼ� y������ �̵�
        Vector3 pos = transform.position;
        pos.y += followSpeed * Time.deltaTime;
        transform.position = pos;
    }


    /// ������ ������ �� ȣ��: ī�޶� ��ġ, ������, �ӵ�, Ÿ�̸Ӹ� ��� �ʱ�ȭ
    public void ResetCameraOnGameOver()
    {
        transform.position = initialPosition;           // ��ġ �ʱ�ȭ
        transform.localScale = new Vector3(1f, 1f, 1f); // ������ �ʱ�ȭ
        followSpeed = 0.2f;                             // �ӵ� �ʱ�ȭ
        timer = 0f;                                     // Ÿ�̸� �ʱ�ȭ
    }
}
