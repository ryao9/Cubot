using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Opens menu and disables player movement when button pressed
public class PauseMenuController : MonoBehaviour
{
    public Canvas menu;
    public CubeRotate[] rotatoes;

    private PlayerMovement player_move;
    private CameraController cam;

    public void Continue()
    {
        menu.gameObject.SetActive(false);

        if (player_move != null)
        {
            player_move.gameObject.SetActive(true);
            player_move.OnCube();
            if (GameObject.Find("PlayerRobot") != null) GameObject.Find("PlayerRobot").GetComponent<playerVisualRotation>().parentRotation();
            //player_move.resetCameraRotation();
        }
        if (cam != null)
        {
            cam.enabled = true;
        }
        foreach (CubeRotate rotate in rotatoes)
        {
            rotate.enabled = true;
        }
        Time.timeScale = 1;
    }

    public void Pause()
    {
        menu.gameObject.SetActive(true);

        if (player_move != null)
        {
            player_move.gameObject.SetActive(false);
        }
        if (cam != null)
        {
            cam.enabled = false;
        }
        foreach (CubeRotate rotate in rotatoes)
        {
            rotate.enabled = false;
        }

        Time.timeScale = 0;
    }

    public bool isPaused()
    {
        return menu.gameObject.activeInHierarchy;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if (Input.GetKeyDown(InputManager.instance.pause) && player_move.allowInput)
        {
            Debug.Log("escape pressed");
            if (menu.gameObject.activeInHierarchy)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }*/

    void Start()
    {
        player_move = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>();
        cam = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }
}
