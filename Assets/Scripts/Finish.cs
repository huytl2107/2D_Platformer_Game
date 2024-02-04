using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelComplected = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player" && !levelComplected)
        {
            finishSound.Play();
            levelComplected = true;
            Invoke("CompleteLevel", 1f);
        }
    }
    private void CompleteLevel()
    {
        UIManager.Instant.PopUpWinPanel();
    }
}
