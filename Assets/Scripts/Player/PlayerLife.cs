using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public bool isHeadStomped = false;
    [SerializeField] private AudioSource deathSoundEffect;

    public global::System.Boolean IsHeadStomped { get => isHeadStomped; set => isHeadStomped = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Trap") || col.gameObject.CompareTag("WeakEnemies") || col.gameObject.CompareTag("StrongEnemies")){
            deathSoundEffect.Play();
            Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("WeakEnemies"))
        {
            IsHeadStomped = true;
            StartCoroutine(DestroyAfterDelay(col.gameObject, 1f));
        }
        if (col.gameObject.CompareTag("StrongEnemies"))
        {
            IsHeadStomped = true;
            StartCoroutine(DestroyAfterDelay(col.gameObject, 1f));
        }
    }
    private IEnumerator DestroyAfterDelay(GameObject objectToDestroy, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(objectToDestroy);
    }
    private void Die(){
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }
    private void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
