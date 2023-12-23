using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDeath : MonoBehaviour
{
    private Animator anim;
    private bool onTriggerEnter = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            onTriggerEnter = true;
            anim.SetBool("Death", onTriggerEnter);
        }
        if (col.CompareTag("Weapon"))
        {
            onTriggerEnter = true;
            anim.SetBool("Death", onTriggerEnter);
        }
    }
    public bool Death()
    {
        return onTriggerEnter;
    }
}
