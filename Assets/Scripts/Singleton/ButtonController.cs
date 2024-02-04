using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gắn scripts này cho các button để tham chiếu qua GameManager và sử dụng
public class ButtonController : MonoBehaviour
{
    [SerializeField] private int _level;

    public void StartGame()
    {
        UIManager.Instant.PopUpMenuLevel();
    }

    public void Option()
    {
        UIManager.Instant.PopUpOption();
    }

    public void ConfirmExit()
    {
        UIManager.Instant.PopUpExitForm();
    }

    public void ExitGame()
    {
        GameManager.Instant.ExitGame();
    }
    public void RestartLevel()
    {
        GameManager.Instant.RestartLevel();
    }

    public void ExitButton()
    {
        GameManager.Instant.ExitButton();
    }

    public void ReturnHome()
    {
        GameManager.Instant.ReturnHome();
    }

    public void LoadLevel()
    {
        GameManager.Instant.LoadLevel(_level);
    }

    public void NextLevel()
    {
        GameManager.Instant.NextLevel();
    }
}
