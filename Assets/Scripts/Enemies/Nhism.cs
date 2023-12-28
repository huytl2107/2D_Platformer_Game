using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nhism : WeakEnemiesMovement
{
    private void SetTagWeakEnemies()
    {
        gameObject.tag = "WeakEnemies";
    }
    private void SetUntagged()
    {
        gameObject.tag = "Untagged";
    }
}
