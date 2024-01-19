using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailStateManager : EnemiesStateManager
{
    private bool _canFlip = true;
    [SerializeField] private float X = 1.8f;
    [SerializeField] private float Y = 1.8f;
    public override void Start()
    {
        CurrentState = State.SnailWalk();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        Debug.Log(SeeGround);
        HandleGroundDetection();
    }

    public override void HandleGroundDetection()
    {
        if (_canFlip)
        {
            if (SeeGround && GroundAheadCheck.IsOverlappingGround)
            {
                StartCoroutine(CoolDownFlip());
                //Xoay lên trên 90 độ
                transform.Rotate(0, 0, 90);
            }
            else if (!SeeGround && !GroundAheadCheck.IsOverlappingGround)
            {
                StartCoroutine(CoolDownFlip());
                //Xoay xuống dưới 90 độ
                transform.Rotate(0, 0, -90);
                TransformPositionSnail();
            }
        }
    }

    public override void WallCheck()
    {
        float normalizedAngle = Mathf.Repeat(transform.eulerAngles.z, 360f);
        Vector2 rayDirection = Vector2.right;

        if (Mathf.Approximately(normalizedAngle, 0f))
        {
            rayDirection = Vector2.right;
        }
        else if (Mathf.Approximately(normalizedAngle, 90f))
        {
            rayDirection = Vector2.up;
        }
        else if (Mathf.Approximately(normalizedAngle, 180f))
        {
            rayDirection = Vector2.left;
        }
        else if (Mathf.Approximately(normalizedAngle, 270f))
        {
            rayDirection = Vector2.down;
        }

        RaycastGround = Physics2D.Raycast(Col.bounds.center, rayDirection, DistanceWallCheck, ~IgnoreLayer);
        RaycastCheckGround();
    }

    private IEnumerator CoolDownFlip()
    {
        _canFlip = false;
        yield return new WaitForSeconds(.7f);
        _canFlip = true;
    }

    private void TransformPositionSnail()
    {
        float normalizedAngle = Mathf.Repeat(transform.eulerAngles.z, 360f);

        if (Mathf.Approximately(normalizedAngle, 0f))
        {
            //right;
            transform.position = new Vector2(transform.position.x + X, transform.position.y + Y);
        }
        else if (Mathf.Approximately(normalizedAngle, 90f))
        {
            //up;
            transform.position = new Vector2(transform.position.x - X, transform.position.y + Y);
        }
        else if (Mathf.Approximately(normalizedAngle, 180f))
        {
            //left;
            transform.position = new Vector2(transform.position.x - X, transform.position.y - Y);
        }
        else if (Mathf.Approximately(normalizedAngle, 270f))
        {
            //down;
            transform.position = new Vector2(transform.position.x + X, transform.position.y - Y);
        }
    }



}
