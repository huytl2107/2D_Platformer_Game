using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiPool : ObjectPool
{
    public static KunaiPool Instance;
    protected void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
