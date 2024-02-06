using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSlideController : MonoBehaviour
{
    private Slider _volumeSlider;

    private void Start()
    {
        _volumeSlider = GetComponent<Slider>();
    }

    public void ChangeMusicVolume()
    {
        if(_volumeSlider != null) //CheckNull
            SoundManager.Instant.ChangeMusicVolume(_volumeSlider.value);
    }
}
