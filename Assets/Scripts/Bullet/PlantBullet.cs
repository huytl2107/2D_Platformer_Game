using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBullet : BulletController, IPieceBulletSpawn
{
    public override void SpawnPiece()
    {
        EffectPooler.Instant.GetPoolObject("PlantPiece", transform.position, _isRight ? Quaternion.Euler(0,0,0) : Quaternion.Euler(0,-180,0));
    }
}
