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
        Vector3 weaponPosition = new Vector3(transform.position.x + PlusXBullet * RaycastDirX, transform.position.y + PlusYBullet, transform.position.z);
        //CurrentWeapon = Instantiate(_weapon, weaponPosition, transform.rotation);

        GameObject bullet = BulletPool.Instance.GetPoolObject();
        if (bullet != null)
        {
            AxeController axeController = bullet.GetComponent<AxeController>();
            axeController.SetDirection(RaycastDirX);
            bullet.transform.position = weaponPosition;
            bullet.SetActive(true);
        }
    }
}
