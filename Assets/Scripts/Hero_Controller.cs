using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Hero_Controller : MonoBehaviour
{
    public bool grounded;
    private Rigidbody2D player_Rigidbody2D;
    public CircleCollider2D ground_collider;
    public Transform groundcheck;
    public Transform vinecheck;
    public LayerMask groundlayer;
    public LayerMask vineslayer;
    public float jump_speed = 2;
    public float jumpcoe = 0.75f;
    public float sprint_speed = 2;
    public GameObject attack_hitbox;
    public GameObject attack_hitbox_special;
    public Animator anim;
    public BoxCollider2D player_hitbox;
    public Transform firepoint_1;
    public Transform firepoint_2;
    public Transform firepoint_3;
    public GameObject hero_projectile;
    public int hero_max_mana = 100;
    public int hero_current_mana;
    public float midair_movement;
    public bool wallclimbing;
    public List<int> shotpattern_1;
    public List<int> shotpattern_2;
    public List<int> shotpattern_3;
    
    public Slider staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        hero_current_mana = hero_max_mana;
        staminaBar.maxValue = hero_max_mana;
        
        anim = GetComponent<Animator>();
        player_Rigidbody2D = GetComponent<Rigidbody2D>();
        ground_collider = GetComponent<CircleCollider2D>();

        shotpattern_1 = new List<int> { 1, 2, 3 };
        shotpattern_2 = new List<int> { 3, 2, 1 };
        shotpattern_3 = new List<int> { 3, 1 };
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

        staminaBar.value = hero_current_mana;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, 0.15f, groundlayer);
        if (grounded == true) { wallclimbing = false; }
        wallclimbing = Physics2D.OverlapCircle(vinecheck.position, 0.15f, vineslayer);
    }


    public void attack(bool is_sprinting, bool special_active)
    {

        if (grounded == true && special_active == false)
        {
            Debug.Log("you attacked");
            StartCoroutine(AttackDuration_ground());
        }

        if (grounded == false && is_sprinting == false)
        {
            StartCoroutine(AttackDuration_air());
        }


        if (special_active == true && hero_current_mana > 0)
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
        StartCoroutine(shoot(shotpattern_1, 0.15f));
        StartCoroutine(shoot(shotpattern_2, 0.30f));
        StartCoroutine(shoot(shotpattern_3, 0.75f));
        yield return new WaitForSeconds(1);
        Debug.Log("attack ended");
        attack_hitbox_special.SetActive(false);
    }

    IEnumerator shoot(List<int> shots_fired, float time_to_wait)
    {
        yield return new WaitForSeconds(time_to_wait);
        if (hero_current_mana > 0)
        {
            foreach (int element in shots_fired)
            {
                Debug.Log(element);
                if (element == 1)
                {
                    Instantiate(hero_projectile, firepoint_1.position, firepoint_1.rotation);
                    hero_current_mana--;
                }

                if (element == 2)
                {
                    Instantiate(hero_projectile, firepoint_2.position, firepoint_2.rotation);
                    hero_current_mana--;
                }

                if (element == 3)
                {
                    Instantiate(hero_projectile, firepoint_3.position, firepoint_3.rotation);
                    hero_current_mana--;
                }

                hero_current_mana--;
            }          
        }
    }


    public void Move(float dir, float speed, bool is_sprinting)
    {

        if (grounded == true)
        {

            if (is_sprinting == true)
            {
                float speed_calc = ((dir * speed)); //* sprint_speed;
                player_Rigidbody2D.velocity = new Vector2(speed_calc, player_Rigidbody2D.velocity.y);
            }

            if (is_sprinting == false)
            {
                //move the character in the move direction (-1 or 1)
                float speed_calc = (dir * speed);
                player_Rigidbody2D.velocity = new Vector2(speed_calc, player_Rigidbody2D.velocity.y);
            }

        }
        
        if (grounded ==false)
        {

            if (is_sprinting == true)
            {
                float speed_calc = ((dir * speed)); //* sprint_speed;
                player_Rigidbody2D.velocity = new Vector2(speed_calc * midair_movement, player_Rigidbody2D.velocity.y);
            }

            if (is_sprinting == false)
            {
                //move the character in the move direction (-1 or 1)
                float speed_calc = (dir * speed);
                player_Rigidbody2D.velocity = new Vector2(speed_calc * midair_movement, player_Rigidbody2D.velocity.y);
            }
        }

    }





    public void Jump(bool is_sprinting)
    {

        if (wallclimbing == true)
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


                player_Rigidbody2D.velocity = new Vector2(calc_jump_speed_x *2, calc_jump_speed_y * 2);
                return;
            }
            if (is_sprinting == true)
            {
                grounded = false;

                float x = player_Rigidbody2D.velocity.x;
                float x2 = Mathf.Abs(x);

                float x3 = x2 * (jumpcoe * 1.25f);
                float x4 = x * (jumpcoe * 1.25f);

                float calc_jump_speed_y = jump_speed + x3;
                float calc_jump_speed_x = x + x4;

                player_Rigidbody2D.velocity = new Vector2(calc_jump_speed_x *2, calc_jump_speed_y * 2);
                return;
            }

        }






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

                float x3 = x2 * (jumpcoe *1.25f);
                float x4 = x * (jumpcoe *1.25f);

                float calc_jump_speed_y = jump_speed + x3;
                float calc_jump_speed_x = x + x4;

                player_Rigidbody2D.velocity = new Vector2(calc_jump_speed_x, calc_jump_speed_y);
                return;
            }


        }

        else return;

    }

}
