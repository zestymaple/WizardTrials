﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Controls : MonoBehaviour
{
    public Hero_Controller controller;
    public float moving_speed = 0;
    public float max_speed = 5;
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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        readInput();
        is_sprinting = false;
        //Call Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Jump(is_sprinting);           
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            is_sprinting = true;
        }

        //Moving Right STATE
        if (current_state == State.right)
        {
            //adjust moving speed
            if (moving_speed <= max_speed)
            {
                moving_speed++;
            }           
            //call move method
            controller.Move(right_direction ,moving_speed, is_sprinting);
        }

        //Moving Left STATE
        if (current_state == State.left)
        {

            //adjust moving speed
            if (moving_speed <= max_speed)
            {
                moving_speed++;
            }
            //call move method
            controller.Move(left_direction, moving_speed, is_sprinting);
        }

        if (current_state == State.idle)
        {
            moving_speed = 0;
            return;
        }


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

}
