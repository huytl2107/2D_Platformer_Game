using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            UIManager.Instant.PlayerHealth +=1;
            UIManager.Instant.UpdatePlayerHealthUI();
            Destroy(gameObject);
        }
    }
}
