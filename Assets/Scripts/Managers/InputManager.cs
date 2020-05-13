using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;
    public bool controller_mode = false;
    // Controller controls

    public KeyCode left = KeyCode.JoystickButton14;
    public KeyCode right = KeyCode.JoystickButton15;
    public KeyCode up = KeyCode.JoystickButton12;
    public KeyCode down = KeyCode.JoystickButton13;
    public KeyCode rot_c = KeyCode.JoystickButton6;
    public KeyCode rot_a = KeyCode.JoystickButton7;
    public KeyCode reset = KeyCode.JoystickButton3;
    public KeyCode action = KeyCode.JoystickButton1;
    public KeyCode exit = KeyCode.JoystickButton0;
    public KeyCode cheat = KeyCode.JoystickButton4;

    // Keyboard controls
    /*
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public KeyCode rot_c = KeyCode.Q;
    public KeyCode rot_a = KeyCode.E;
    public KeyCode pause = KeyCode.Escape; */

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        string[] names = Input.GetJoystickNames();
        foreach (string name in names)
        {
            if (name.Length == 19)
            {
                controller_mode = true;
            }
        }

        if (!controller_mode)
        {
            left = KeyCode.A;
            right = KeyCode.D;
            up = KeyCode.W;
            down = KeyCode.S;
            rot_c = KeyCode.Q;
            rot_a = KeyCode.E;
            reset = KeyCode.Escape;
            exit = KeyCode.R;
            action = KeyCode.Space;
            cheat = KeyCode.F10;
        }
    }

}
