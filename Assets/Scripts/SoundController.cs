using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource _sound;
    private void Awake()
    {
        _sound = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        StartCoroutine(PlayAndDisable());
    }

    private IEnumerator PlayAndDisable()
    {
        _sound.PlayOneShot(_sound.clip);
        yield return new WaitForSeconds(_sound.clip.length);
        gameObject.SetActive(false);
    }
}
