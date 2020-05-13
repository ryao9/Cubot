using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guidanceChange : MonoBehaviour
{
    bool isKeyboard;
    // Start is called before the first frame update
    void Start()
    {
        isKeyboard = !InputManager.instance.controller_mode;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
