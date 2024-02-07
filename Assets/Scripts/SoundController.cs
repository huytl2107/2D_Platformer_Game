using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource _sound;
    [SerializeField] private float _lifeTime = 0f;
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
        if(_lifeTime == 0f)
        {
            yield return new WaitForSeconds(_sound.clip.length);
        }
        else
        {
            yield return new WaitForSeconds(_lifeTime);
        }
        gameObject.SetActive(false);
    }
}
