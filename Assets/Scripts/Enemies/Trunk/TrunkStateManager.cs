using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkStateManager : EnemiesStateManager
{
    public override void Awake()
    {
        base.Awake();
    }
    public override void Start()
    {
        CurrentState = State.TrunkWalk();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
        HandleGroundDetection();
    }

    public void Fire()
    {
        Vector3 bulletPosition = new Vector3(transform.position.x + PlusXBullet * RaycastDirX, transform.position.y + PlusYBullet, transform.position.z);
        //CurrentWeapon = Instantiate(_weapon, weaponPosition, transform.rotation);

        GameObject bullet = ObjectPooler.Instant.GetPoolObject("TrunkBullet", bulletPosition, Quaternion.identity);
        if (bullet != null)
        {
            BulletController axeController = bullet.GetComponent<BulletController>();
            axeController.SetDirection(RaycastDirX);
        }
    }



    public override void GotHit()
    {
        CurrentState = State.TrunkGotHit();
        CurrentState.EnterState();
    }
}
