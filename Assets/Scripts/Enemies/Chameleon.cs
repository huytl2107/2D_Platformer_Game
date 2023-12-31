using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chameleon : StrongEnemiesMovement
{
    private bool called = false;
    private enum state{idle, running, attack};
    [SerializeField] GameObject player;
    [SerializeField] GameObject attackZone;
    private void Start()
    {
        base.Start();
        attackZone.SetActive(false);
    }
    private void Update()
    {
        if(!called)
        {
            SetAnimIdle();
            Invoke("SetAnimAttack", 6f);
            called = true;
        }
    }
    private void SetAnimIdle()
    {
        anim.SetInteger("State",(int)state.idle);
        Invoke("SetAnimRunning", 4f);
    }
    private void SetAnimRunning()
    {
        anim.SetInteger("State", (int)state.running);
        Invoke("SetAnimIdle", 4f);
        Running();
    }
    private void SetAnimAttack()
    {
        anim.SetInteger("State", (int)state.attack);
        Invoke("SetAnimAttack", 6f);
    }
    private void returnIdle()
    {
        anim.SetInteger("State", (int)state.idle);
    }
    private void EnableAttackZone()
    {
        attackZone.SetActive(true);
    }
    private void DisableAttackZone()
    {
        attackZone.SetActive(false);
    }
}