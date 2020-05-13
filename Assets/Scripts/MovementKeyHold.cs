using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// Script for tracking how long movement key buttons are held
public class MovementKeyHold : MonoBehaviour
{
    public float left_held_duration;
    public float right_held_duration;
    public float up_held_duration;
    public float down_held_duration;
    public float left_held_start;
    public float right_held_start;
    public float up_held_start;
    public float down_held_start;

    public bool right_pressed = false;
    public bool left_pressed = false;
    public bool up_pressed = false;
    public bool down_pressed = false;

    public bool right_key_down = false;
    public bool left_key_down = false;
    public bool up_key_down = false;
    public bool down_key_down = false;

    private CameraController c;
    private PlayerMovement player_move;

    void Start()
    {
        player_move = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>();
        c = Camera.main.GetComponent<CameraController>();
    }

    float Truncate(float value)
    {
        double mult = Math.Pow(10.0, 1);
        double result = Math.Truncate(mult * value) / mult;
        return (float)result;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") == 1 && !right_pressed)
        {
            right_pressed = true;
            right_held_start = Time.time;
            right_key_down = true;

            if (player_move.enabled == true)
            {
                if (player_move.allowInput)
                {
                    player_move.Right();
                    player_move.MovementCoroutine();
                }
            }
            
        }
        if (Input.GetAxis("Horizontal") == 1 && right_pressed)
        {
            right_held_duration = Time.time - right_held_start;
            right_key_down = false;
        }
        if (Input.GetAxis("Horizontal") != 1)
        {
            right_pressed = false;
            right_held_duration = 0f;
        }

        if (Input.GetAxis("Horizontal") == -1 && !left_pressed)
        {
            left_pressed = true;
            left_held_start = Time.time;
            left_key_down = true;

            if (player_move.enabled == true)
            {
                if (player_move.allowInput)
                {
                    player_move.Left();
                    player_move.MovementCoroutine();
                }
            }
        }
        if (Input.GetAxis("Horizontal") == -1 && left_pressed)
        {
            left_held_duration = Time.time - left_held_start;
            left_key_down = false;
        }
        if (Input.GetAxis("Horizontal") != -1)
        {
            left_pressed = false;
            left_held_duration = 0f;
        }

        if (Input.GetAxis("Vertical") == 1 && !up_pressed)
        {
            up_pressed = true;
            up_held_start = Time.time;
            up_key_down = true;

            if (player_move.enabled == true)
            {
                if (player_move.allowInput)
                {
                    player_move.Up();
                    player_move.MovementCoroutine();
                }
            }
        }
        if (Input.GetAxis("Vertical") == 1 && up_pressed)
        {
            up_held_duration = Time.time - up_held_start;
            up_key_down = false;
        }
        if (Input.GetAxis("Vertical") != 1)
        {
            up_pressed = false;
            up_held_duration = 0f;
        }

        if (Input.GetAxis("Vertical") == -1 && !down_pressed)
        {
            down_pressed = true;
            down_held_start = Time.time;
            down_key_down = true;

            if (player_move.enabled == true)
            {
                if (player_move.allowInput)
                {
                    player_move.Down();
                    player_move.MovementCoroutine();
                }
            }
        }
        if (Input.GetAxis("Vertical") == -1 && down_pressed)
        {
            down_held_duration = Time.time - down_held_start;
            down_key_down = false;
        }
        if (Input.GetAxis("Vertical") != -1)
        {
            down_pressed = false;
            down_held_duration = 0f;
        }

        if (Input.GetKeyDown(InputManager.instance.up))
        {
            up_held_start = Time.time;
        }
        if (Input.GetKey(InputManager.instance.up))
        {
            up_held_duration = Truncate(Time.time - up_held_start);
        }
        if (Input.GetKeyUp(InputManager.instance.up))
        {
            up_held_duration = 0f;
        }

        if (Input.GetKeyDown(InputManager.instance.down))
        {
            down_held_start = Time.time;
        }
        if (Input.GetKey(InputManager.instance.down))
        {
            down_held_duration = Truncate(Time.time - down_held_start);
        }
        if (Input.GetKeyUp(InputManager.instance.down))
        {
            down_held_duration = 0f;
        }

        if (Input.GetKeyDown(InputManager.instance.left))
        {
            left_held_start = Time.time;
        }
        if (Input.GetKey(InputManager.instance.left))
        {
            left_held_duration = Truncate(Time.time - left_held_start);
        }
        if (Input.GetKeyUp(InputManager.instance.left))
        {
            left_held_duration = 0f;
        }

        if (Input.GetKeyDown(InputManager.instance.right))
        {
            right_held_start = Time.time;
        }
        if (Input.GetKey(InputManager.instance.right))
        {
            right_held_duration = Truncate(Time.time - right_held_start);
        }
        if (Input.GetKeyUp(InputManager.instance.right))
        {
            right_held_duration = 0f;
        }
    }
}
