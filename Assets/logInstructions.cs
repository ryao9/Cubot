using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logInstructions : MonoBehaviour
{
    public Text exitInstruction;
    public Text imageInstruction;
    public Text choiceInstruction;
    // Start is called before the first frame update
    void Start()
    {
        if (InputManager.instance.controller_mode == false) {
            if (imageInstruction != null)
            {
                imageInstruction.text = "Press Q to view larger image";
            }
            if (choiceInstruction != null)
            {
                choiceInstruction.text = "Press Q to select";
            }
            exitInstruction.text = "Press R to exit";
        } else
        {
            if (imageInstruction != null)
            {
                imageInstruction.text = "Press L2 to view larger image";
            }
            if (choiceInstruction != null)
            {
                choiceInstruction.text = "Press L2 to select";
            }
            exitInstruction.text = "Press Square to exit";
        }
    }
}
