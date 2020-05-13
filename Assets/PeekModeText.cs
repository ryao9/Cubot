using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeekModeText : MonoBehaviour
{
    public Text peekModeText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        bool onCube = false;
        if (GameObject.Find("PlayerMovement") != null)
        {
            onCube = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().getOnCube();
        }

        if (InputManager.instance.controller_mode && onCube)
        {
            peekModeText.text = "Cube rotation still enabled\nPress any other button to exit";
        }
        else if (InputManager.instance.controller_mode && !onCube)
        {
            peekModeText.text = "Press any button to exit";
        }
        else if (!InputManager.instance.controller_mode && onCube)
        {
            peekModeText.text = "Cube rotation still enabled\nPress any other key to exit";
        }
        else if (!InputManager.instance.controller_mode && !onCube)
        {
            peekModeText.text = "Press any key to exit";
        }

    }
}
