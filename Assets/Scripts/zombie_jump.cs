using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_jump : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public bool testbool;
    public bool testbool2;
    public left_right_zombie playdir;
    public float jumpspeed;
    public float movespeed;
    public float movetimer;
    public bool cooldown;
    public float freezetime;
    public float max_range;
    // Start is called before the first frame update
    void Start()
    {
 
        playdir = GetComponent<left_right_zombie>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //rb.velocity = transform.right * movespeed * 5 * -1;
        // InvokeRepeating("move", 0f, movetimer);
        InvokeRepeating("jump", 5f, movetimer + 1);
    }

    // Update is called once per frame
    void Update()
    {        
        move();
        if (playdir.dirNum == 1)
        {
            Vector3 flip_dir = transform.localScale;
            flip_dir.x = -1;
            transform.localScale = flip_dir;
        }

        if (playdir.dirNum == -1)
        {
            Vector3 flip_dir = transform.localScale;
            flip_dir.x = 1;
            transform.localScale = flip_dir;
        }
        if (Vector2.Distance(transform.position, player.position) > max_range)
        {
            Destroy(this.gameObject);
        }

        if (testbool)
        {
            kill();
        }

        
        if (Vector2.Distance(transform.position, player.position) >= max_range)
        {
            kill();
        }

    }

    void move()
    {
        rb.velocity = new Vector2(movespeed * playdir.dirNum, rb.velocity.y);
    }

    void jump()
    {
        rb.velocity = new Vector2(playdir.dirNum * jumpspeed, 5);
    }


    void kill()
    {
        Destroy(gameObject);
    }

}
