using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeState : MonoBehaviour
{
    public bool rotatable = true;

    // Update is called once per frame
    void setRotatable(bool input)
    {
        rotatable = input;
    }

    public bool getRotatable()
    {
        return rotatable;
    }
}
