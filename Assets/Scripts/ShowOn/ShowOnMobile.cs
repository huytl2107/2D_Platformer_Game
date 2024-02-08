using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowOnMobile : MonoBehaviour
{
    void Awake()
    {
        gameObject.SetActive(Application.isMobilePlatform);
    }
}
