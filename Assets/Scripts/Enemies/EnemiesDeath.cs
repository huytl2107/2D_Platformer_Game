using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDeath : MonoBehaviour
{
    private Animator anim;
    private bool death = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.name == "Player") || col.CompareTag("Weapon"))
        {
            Debug.Log("Va chạm");
            anim.SetTrigger("Death");
            Death();
        }
    }

    private void Death()
    {
        death = true;
        Invoke("Destroy", 1f);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
    public bool isDeath()
    {
        return death;
    }
}
