using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    private Animator anim;
    private Collider2D col;
    [SerializeField] private float _delay = 0;
    [SerializeField] private float _coolDown = 1.5f;
    
    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        StartCoroutine(On());
    }

    private IEnumerator AwakeFire()
    {
        yield return new WaitForSeconds(_delay);
        StartCoroutine(On());
    }

    private IEnumerator On()
    {
        yield return new WaitForSeconds(_coolDown);
        anim.SetBool("State", true);
        gameObject.tag = "Trap";
        StartCoroutine(Off());
    }
    private IEnumerator Off()
    {
        yield return new WaitForSeconds(_coolDown);
        anim.SetBool("State", false);
        gameObject.tag = "Untagged";
        StartCoroutine(On());
    }

}
