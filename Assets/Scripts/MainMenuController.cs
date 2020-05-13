using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public textAppearing opening;
    public AudioSource player;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && opening.done)
        {
            SceneManager.LoadScene(1);
        }
        if (opening.done)
        {
            player.enabled = true;
        }
    }
}
