using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Player")
        {
            SoundManager.Instant.PlaySound(GameEnum.ESound.finishSound);
            Invoke("CompleteLevel", 1f);
        }
    }
    private void CompleteLevel()
    {
        UIManager.Instant.PopUpWinPanel();
    }
}
