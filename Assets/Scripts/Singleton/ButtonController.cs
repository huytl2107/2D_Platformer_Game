using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gắn scripts này cho các button để tham chiếu qua GameManager và sử dụng
public class ButtonController : MonoBehaviour
{
    [SerializeField] private int _level;

    private void PlaySfx()
    {
        SoundManager.Instant.PlaySound(GameEnum.ESound.uiClick);
    }

    public void StartGame()
    {
        PlaySfx();
        UIManager.Instant.PopUpMenuLevel();
    }

    public void Option()
    {
        PlaySfx();
        UIManager.Instant.PopUpOption();
    }

    public void ConfirmExit()
    {
        PlaySfx();
        UIManager.Instant.PopUpExitForm();
    }

    public void ExitGame()
    {
        PlaySfx();
        GameManager.Instant.ExitGame();
    }
    public void RestartLevel()
    {
        PlaySfx();
        UIManager.Instant.ResetFruitText();
        GameManager.Instant.RestartLevel();
    }

    public void ExitButton()
    {
        PlaySfx();
        GameManager.Instant.ExitButton();
    }

    public void ReturnHome()
    {
        PlaySfx();
        GameManager.Instant.ReturnHome();
    }

    public void LoadLevel()
    {
        PlaySfx();
        GameManager.Instant.LoadLevel(_level);
    }

    public void NextLevel()
    {
        PlaySfx();
        UIManager.Instant.SaveFruitsNumb();
        GameManager.Instant.NextLevel();
    }
}
