using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Controller : MonoBehaviour
{
    [SerializeField] private float m_MaxSpeed = 10f;
    public bool grounded;
    private Rigidbody2D player_Rigidbody2D;
    public CircleCollider2D ground_collider;
    public Transform groundcheck;
    public LayerMask groundlayer;
    public float jump_speed = 2;
    public float jumpcoe = 0.75f;
    public float sprint_speed = 2;
    public GameObject attack_hitbox;
    public GameObject attack_hitbox_special;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player_Rigidbody2D = GetComponent<Rigidbody2D>();
        ground_collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded == true)
        {
            anim.ResetTrigger("attack_air");
        }

        if (grounded == false)
        {
            anim.ResetTrigger("attack_special");
            anim.ResetTrigger("attack");
        }
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, 0.15f, groundlayer);
    }


    public void attack(bool is_sprinting)
    {

        if (grounded == true && is_sprinting == false)
        {
            Debug.Log("you attacked");
            StartCoroutine(AttackDuration_ground());
        }

        if (grounded == false && is_sprinting == false)
        {
            StartCoroutine(AttackDuration_air());
        }


        if (is_sprinting == true && grounded == true)
        {
            StartCoroutine(AttackDuration_special());
        }

    }

    IEnumerator AttackDuration_ground()
    {
        anim.SetTrigger("attack");
        Debug.Log("attack start");
        attack_hitbox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("attack ended");
        attack_hitbox.SetActive(false);
    }

    IEnumerator AttackDuration_air()
    {
        anim.SetTrigger("attack_air");
        Debug.Log("attack start");
        attack_hitbox.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("attack ended");
        attack_hitbox.SetActive(false);
    }

    IEnumerator AttackDuration_special()
    {
        anim.SetTrigger("attack_special");
        Debug.Log("attack start");
        attack_hitbox_special.SetActive(true);
        yield return new WaitForSeconds(1);
        Debug.Log("attack ended");
        attack_hitbox_special.SetActive(false);
    }

    public void Move(float dir, float speed, bool is_sprinting)
    {

        if (is_sprinting == true)
        {
            float speed_calc = ((dir * speed) / 10) * sprint_speed;
            player_Rigidbody2D.velocity = new Vector2(speed_calc, player_Rigidbody2D.velocity.y);
        }

        if (is_sprinting == false)
        {
            //move the character in the move direction (-1 or 1)
            float speed_calc = (dir * speed) / 10;
            player_Rigidbody2D.velocity = new Vector2(speed_calc, player_Rigidbody2D.velocity.y);
        }

        

    }


    public void Jump(bool is_sprinting)
    {
        if (grounded == true)
        {

            if (is_sprinting == false)
            {

                grounded = false;

                float x = player_Rigidbody2D.velocity.x;
                float x2 = Mathf.Abs(x);

                float x3 = x2 * jumpcoe;
                float x4 = x * jumpcoe;

                float calc_jump_speed_y = jump_speed + x3;
                float calc_jump_speed_x = x + x4;


                player_Rigidbody2D.velocity = new Vector2(calc_jump_speed_x, calc_jump_speed_y);
                return;
            }

            if (is_sprinting == true)
            {
                grounded = false;

                float x = player_Rigidbody2D.velocity.x;
                float x2 = Mathf.Abs(x);

                float x3 = x2 * (jumpcoe) * 0.5f;
                float x4 = x * (jumpcoe) * 5.5f;

                float calc_jump_speed_y = jump_speed + x3;
                float calc_jump_speed_x = x + x4;

                player_Rigidbody2D.velocity = new Vector2(calc_jump_speed_x, calc_jump_speed_y);
                return;
            }


        }

    }

}
