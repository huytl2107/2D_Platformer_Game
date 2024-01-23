using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    private ParticleSystem _effect;
    void Awake()
    {
        _effect = GetComponentInChildren<ParticleSystem>();
    }
    
    public void OnEnable() 
    {
        _effect.Play();
        Invoke("DisableObject", 1f);
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
