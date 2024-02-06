using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyFans : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instant.PlaySound(GameEnum.ESound.fanSound, transform.position);
    }
}
