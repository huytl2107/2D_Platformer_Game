using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkMovement : StrongEnemiesMovement
{
    [SerializeField] EnemiesRaycast raycast;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioSource shootSound;
    private enum state { idle, running, attack };
    state currentState;
    private bool canShoot = true;
    [SerializeField] private float plusYBullet = 0;
    [SerializeField] private float plusXBullet = 0;
    [SerializeField] private float reloadBullet = 1.5f;
    protected override void Start()
    {
        base.Start();
        currentState = state.running;
    }

    // Update is called once per frame
    void Update()
    {
        raycast.RaycastCheck();
        move = raycast.right ? 1 : -1;
        if (move == -1)
        {
            sprite.flipX = false;
        }
        if (move == 1)
        {
            sprite.flipX = true;
        }
        if (raycast.seePlayer && canShoot)
        {
            currentState = state.attack;
            StartCoroutine(WaitForNextShot());
        }
        if (raycast.seePlayer && !isStartedRunning)
        {
            move = -move;
            Running();
            move = -move;
        }
        else if (isStartedRunning)
        {
            move = -move;
            DelayRunning();
            move = -move;
        }
        else
        {
            Walking();
        }
        anim.SetInteger("State", (int)currentState);
        if (raycast.seeGround)
        {
            raycast.right = !raycast.right;
            Debug.Log(raycast.right);
        }
    }
    void ShootBullet()
    {
        // Tạo một bản sao của prefab viên đạn tại vị trí và hướng của đối tượng Plants
        Vector3 bulletPosition = new Vector3(transform.position.x + move * plusXBullet, transform.position.y + plusYBullet, transform.position.z);
        GameObject thisbullet = Instantiate(bullet, bulletPosition, transform.rotation);
        Bullet bulletController = thisbullet.GetComponent<Bullet>();
        bulletController.right = raycast.right ? true : false;

        // Phát âm thanh bắn
        shootSound.Play();
    }
    IEnumerator WaitForNextShot()
    {
        // Chờ trong khoảng thời gian quy định trước khi có thể bắn lần tiếp theo
        canShoot = false;
        yield return new WaitForSeconds(reloadBullet);
        currentState = state.running;
        canShoot = true;
    }
}
