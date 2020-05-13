using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anyKeyInstruction : MonoBehaviour
{
    public string action;
    // Start is called before the first frame update
    void Awake()
    {
        if (InputManager.instance.controller_mode == false)
        {
            GetComponent<UnityEngine.UI.Text>().text = "Press Any Key to " + action;
        }
        else
        {
            GetComponent<UnityEngine.UI.Text>().text = "Press Any Button to " + action;
        }
    }
}
