using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChameleonStateManager : EnemiesStateManager
{
    public ChameleonStateManager()
    {
    }

    public override void Start()
    {
        CurrentState = State.ChameleonIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        HandleGroundDetection();
        PlayerCheck();
    }

    public override void HandleGroundDetection()
    {
        if (SeeGround || !GroundAheadCheck.IsOverlappingGround)
        {
            //Vì Sprite của con này lệch qua 1 bên nên cần cập nhật lại ví trí cho nó hiển thị chuẩn
            Rb.transform.position = new Vector2(Rb.transform.position.x - 2.5f * RaycastDirX, Rb.transform.position.y);
            FlipXObject();
        }
    }

    //Func này sẽ được gọi trong 1 farme của Animation Attack;
    private void PlayerGotHit()
    {
        if (SeePlayer)
        {
            Player.CurrentState = Player.State.GotHit();
            Player.CurrentState.EnterState();
        }
    }
}
