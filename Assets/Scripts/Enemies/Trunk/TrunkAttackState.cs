using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkAttackState : EnemiesAttackState
{
    public TrunkAttackState(EnemiesStateManager currentContext, EnemiesStateFactory currentState) : base(currentContext, currentState)
    {
    }

    private float _lifeTime = 0;
    private float _animTime = 0;
    private bool _isShooted = false;

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
        enemy.Rb.velocity = new Vector2(-enemy.WalkSpeed * 1.5f * enemy.RaycastDirX, enemy.Rb.velocity.y);

        _animTime += Time.deltaTime;
        if(_animTime >= .4f && !_isShooted)
        {
            _isShooted = true;
            enemy.Anim.SetInteger("State", (int)StateEnum.ETrunkState.coolDownAttack);
        }
        if(_animTime >= 1f)
        {
            enemy.Rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
            enemy.Anim.SetInteger("State", (int)StateEnum.ETrunkState.attack);
            _animTime = 0;
            _isShooted = false;
        }
        if (enemy.SeePlayer)
        {
            _lifeTime = 0;
        }
        else
        {
            _lifeTime += Time.deltaTime;
        }
    }

    public override void CheckSwitchState()
    {
        base.CheckSwitchState();
        if(_lifeTime > 1.5f)
        {
            SwitchState(factory.TrunkWalk());
        }
    }
}