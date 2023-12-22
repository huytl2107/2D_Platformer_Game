using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plants : MonoBehaviour
{
    [SerializeField] RaycastOnlyPlayer raycast;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private GameObject bullet;
    private Animator anim;
    private bool canShoot = true;
    [SerializeField] private float waitBeforeShoot = .65f;
    [SerializeField] private float plusYBullet = 0;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        raycast.RaycastCheck();
        if (raycast.seePlayer && canShoot)
        {
            anim.SetBool("State", true);
            StartCoroutine(WaitAnimationAndShot());
            StartCoroutine(WaitForNextShot());
        }
    }
    void ShootBullet()
    {
        // Tạo một bản sao của prefab viên đạn tại vị trí và hướng của đối tượng Plants
        Vector3 bulletPosition = new Vector3(transform.position.x, transform.position.y + plusYBullet, transform.position.z);
        GameObject thisbullet = Instantiate(bullet, bulletPosition, transform.rotation);

        // Phát âm thanh bắn
        shootSound.Play();
    }
    IEnumerator WaitForNextShot()
    {
        // Chờ trong khoảng thời gian quy định trước khi có thể bắn lần tiếp theo
        canShoot = false;
        yield return new WaitForSeconds(1.5f);
        canShoot = true;
    }
    IEnumerator WaitAnimationAndShot()
    {
        yield return new WaitForSeconds(waitBeforeShoot);
        ShootBullet();
        anim.SetBool("State", false);
    }
}
