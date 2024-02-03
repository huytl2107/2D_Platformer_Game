using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gắn scripts này cho các button để tham chiếu qua GameManager và sử dụng
public class ButtonController : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instant.StartGame();
    }
    public void ExitGame()
    {
        GameManager.Instant.Quit();
    }
}
