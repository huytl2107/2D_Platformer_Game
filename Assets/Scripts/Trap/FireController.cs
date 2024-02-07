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
        StartCoroutine(AwakeFire());
    }

    private IEnumerator AwakeFire()
    {
        yield return new WaitForSeconds(_delay);
        StartCoroutine(On());
    }

    private IEnumerator On()
    {
        SoundManager.Instant.PlaySound(GameEnum.ESound.fireTrapSound, transform.position);
        anim.SetBool("State", true);
        gameObject.tag = "Trap";
        yield return new WaitForSeconds(_coolDown);
        StartCoroutine(Off());
    }
    private IEnumerator Off()
    {
        anim.SetBool("State", false);
        gameObject.tag = "Untagged";
        yield return new WaitForSeconds(_coolDown);
        StartCoroutine(On());
    }

}
