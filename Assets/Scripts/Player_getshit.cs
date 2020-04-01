﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_getshit : MonoBehaviour
{
    public Animator anim;
    public int hits_taken;
    public Rigidbody2D playerbod;
    public float knockdur; //how long knocked back
    public Vector2 knockback_dir; //direction of knock back
    public float knockbackpower; //how far you get knocked back
    public Transform player;
    public bool on_cooldown;
    // Start is called before the first frame update
    void Start()
    {
 
    }


    void get_hit()
    {
        anim.SetTrigger("get_hit");
        StartCoroutine(knockback());
        StartCoroutine(cooldown(0.75f));
    }

    IEnumerator cooldown(float waitTime)
    {
        anim.SetBool("get_hitbool", true);
        on_cooldown = true;
        yield return new WaitForSeconds(waitTime);
        on_cooldown = false;
        anim.SetBool("get_hitbool", false);
    }


    public IEnumerator knockback()
    {
        float timer = 0;
        knockback_dir.x = player.transform.position.x;
        knockback_dir.y = player.transform.position.y;
        while (knockdur > timer)
        {


            float x = 0;
            float y = 0;
            float xbase =0;
            float ybase =0;
            timer += Time.deltaTime;

            //ifx positive
            if (Mathf.Sign(playerbod.velocity.x) == 1)
            {
                x = -1;
                xbase = -1.5f;
            }

            //ifx negative
            if (Mathf.Sign(playerbod.velocity.x) == -1)
            {
                x = -1;
                xbase = 1.5f;
            }

            //ify positive
            if (Mathf.Sign(playerbod.velocity.y) == 1)
            {
                y = -1;
                ybase = -1.5f;
            }

            //ify negative
            if (Mathf.Sign(playerbod.velocity.y) == -1)
            {
                y = -1;
                ybase = 1.5f;
            }

            playerbod.AddForce(new Vector2(xbase + playerbod.velocity.x * x * 2, ybase + playerbod.velocity.y * y * 2));
            //playerbod.AddForce(new Vector2(knockback_dir.x * -1, knockback_dir.y * -1));

        }
        

        yield return 0;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Melee_Enemy_1")
        {
            get_hit();
            Debug.Log("Melee_Enemy_1 did melee damage");
            hits_taken += 1;
        }


        if (other.tag == "Melee_Enemy_touch")
        {
            get_hit();
            Debug.Log("Melee_Enemy_1 touched player");
            hits_taken += 1;
        }


        if (other.tag == "Range_Enemy_1")
        {
            get_hit();
            Debug.Log("Range_enemy_1 projectile hit");
            hits_taken += 1;
        }

        if (other.tag == "Range_Enemy_touch")
        {
            get_hit();
            Debug.Log("Range_enemy_1 touched player");
            hits_taken += 1;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
