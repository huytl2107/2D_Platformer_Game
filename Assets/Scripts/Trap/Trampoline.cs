using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float thrust = 30f;
    private void Start() {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.name == "Player")
        {
            SoundManager.Instant.PlaySound(GameEnum.ESound.trampolineSound);
            anim.SetBool("State", true);
            Rigidbody2D playerRB = col.GetComponent<Rigidbody2D>();
            playerRB.AddForce(Vector2.up * thrust, ForceMode2D.Impulse);
        }
    }
    private void SetIdle()
    {
        anim.SetBool("State", false);
    }
}
