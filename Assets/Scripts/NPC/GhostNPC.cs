using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;

public class GhostNPC : NPC
{
    [SerializeField] private GameObject _chatBox;
    [SerializeField] private GameObject _notification;
    [SerializeField] private string[] text;
    private Transform _player;
    private bool _canContunies = true;
    private int _currentIndex = 0;
    private enum state { idle, appear, disappear };
    private Animator anim;
    private SpriteRenderer sprite;
    private Text _chatText;
    [SerializeField] private float _timeLoadText = .05f;
    private IEnumerator _coroutine;

    [System.Serializable]
    public class TargetStory
    {
        public Transform Target;
        public int TextNumberToTransformCamera;
    }
    public List<TargetStory> _listTransform;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        Color currentColor = sprite.color;
        currentColor.a = 0f; // Đặt alpha thành 0 để ẩn
        sprite.color = currentColor;
        _chatText = _chatBox.GetComponentInChildren<Text>();
        _player = GameObject.FindObjectOfType<PlayerStateManager>().transform;
    }

    private new void Update()
    {
        // Ẩn _ChatBox khi không trong cuộc trò chuyện
        if (_chatBox != null && !isPlayerInRange)
        {
            _chatBox.SetActive(false);
            _notification.SetActive(false);
        }
        if (isPlayerInRange && (Input.GetButtonDown("Jump")) && _canContunies)
        {
            //Dảm bảo dừng Coroutine DisplayText cũ
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            _coroutine = null;

            // Người chơi nhấn Space, mở hộp thoại chat
            if (_currentIndex >= text.Length)
            {
                CameraController.Instant.Player = _player;
                _notification.SetActive(false);
                _chatBox.SetActive(false);
                anim.SetInteger("State", (int)state.disappear);
            }
            else
            {
                bool conversationStarted = false; // Biến để kiểm tra xem liệu cuộc trò chuyện đã được bắt đầu chưa

                for (int i = 0; i < _listTransform.Count; i++)
                {
                    if (_currentIndex == _listTransform[i].TextNumberToTransformCamera)
                    {
                        StartConversation();
                        if (_listTransform[i].Target != null)
                        {
                            CameraController.Instant.Player = _listTransform[i].Target;
                        }
                        conversationStarted = true; // Đánh dấu rằng cuộc trò chuyện đã được bắt đầu
                        break; // Thoát khỏi vòng lặp sau khi bắt đầu cuộc trò chuyện
                    }
                }

                if (!conversationStarted)
                {
                    StartConversation();
                }
            }
        }
    }

    protected override void StartConversation()
    {
        _canContunies = false;
        _notification.SetActive(false);
        _chatBox.SetActive(true);
        _chatText.text = "";
        _coroutine = DisplayText(text[_currentIndex]);
        StartCoroutine(_coroutine);
        _currentIndex++;
        Debug.Log("Ghost: Hello Bro!!!");
        Invoke("Show_Notification", 1f);
    }

    private IEnumerator DisplayText(string displayText)
    {
        for (int i = 1; i < displayText.Length; i += 2)
        {
            _chatText.text += displayText[i - 1];
            _chatText.text += displayText[i];
            yield return new WaitForSeconds(_timeLoadText);
        }
    }

    private void Show_Notification()
    {
        _notification.SetActive(true);
        _canContunies = true;
    }
    protected new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _notification.SetActive(true);
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

        _notification.SetActive(false);
        _chatBox.SetActive(false);
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
