using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesState : MonoBehaviour
{
    private Animator anim;
    private bool isEnemiesDeath = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnemiesDeath)
        {
            anim.SetBool("Death", isEnemiesDeath);
            isEnemiesDeath = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            isEnemiesDeath = true;
        }
    }
}
