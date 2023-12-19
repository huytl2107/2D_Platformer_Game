using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fruits = 0;
    [SerializeField] private Text fruitsText;
    [SerializeField] private AudioSource collectItemSoundEffect;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Apple"))
        {
            Destroy(col.gameObject);
            fruits++;
            fruitsText.text = "Fruits: " + fruits;
            collectItemSoundEffect.Play();
        }
    }
}
