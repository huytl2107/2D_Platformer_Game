using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chameleon : StrongEnemiesMovement
{
    private bool called = false;
    private enum state { idle, running, attack };
    [SerializeField] GameObject player;
    [SerializeField] EnemiesRaycast enemiesRaycast;
    private bool isRunning = false;
    private float delayTime;

    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        enemiesRaycast.RaycastCheck();
        if (!called)
        {
            Invoke("SetAnimIdle", delayTime);
            called = true;
        }
        if (isRunning)
        {
            Running();
        }
        else
        {
            StopRunning();
        }
        if (enemiesRaycast.seeGround && canFlip)
        {
            FlipObject();
        }
    }
    private void SetAnimIdle()
    {
        isRunning = false;
        anim.SetInteger("State", (int)state.idle);
        Invoke("SetAnimRunning", 3f);
    }
    private void SetAnimRunning()
    {
        isRunning = true;
        anim.SetInteger("State", (int)state.running);
        Invoke("SetAnimAttack", 3f);
    }
    private void SetAnimAttack()
    {
        isRunning = false;
        anim.SetInteger("State", (int)state.attack);
    }
    private void Attack()
    {
        if (enemiesRaycast.seePlayer)
        {
            //PlayerLife playerLife = player.GetComponent<PlayerLife>();
            //if (playerLife != null)
            //{
            //    playerLife.DeathOrAlive();
            //}
        }
    }
    private void FlipObject()
    {
        sprite.flipX = !sprite.flipX;
        move = -move;
        enemiesRaycast.right = !enemiesRaycast.right;
        // Điều chỉnh vị trí của đối tượng sau khi flip
        float adjustment = sprite.flipX ? 3f : -3f;
        transform.position = new Vector3(transform.position.x + adjustment, transform.position.y, transform.position.z);
        canFlip = false;
        Invoke("CanFlipTrue", 1f);
    }
}