using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool
{
    public static BulletPool Instance;
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}

