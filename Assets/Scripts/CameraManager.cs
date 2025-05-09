using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    float offsetY;

    void Start()
    {
        if (target == null)
            return;

        offsetY = transform.position.y - target.position.y;
    }

    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position;
        pos.y = target.position.y + offsetY;
        transform.position = pos;
    }
}
