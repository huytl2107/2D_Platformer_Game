using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadishGotHitState : EnemiesGotHitState
{
    public RadishGotHitState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    Vector3 _pos;

    public override void EnterState()
    {
        SoundManager.Instant.PlaySound(GameEnum.ESound.enemyGotHit);
        _pos = new Vector2(enemy.transform.position.x, enemy.transform.position.y + 1f);
        enemy.Health -=1;
        if (enemy.Health < 0)
        {
            enemy.Anim.SetTrigger("Death");
            enemy.Rb.AddForce(Vector2.up * 4f, ForceMode2D.Impulse);
            enemy.EnemiesDeath();
        }
        else
        {
            EffectPooler.Instant.GetPoolObject("RadishPiece", _pos, Quaternion.identity);
            enemy.Anim.SetInteger("State", (int)StateEnum.ERadishState.gotHit);
            enemy.Rb.bodyType = RigidbodyType2D.Dynamic;
            enemy.StartCoroutine(SwitchToIdleState());
        }
    }

    public override void UpdateState()
    {

    }

    
    private IEnumerator SwitchToIdleState()
    {
        yield return new WaitForSeconds(1f);
        SwitchState(factory.RadishIdle());
    }
}
