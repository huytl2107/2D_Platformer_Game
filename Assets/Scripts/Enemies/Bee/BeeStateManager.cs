using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeStateManager : EnemiesStateManager
{
    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        CurrentState = State.BeeIdle();
        CurrentState.EnterState();
    }

    public override void Update()
    {
        base.Update();
        PlayerCheck();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            CurrentState = State.BeeGotHit();
            CurrentState.EnterState();
        }
    }

    private void Fire()
    {
        Vector3 bulletPosition = new Vector3(transform.position.x + PlusXBullet, transform.position.y + PlusYBullet, transform.position.z);

        ObjectPooler.Instant.GetPoolObject("BeeBullet", bulletPosition, Quaternion.identity);
    }
}
