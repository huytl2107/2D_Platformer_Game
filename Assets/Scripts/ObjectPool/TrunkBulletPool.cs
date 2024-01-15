using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkBulletPool : ObjectPool
{
    public static TrunkBulletPool Instance;
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
