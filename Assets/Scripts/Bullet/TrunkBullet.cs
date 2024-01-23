using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBullet : BulletController, IPieceBulletSpawn
{
    public override void SpawnPiece()
    {
        EffectPooler.Instant.GetPoolObject("TrunkPiece", transform.position, _isRight ? Quaternion.Euler(0,0,0) : Quaternion.Euler(0,-180,0));
    }
}
