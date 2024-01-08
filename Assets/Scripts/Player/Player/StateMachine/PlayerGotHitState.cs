using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerGotHitState : PlayerBaseState
{
    [SerializeField] private float _gotHitTime = .5f;
    private bool _isGottingHit = false;

    public PlayerGotHitState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public bool IsGottingHit { get => _isGottingHit; set => _isGottingHit = value; }

    public override void EnterState()
    {
        Debug.Log("Hello from GotHit State");
        if (player.PlayerHealth > -1)
        {
            player.GotHitSound.Play();
            //Transition từ AnyState, tắt Can transition to self để không treo ở frame đàu.
            player.Anim.SetBool("GotHit", true);
            player.Rb.AddForce(Vector2.up * player.JumpForce, ForceMode2D.Impulse);
            player.StartCoroutine(GotHit());
            UpdatePlayerHealthUI();
        }
        else
        {
            player.Anim.SetTrigger("Death");
            player.Rb.bodyType = RigidbodyType2D.Static;
            player.StartCoroutine(Death());
        }
    }

    public override void UpdateState()
    {
        CheckSwitchState();
    }

    
    public override void CheckSwitchState()
    {
        if (IsGottingHit)
        {
            player.Rb.velocity = new Vector2(-player.RaycastDirX * player.Speed, player.Rb.velocity.y);
        }
        else
        {
            SwitchState(factory.Fall());
        }
    }

    private IEnumerator GotHit()
    {
        IsGottingHit = true;
        yield return new WaitForSeconds(_gotHitTime);
        IsGottingHit = false;
    }

    private IEnumerator Death()
    {
        Debug.Log("Hello from IEnumerator");
        //Chờ 1s rồi restart level
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdatePlayerHealthUI()
    {
        switch (player.PlayerHealth)
        {
            case 3:
                player.Head1.sprite = player.Head;
                player.Head2.sprite = player.Head;
                player.Head3.sprite = player.Head;
                break;
            case 2:
                player.Head1.sprite = player.Head;
                player.Head2.sprite = player.Head;
                player.Head3.sprite = player.NullHead;
                break;
            case 1:
                player.Head1.sprite = player.Head;
                player.Head2.sprite = player.NullHead;
                player.Head3.sprite = player.NullHead;
                break;
            case 0:
                player.Head1.sprite = player.NullHead;
                player.Head2.sprite = player.NullHead;
                player.Head3.sprite = player.NullHead;
                break;
        }
    }

    public override void ExitState()
    {

    }

    public override void InitializeSubState()
    {

    }
}
