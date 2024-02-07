using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            SoundManager.Instant.PlaySound(GameEnum.ESound.itemCollectedSound);
            UIManager.Instant.PlayerHealth +=1;
            UIManager.Instant.UpdatePlayerHealthUI();
            Destroy(gameObject);
        }
    }

    private IEnumerator Effect()
    {
        anim.SetTrigger("Collected");
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
