using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] private RaycastOnlyPlayer shootRaycast;
    [SerializeField] protected RaycastOnlyPlayer leftRaycast;
    [SerializeField] protected RaycastOnlyPlayer rightRaycast;
    [SerializeField] protected GameObject player;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] protected float speed = 3f;
    protected bool seenPlayer = false;
    [SerializeField] private GameObject bullet;
    protected Animator anim;
    [SerializeField] private float plusXBullet = 0f;
    [SerializeField] private float plusYBullet = 0f;
    protected bool idle = true;
    
    private void Start() 
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        shootRaycast.RaycastCheck();
        leftRaycast.RaycastCheck();
        rightRaycast.RaycastCheck();
        if(leftRaycast.seePlayer || rightRaycast.seePlayer && !seenPlayer)
        {
            seenPlayer = true;
            Invoke("NotSeeingPlayer",5f);
        }
        if(seenPlayer)
        {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
        }
        if(shootRaycast.seePlayer && idle)
        {
            idle = false;
            anim.SetBool("State", true);
        }
    }
    protected void NotSeeingPlayer()
    {
        seenPlayer = false;
    }
    private void ShootBullet()
    {
        // Tạo một bản sao của prefab viên đạn tại vị trí và hướng của đối tượng Plants
        Vector3 bulletPosition = new Vector3(transform.position.x + plusXBullet, transform.position.y + plusYBullet, transform.position.z);
        GameObject thisbullet = Instantiate(bullet, bulletPosition, transform.rotation);
        Bullet bulletController = thisbullet.GetComponent<Bullet>();
        bulletController.right = shootRaycast.right ? true : false;
        // Phát âm thanh bắn
        shootSound.Play();
    }
    protected void SetIdle()
    {
        anim.SetBool("State", false);
        idle = true;
    }
}
