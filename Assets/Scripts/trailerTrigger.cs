using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailerTrigger : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetTrigger("pickup");
        }
    }
}
