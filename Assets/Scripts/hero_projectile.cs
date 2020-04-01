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
 


        if (player.transform.localScale.x == -1)
        {

            rb.velocity = transform.right * -1 * speed;

        }

        if (player.transform.localScale.x == 1)
        {

            rb.velocity = transform.right * speed;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
