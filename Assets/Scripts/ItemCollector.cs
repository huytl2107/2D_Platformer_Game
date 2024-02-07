using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            SoundManager.Instant.PlaySound(GameEnum.ESound.itemCollectedSound);
            UIManager.Instant.UpdateFruitText();
            StartCoroutine(Effect());
        }
    }

    private IEnumerator Effect()
    {
        anim.SetTrigger("Collected");
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }
}
