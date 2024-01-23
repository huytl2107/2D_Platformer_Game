using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeBullet : BulletController, IPieceBulletSpawn
{
    public new void FixedUpdate()
    {
        rb.velocity = Vector2.down * speed;
    }

    public override void SpawnPiece()
    {
        EffectPooler.Instant.GetPoolObject("BeePiece", transform.position, _isRight ? Quaternion.Euler(0,0,0) : Quaternion.Euler(0,-180,0));
    }
}
