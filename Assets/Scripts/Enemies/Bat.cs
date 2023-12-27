using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Bee
{
    [SerializeField] private GameObject nest;
    private bool setanimCellingOut = false;
    private bool setanimCellingIn = false;
    private enum state{idle, cellingOUT, flying, cellingIN};
    private SpriteRenderer sprite;
    private bool flip = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        leftRaycast.RaycastCheck();
        rightRaycast.RaycastCheck();
        sprite.flipX = flip;
        if(leftRaycast.seePlayer || rightRaycast.seePlayer && !seenPlayer)
        {
            seenPlayer = true;
            Invoke("NotSeeingPlayer",5f);
        }
        if(seenPlayer)
        {
            if(!setanimCellingOut)
            {
                setanimCellingOut = true;
                anim.SetInteger("State", (int)state.cellingOUT);
            }
            Invoke("Flying", 1f);
            if(transform.position.x - player.transform.position.x < 0) 
            {flip = true;}
            else {flip = false;}
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, nest.transform.position, Time.deltaTime * speed);
            if((Vector2.Distance(transform.position, nest.transform.position) < .1f) && !setanimCellingIn)
            {
                setanimCellingIn = true;
                anim.SetInteger("State", (int)state.cellingIN);
            }
            if(transform.position.x - nest.transform.position.x < 0) 
            {flip = true;}
            else {flip = false;}
        }
    }
    private void setFlying()
    {
        setanimCellingIn = false;
        anim.SetInteger("State", (int)state.flying);
    }
    private void setIdle()
    {
        setanimCellingOut = false;
        anim.SetInteger("State", (int)state.idle);
    }
    private void Flying()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * speed);
    }
}
