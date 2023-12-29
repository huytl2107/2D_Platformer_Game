using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    protected bool isPlayerInRange = false;
    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Player entered NPC's trigger zone.");
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("Player exited NPC's trigger zone.");
        }
    }

    protected void Update()
    {
        if (isPlayerInRange && (Input.GetButtonDown("Jump")))
        {
            // Người chơi nhấn Y, thực hiện hành động nói chuyện hoặc mở hộp thoại
            StartConversation();
        }
    }

    protected virtual void StartConversation()
    {
        // Thực hiện hành động khi người chơi bấm Y (ví dụ: mở hộp thoại)
        Debug.Log("NPC: Hello, how can I help you?");
    }
}
