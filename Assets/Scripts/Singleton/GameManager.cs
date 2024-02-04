using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        UIManager.Instant.HideAllUI();

        //Không chạy lại nhạc khi player load lại màn chơi cũ
        if(SceneManager.GetActiveScene().buildIndex == level)
        return;

        SoundManager.Instant.PlayMusic((GameEnum.EMusic)level);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        UIManager.Instant.HideAllUI();
        SoundManager.Instant.PlayMusic((GameEnum.EMusic)(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UIManager.Instant.HideAllUI();
    }

    public void ExitButton()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            UIManager.Instant.LoadHomeUI();
        }
        else
        {
            UIManager.Instant.HideAllUI();
            if(UIManager.Instant.PlayerHealth < 0)
            {
                UIManager.Instant.PopUpLosePanel();
            }
            else
            {
                UIManager.Instant.PopUpWinPanel();
            }
        }
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene(0);
        UIManager.Instant.LoadHomeUI();
        SoundManager.Instant.PlayMusic(GameEnum.EMusic.MusicIndex);
    }
}
