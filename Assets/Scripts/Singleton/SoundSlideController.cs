using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlideController : MonoBehaviour
{
    private Slider _volumeSlider;

    private void Start()
    {
        _volumeSlider = GetComponent<Slider>();
    }

    public void ChangeSoundVolume()
    {
        SoundManager.Instant.ChangeSoundVolume(_volumeSlider.value);
    }

    public void ChangeMusicVolume()
    {
        SoundManager.Instant.ChangeMusicVolume(_volumeSlider.value);
    }
}
