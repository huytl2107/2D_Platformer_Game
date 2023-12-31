using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : StrongEnemiesMovement
{
    [SerializeField] private float plusYBullet = 0;
    [SerializeField] private float plusXBullet = 0;
    [SerializeField] private GameObject bullet;
    [SerializeField] private AudioSource shootSound;
    private bool isCalled = false;
    [SerializeField] private int numbBullet = 7;
    void Update()
    {
        if (!isCalled)
        {
            isCalled = true;
            ShootBullet();
        }
    }
    void ShootBullet()
    {
        Vector3 bulletPosition = new Vector3(transform.position.x + move * plusXBullet, transform.position.y + plusYBullet, transform.position.z);
        for (float i = 0; i < 181; i += 180f / numbBullet)
        {
            GameObject thisbullet = Instantiate(bullet, bulletPosition, transform.rotation);
            Bullet bulletController = thisbullet.GetComponent<Bullet>();
            bulletController.shootAngle = i;
        }
        Debug.Log("Shoot");
        shootSound.Play();
        Invoke("ShootBullet", 4f);
    }
}
