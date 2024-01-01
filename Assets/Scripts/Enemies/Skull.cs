using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : StrongEnemiesMovement
{
    [SerializeField] private float plusYBullet = 0;
    [SerializeField] private float plusXBullet = 0;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private int numbBullet = 7;
    private bool canShoot = true;
    private bool canMove = true;
    private bool isTranf = false;
    private bool attackedPlayer = false;
    [SerializeField] private EnemiesRaycast leftRaycast;
    [SerializeField] private EnemiesRaycast rightRaycast;
    [SerializeField] private SkullLife skullLife;
    private enum state { idle1, gotHit1, tranf, idle2, gotHit2, attack1, attack2 };
    [SerializeField] private Sprite redHorn;

    void Update()
    {
        if ((skullLife.lives < 5) && !isTranf)
        {
            isTranf = true;
            speed = speed * 2;
            numbBullet = 8;
            coll.size = new Vector2(coll.size.x + 1f, coll.size.y + 0.5f);
        }
        leftRaycast.RaycastCheck();
        rightRaycast.RaycastCheck();
        if (canMove && !attackedPlayer)
        {
            if (leftRaycast.seePlayer || rightRaycast.seePlayer)
            {
                Running();
                if (leftRaycast.seePlayer && move == 1 && canFlip)
                {
                    FlipObject();
                }
                if (rightRaycast.seePlayer && move == -1 && canFlip)
                {
                    FlipObject();
                }
                if (canShoot)
                {
                    canShoot = false;
                    Invoke("DelayAndShoot", 2f);
                }
            }
            else
            {
                Walking();
            }
        }
        else if (canMove && attackedPlayer)
        {
            StopRunning();
            Invoke("WaitBeforeNextAttack", 1f);
        }
        if ((leftRaycast.seeGround || rightRaycast.seeGround) && canFlip)
        {
            FlipObject();
        }
    }
    private void DelayAndShoot()
    {
        canMove = false;
        StopRunning();
        if (!isTranf)
        {
            anim.SetInteger("State", (int)state.attack1);
        }
        else
        {
            anim.SetInteger("State", (int)state.attack2);
        }
        Invoke("CanShootTrue", 2f);
        Invoke("CanMoveTrue", 1f);
    }
    private void ShootBullet()
    {
        Vector3 bulletPosition = new Vector3(transform.position.x + move * plusXBullet, transform.position.y + plusYBullet, transform.position.z);
        for (float i = 0; i < 181; i += 180f / (numbBullet - 1))
        {
            GameObject thisbullet = Instantiate(bullet, bulletPosition, transform.rotation);
            Bullet bulletController = thisbullet.GetComponent<Bullet>();
            bulletController.shootAngle = i;
            if(isTranf)
            {
                SpriteRenderer bulletSprite = thisbullet.GetComponent<SpriteRenderer>();
                bulletSprite.sprite = redHorn;
            }
        }
        Debug.Log("Shoot");
        shootSound.Play();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            attackedPlayer = true;
        }
    }
    private void WaitBeforeNextAttack()
    {
        attackedPlayer = false;
    }

    private void FlipObject()
    {
        canFlip = false;
        sprite.flipX = !sprite.flipX;
        move = -move;
        Invoke("CanFlipTrue", .2f);
    }
    private void CanShootTrue()
    {
        canShoot = true;
    }
    private void CanMoveTrue()
    {
        canMove = true;
    }
    private void ReturnIdle()
    {
        if (skullLife.lives > 4)
        {
            anim.SetInteger("State", (int)state.idle1);
        }
        else
        {
            anim.SetInteger("State", (int)state.idle2);
        }
    }
}
