using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            SoundManager.Instant.PlaySound(GameEnum.ESound.itemCollectedSound);
            UIManager.Instant.UpdateFruitText();
            Destroy(gameObject);
        }
    }
}
