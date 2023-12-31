using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private AudioSource axeSound;
    [SerializeField] private GameObject axe;
    [SerializeField] private float plusYAxe;
    [SerializeField] private float plusXAxe;
    private float dirX = 0;
    private float direction = 1;
    private PlayerMovement playerMovement;
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerMovement.CanMove())
        {
            dirX = Input.GetAxisRaw("Horizontal");
            if (dirX != 0) { direction = dirX; }
            if (Input.GetKeyDown(KeyCode.J))
            {
                ThrowAxe();
            }
        }
    }
    void ThrowAxe()
    {
        Vector3 axePoisition = new Vector3(transform.position.x + plusXAxe * direction, transform.position.y + plusYAxe, transform.position.z);
        GameObject thisAxe = Instantiate(axe, axePoisition, transform.rotation);

        AxeController axeController = thisAxe.GetComponent<AxeController>();
        axeController.SetDirection(direction);
        axeSound.Play();
    }

}
