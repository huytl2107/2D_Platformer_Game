using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("UI")]
    [SerializeField] GameObject _startMenu;
    [SerializeField] GameObject _option;
    [SerializeField] GameObject _exitConfirm;
    [SerializeField] GameObject _menuLevel;
    [SerializeField] GameObject _losePanel;
    [SerializeField] GameObject _winPanel;


    //Sử dụng Singleton để quản lý PlayerHealth, lưu lại qua các scene;
    [Header("Health")]
    [SerializeField] private int _playerHealth;
    [SerializeField] private Image _head1;
    [SerializeField] private Image _head2;
    [SerializeField] private Image _head3;
    [SerializeField] private Sprite _head;
    [SerializeField] private Sprite _nullHead;

    [Header("ItemCollector")]
    [SerializeField] private Text _fruitText;
    private int _fruitNumb = 0;

    public int PlayerHealth { get => _playerHealth; set => _playerHealth = value; }
    public Image Head1 { get => _head1; set => _head1 = value; }
    public Image Head2 { get => _head2; set => _head2 = value; }
    public Image Head3 { get => _head3; set => _head3 = value; }
    public Sprite Head { get => _head; set => _head = value; }
    public Sprite NullHead { get => _nullHead; set => _nullHead = value; }
    public Text FruitText { get => _fruitText; set => _fruitText = value; }
    public int FruitNumb { get => _fruitNumb; set => _fruitNumb = value; }

    public override void Awake()
    {
        base.Awake(); // Gọi Awake của lớp cha để thực hiện việc Singleton

        if (_instant == this) // Đảm bảo chỉ thực hiện với instance mới được tạo ra
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Start()
    {
        LoadHomeUI();
    }

    public void HideAllUI()
    {
        if (_startMenu != null) _startMenu.SetActive(false);
        if (_option != null) _option.SetActive(false);
        if (_exitConfirm != null) _exitConfirm.SetActive(false);
        if (_menuLevel != null) _menuLevel.SetActive(false);
        if (_losePanel != null) _losePanel.SetActive(false);
        if (_winPanel != null) _winPanel.SetActive(false);
    }

    public void LoadHomeUI()
    {
        HideAllUI();
        if (_startMenu != null) _startMenu.SetActive(true);
    }

    public void PopUpLosePanel()
    {
        _losePanel.SetActive(true);
    }

    public void PopUpWinPanel()
    {
        _winPanel.SetActive(true);
    }

    public void PopUpMenuLevel()
    {
        _menuLevel.SetActive(true);
    }

    public void PopUpOption()
    {
        _option.SetActive(true);
    }

    public void PopUpExitForm()
    {
        _exitConfirm.SetActive(true);
    }

    #region HealthAndFruits
    public void GotHit()
    {
        PlayerHealth -= 1;
        Debug.Log(PlayerHealth);
    }
    public void UpdatePlayerHealthUI()
    {
        if (PlayerHealth > 3) PlayerHealth = 3;
        switch (PlayerHealth)
        {
            case 3:
                Head1.sprite = Head;
                Head2.sprite = Head;
                Head3.sprite = Head;
                break;
            case 2:
                Head1.sprite = Head;
                Head2.sprite = Head;
                Head3.sprite = NullHead;
                break;
            case 1:
                Head1.sprite = Head;
                Head2.sprite = NullHead;
                Head3.sprite = NullHead;
                break;
            case 0:
                Head1.sprite = NullHead;
                Head2.sprite = NullHead;
                Head3.sprite = NullHead;
                break;
        }
    }
    public void UpdateFruitText()
    {
        FruitNumb += 1;
        FruitText.text = "Fruit: " + FruitNumb;
    }
    #endregion HealthAndFruits
}