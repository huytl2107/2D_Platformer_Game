using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStateManager : EnemiesStateManager
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        CurrentState = State.PlantIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
    }

    public void Fire()
    {
        Vector3 bulletPosition = new Vector3(transform.position.x + PlusXBullet * RaycastDirX, transform.position.y + PlusYBullet, transform.position.z);
        //CurrentWeapon = Instantiate(_weapon, weaponPosition, transform.rotation);

        SoundManager.Instant.PlaySound(GameEnum.ESound.enemyShoot);
        GameObject bullet = ObjectPooler.Instant.GetPoolObject("Bullet", bulletPosition, Quaternion.identity);
        if (bullet != null)
        {
            BulletController bulletController = bullet.GetComponent<BulletController>();
            bulletController.SetDirection(RaycastDirX);
        }
    }

    public override void GotHit()
    {
        CurrentState.ExitState();
        CurrentState = State.PlantGotHit();
        CurrentState.EnterState();
    }
}
