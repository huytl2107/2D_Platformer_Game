using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

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
        //Trừ máu Player ngay khi vào GotHitState rồi mới check If Else
        UIManager.Instant.GotHit();
        if (UIManager.Instant.PlayerHealth >= 0)
        {
            SoundManager.Instant.PlaySound(GameEnum.ESound.gotHit);
            //Transition từ AnyState, tắt Can transition to self để không treo ở frame đàu.
            player.Anim.SetBool("GotHit", true);
            player.Rb.velocity = new Vector2(0f,0f);
            player.Rb.gravityScale = 12f;
            player.Rb.AddForce(Vector2.up * player.JumpForce/1.5f, ForceMode2D.Impulse);
            player.StartCoroutine(GotHit());
            UIManager.Instant.UpdatePlayerHealthUI();
        }
        else
        {
            player.tag = "Untagged";
            SoundManager.Instant.PlaySound(GameEnum.ESound.deathSound);
            player.Anim.SetTrigger("Death");
            player.Col.isTrigger = true;
            player.Rb.bodyType = RigidbodyType2D.Static;
            player.StartCoroutine(Death());
        }
    }

    public override void UpdateState()
    {
        CheckSwitchState();
        player.Rb.velocity = new Vector2(player.GotHitDirX * player.Speed, player.Rb.velocity.y);
    }


    public override void CheckSwitchState()
    {
        if (!IsGottingHit && UIManager.Instant.PlayerHealth >= 0)
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
        //Chờ 1s rồi restart level
        yield return new WaitForSeconds(1f);
        player.Col.enabled = false;
        //Bỏ cái này đi nếu k sẽ bug UI
        //UIManager.Instant.PlayerHealth = 3;
        UIManager.Instant.PopUpLosePanel();
    }

    public override void ExitState()
    {
        player.Rb.gravityScale = 9f;
    }

    public override void FixedUpdateState()
    {

    }
}
