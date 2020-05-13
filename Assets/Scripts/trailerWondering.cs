using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailerWondering : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GetComponent<Animator>().SetTrigger("wondering");
        }
    }
}
