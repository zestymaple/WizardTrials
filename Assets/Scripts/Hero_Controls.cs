﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Controls : MonoBehaviour
{
    public Hero_Controller controller;
    public float moving_speed = 0;
    public float max_speed = 5;
    public float max_speed_sprint = 10;
    public bool moving_right;
    public bool moving_left;
    public bool grounded;
    public enum State {left, right, idle, jumping, crouching};
    public State current_state = State.idle;
    private readonly int right_transition = 1;
    private readonly int left_transition = 2;
    private readonly int go_right = 3;
    private readonly int go_left = 4;
    private readonly int go_idle = 5;
    private readonly int left_direction = -1;
    private readonly int right_direction = 1;
    public bool is_sprinting;
    public Animator anim;
    private Rigidbody2D player_Rigidbody2D;
    public Player_getshit playerhit;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player_Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerhit.on_cooldown == false)

        {

            readInput();
            //is_sprinting = false;



            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("is_walk", false);
                anim.SetBool("is_sprint", true);
                is_sprinting = true;
            }


            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetBool("is_sprint", false);
                is_sprinting = false;
            }

            //Call Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("jump_pressed");
                controller.Jump(is_sprinting);
            }

            //call attack
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {

                //anim.Play("normal_attack");

                controller.attack(is_sprinting);


            }

            //Moving Right STATE
            if (current_state == State.right)
            {
                Vector3 flip_dir = transform.localScale;
                flip_dir.x = 1;
                transform.localScale = flip_dir;

                //ascending
                if (player_Rigidbody2D.velocity.y > 0)
                {
                    anim.SetBool("descending", false);
                    anim.SetBool("ascending", true);
                }

                //descending
                if (player_Rigidbody2D.velocity.y < 0)
                {
                    anim.SetBool("ascending", false);
                    anim.SetBool("descending", true);
                }

                if (player_Rigidbody2D.velocity.y == 0)
                {
                    anim.SetBool("ascending", false);
                    anim.SetBool("descending", false);
                    anim.SetBool("is_idle", false);
                    anim.SetBool("is_walk", true);
                }


                //adjust moving speed
                if (moving_speed <= max_speed && is_sprinting == false)
                {
                    moving_speed++;
                }

                //adjust moving speed
                if (moving_speed <= max_speed_sprint && is_sprinting == true)
                {
                    moving_speed++;
                }


                //call move method
                controller.Move(right_direction, moving_speed, is_sprinting);
            }

            //Moving Left STATE
            if (current_state == State.left)
            {
                Vector3 flip_dir = transform.localScale;
                flip_dir.x = -1;
                transform.localScale = flip_dir;

                //ascending
                if (player_Rigidbody2D.velocity.y > 0)
                {
                    anim.SetBool("descending", false);
                    anim.SetBool("ascending", true);
                }

                //descending
                if (player_Rigidbody2D.velocity.y < 0)
                {
                    anim.SetBool("ascending", false);
                    anim.SetBool("descending", true);
                }

                if (player_Rigidbody2D.velocity.y == 0)
                {
                    anim.SetBool("ascending", false);
                    anim.SetBool("descending", false);
                    anim.SetBool("is_idle", false);
                    anim.SetBool("is_walk", true);
                }


    
                //adjust moving speed
                if (moving_speed <= max_speed && is_sprinting == false)
                {
                    moving_speed++;
                }

                //adjust moving speed
                if (moving_speed <= max_speed_sprint && is_sprinting == true)
                {
                    moving_speed++;
                }

                //call move method
                controller.Move(left_direction, moving_speed, is_sprinting);
            }

            if (current_state == State.idle)
            {

                //ascending
                if (player_Rigidbody2D.velocity.y > 0)
                {
                    anim.SetBool("descending", false);
                    anim.SetBool("ascending", true);
                }

                //descending
                if (player_Rigidbody2D.velocity.y < 0)
                {
                    anim.SetBool("ascending", false);
                    anim.SetBool("descending", true);
                }


                if (player_Rigidbody2D.velocity.y == 0)
                {
                    anim.SetBool("ascending", false);
                    anim.SetBool("descending", false);
                    anim.SetBool("is_idle", false);
                    anim.SetBool("is_walk", false);
                }

                anim.SetBool("is_walk", false);
                anim.SetBool("is_sprint", false);
                anim.SetBool("is_idle", true);
                moving_speed = 0;
                return;
            }

        }

        else return;

    }

    public bool readInput()
    {
        


        //ENTER RIGHT STATE
        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.A)))
        {

        
            if (current_state == State.left)
            {
                stateHandler(right_transition);
                return true;
            }
            stateHandler(go_right);
            return true;
        }

        //ENTER LEFT STATE
        if (Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.D)))
        {
            if (current_state == State.right)
            {
                stateHandler(left_transition);
                return true;
            }
            stateHandler(go_left);
            return true;
        }






        //no left or right movement key pressed = we do nothing
        stateHandler(go_idle);
        return false;
    }

    public void stateHandler(int x)
    {
       switch (x)
        {
            case 1: //Transition right
                moving_speed = 0;
                current_state = State.right;
                break;
            case 2: //Transition left
                moving_speed = 0;
                current_state = State.left;
                break;
            case 3:
                current_state = State.right;
                break;
            case 4:
                current_state = State.left;
                break;
            case 5:
                current_state = State.idle;
                break;
        }
    }




    public void animHandler(int x)
    {
        switch (x)
        {
            case 1: //idle
                moving_speed = 0;
                current_state = State.right;
                break;
            case 2: //walk
                moving_speed = 0;
                current_state = State.left;
                break;
            case 3: //sprint
                current_state = State.right;
                break;
            case 4:
                current_state = State.left;
                break;
            case 5:
                current_state = State.idle;
                break;
        }
    }

}
