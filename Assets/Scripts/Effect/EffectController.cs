using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    private ParticleSystem _effect;
    [SerializeField] private float _lifeTime = 1f;
    void Awake()
    {
        _effect = GetComponentInChildren<ParticleSystem>();
    }
    
    public void OnEnable() 
    {
        _effect.Play();
        Invoke("DisableObject", _lifeTime);
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
