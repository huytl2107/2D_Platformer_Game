using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesState : MonoBehaviour
{
    private Animator anim;
    private bool onTriggerEnter = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            onTriggerEnter = false;
            anim.SetBool("State", onTriggerEnter);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            onTriggerEnter = true;
            anim.SetBool("State", onTriggerEnter);
        }
    }
}
