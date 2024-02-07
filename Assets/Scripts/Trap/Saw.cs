using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    void Start()
    {
        SoundManager.Instant.PlaySound(GameEnum.ESound.sawSound, transform.position);
    }
}
