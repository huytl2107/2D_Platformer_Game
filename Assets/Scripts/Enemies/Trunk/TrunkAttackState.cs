using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkAttackState : EnemiesAttackState
{
    private bool _seenPlayer = false;
    public TrunkAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }
    private bool _switched = false;
    public override void EnterState()
    {
        base.EnterState();
        enemy.Rb.velocity = new Vector2(0f, 0f);
        if (enemy.IsGrounded())
        {
            enemy.Rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
        }
        enemy.Anim.SetInteger("State", (int)StateEnum.ETrunkState.attack);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        enemy.Rb.velocity = new Vector2(-enemy.WalkSpeed * 1.5f * enemy.RaycastDirX, enemy.Rb.velocity.y);
        if (!_switched)
        {
            enemy.StartCoroutine(AnimCoolDown());
        }
        if (enemy.SeePlayer)
        {
            _seenPlayer = true;
            enemy.StopCoroutine(DelayBeforeSwitchState());
        }
        else
        {
            if (_seenPlayer)
            {
                enemy.StartCoroutine(DelayBeforeSwitchState());
            }
        }
    }

    public IEnumerator AnimCoolDown()
    {
        _switched = true;
        yield return new WaitForSeconds(.4f);
        enemy.Anim.SetInteger("State", (int)StateEnum.ETrunkState.coolDownAttack);
        yield return new WaitForSeconds(.6f);
        if (enemy.IsGrounded())
        {
            enemy.Rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
        }
        enemy.Anim.SetInteger("State", (int)StateEnum.ETrunkState.attack);
        _switched = false;
    }

    public IEnumerator DelayBeforeSwitchState()
    {
        yield return new WaitForSeconds(1.5f);
        _seenPlayer = false;
        SwitchState(factory.TrunkWalk());
    }
}
