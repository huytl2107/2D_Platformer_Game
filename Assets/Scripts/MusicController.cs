using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource _music;
    private void Awake()
    {
        _music = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _music.Play();
    }
}
