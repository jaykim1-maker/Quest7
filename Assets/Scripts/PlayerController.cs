using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(horizontal, vertical).normalized;

        if (Mathf.Abs(horizontal) > 0.01f)
        {
            //좌우 방향에 따라 lookDirection 값을 설정한다.
            //(1,0), (-1,0)
            lookDirection = new Vector2(horizontal, 0).normalized;
        }
    }





}

