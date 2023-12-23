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
        StartCoroutine(DestroyAfterDelay(gameObject, 1f));
    }
    private IEnumerator DestroyAfterDelay(GameObject objectToDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(objectToDestroy);
    }
    public bool isDeath()
    {
        return death;
    }
}
