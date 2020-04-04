using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero_projectile : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        transform.localScale = player.transform.localScale;


        if (player.transform.localScale.x == -1)
        {

            rb.velocity = transform.right * -1 * speed;

        }

        if (player.transform.localScale.x == 1)
        {

            rb.velocity = transform.right * speed;

        }

    }



    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Ground" || other.tag == "enemy" || other.tag == "Melee_Enemy_touch" || other.tag =="Range_Enemy_touch" || other.tag == "vines" || other.tag == "opaque" || other.tag == "non-climb")
        {
            Destroy(gameObject);
        }


    }

        // Update is called once per frame
        void Update()
    {
        
    }
}
