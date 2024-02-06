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

    public int GetBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadLevel(int level)
    {
        if(UIManager.Instant.IsWinPanelActive())
        {
            UIManager.Instant.SaveFruitsNumb();
        }
        SceneManager.LoadScene(level);
        UIManager.Instant.HideAllUI();
        StartCoroutine(ResetFruitText());
        //Không chạy lại nhạc khi player load lại màn chơi cũ
        if(SceneManager.GetActiveScene().buildIndex == level)
        return;
        SoundManager.Instant.PlayMusic((GameEnum.EMusic)level);
    }

    //Đợi nó lưu rồi hãy reset Text;
    public IEnumerator ResetFruitText()
    {
        yield return new WaitForSeconds(.1f);
        UIManager.Instant.ResetFruitText();
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

    public void ExitButtonSetting()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            UIManager.Instant.LoadHomeUI();
        }
        else
        {
            UIManager.Instant.HideAllUI();
        }
    }

    public void ReturnHome()
    {
        SceneManager.LoadScene(0);
        UIManager.Instant.LoadHomeUI();
        SoundManager.Instant.PlayMusic(GameEnum.EMusic.MusicIndex);
    }
}
