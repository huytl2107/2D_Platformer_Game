using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    private Animator anim;
    private Collider2D col;
    [SerializeField] private float waitTime = 1f;
    [SerializeField] private float firstDelay = 0;
    private bool isChanged = false;
    private bool isCalled = false;
    
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(!isCalled)
        {
            Invoke("On", firstDelay);
            isCalled = true;
        }
    }
    private void On()
    {
        if(!isChanged)
        {
        isChanged = true;
        anim.SetBool("State", true);
        col.isTrigger = true;
        Invoke("Off", waitTime);
        Debug.Log("On");
        }
    }
    private void Off()
    {
        if(isChanged)
        {
        isChanged = false;
        anim.SetBool("State", false);
        col.isTrigger = false;
        Invoke("On", waitTime);
        Debug.Log("Off");
        }
    }

}
