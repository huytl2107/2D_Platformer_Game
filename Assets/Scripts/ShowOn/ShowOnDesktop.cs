using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnDesktop : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(!Application.isMobilePlatform);
    }
}
