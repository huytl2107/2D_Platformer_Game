using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostNPC : NPC
{
    [SerializeField] private GameObject chatBox;
    [SerializeField] private GameObject notification;
    [SerializeField] private string[] text;
    private bool canContunies = true;
    private int currentIndex = 0;
    private enum state { idle, appear, disappear };
    private Animator anim;
    private SpriteRenderer sprite;
    private Text _chatText;
    [SerializeField] private float _timeLoadText = .05f;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        Color currentColor = sprite.color;
        currentColor.a = 0f; // Đặt alpha thành 0 để ẩn
        sprite.color = currentColor;
        _chatText = chatBox.GetComponentInChildren<Text>();
    }

    private new void Update()
    {
        // Ẩn ChatBox khi không trong cuộc trò chuyện
        if (chatBox != null && !isPlayerInRange)
        {
            chatBox.SetActive(false);
            notification.SetActive(false);
        }
        if (isPlayerInRange && (Input.GetButtonDown("Jump")))
        {
            // Người chơi nhấn Space, mở hộp thoại chat
            if (currentIndex >= text.Length)
            {
                notification.SetActive(false);
                chatBox.SetActive(false);
                anim.SetInteger("State", (int)state.disappear);
            }
            else
            {
                StartConversation();
            }
        }
    }

    protected override void StartConversation()
    {
        if (canContunies)
        {
            canContunies = false;
            notification.SetActive(false);
            chatBox.SetActive(true);
            _chatText.text = "";
            StartCoroutine(DisplayText(text[currentIndex]));
            currentIndex++;
            Debug.Log("Ghost: Hello Bro!!!");
            Invoke("ShowNotification", 1f);
        }
    }

    private IEnumerator DisplayText(string displayText)
    {
        for (int i=0; i<displayText.Length; i++)
        {
            _chatText.text += displayText[i];
            yield return new WaitForSeconds(_timeLoadText);
        }
    }

    private void ShowNotification()
    {
        notification.SetActive(true);
        canContunies = true;
    }
    protected new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            notification.SetActive(true);
            Color currentColor = sprite.color;
            currentColor.a = 1f;
            sprite.color = currentColor;
            isPlayerInRange = true;
            anim.SetInteger("State", (int)state.appear);
        }
    }

    private new void OnTriggerExit2D(Collider2D other)
    {
        Color currentColor = sprite.color;
        currentColor.a = 0f;
        sprite.color = currentColor;

        notification.SetActive(false);
        chatBox.SetActive(false);
    }

    private void SetIdle()
    {
        anim.SetInteger("State", (int)state.idle);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
