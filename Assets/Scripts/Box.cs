using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Animator _anim;
    private Rigidbody2D _rb;

    private enum State{idle, hit}
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            _anim.SetInteger("State", (int)State.hit);
            _rb.bodyType = RigidbodyType2D.Dynamic;
            _rb.AddForce(Vector2.up * 3f);
        } 
    }

    private void CreateEffectAndDestroy()
    {
        EffectPooler.Instant.GetPoolObject("BoxPiece", transform.position, Quaternion.identity);
        SoundManager.Instant.PlaySound(GameEnum.ESound.boxCracked);
        Destroy(gameObject);
    }
}
