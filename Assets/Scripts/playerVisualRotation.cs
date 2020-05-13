using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerVisualRotation : MonoBehaviour
{
    private Vector3 previousDirection;
    private CameraController cameraControl;
    private PlayerMovement playerMovement;

    void Start()
    {
        previousDirection = Vector3.forward;
        cameraControl = Camera.main.GetComponent<CameraController>();
        playerMovement = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>();
    }

    public void faceForward()
    {
        transform.parent.localRotation = Quaternion.Euler(0, 0, 0);
        previousDirection = Vector3.forward;
    }

    public void faceBack()
    {
        transform.parent.localRotation = Quaternion.Euler(0, 180, 0);
        previousDirection = Vector3.back;
    }

    public void faceLeft()
    {
        transform.parent.localRotation = Quaternion.Euler(0, 270, 0);
        previousDirection = Vector3.left;
    }

    public void faceRight()
    {
        transform.parent.localRotation = Quaternion.Euler(0, 90, 0);
        previousDirection = Vector3.right;
    }

    public void parentRotation()
    {
        if (playerMovement.getOnCube())
        {
            int currentSide = playerMovement.getCurrentCubeSide();

            if (currentSide == 5)
            {
                transform.parent.parent.localRotation = Quaternion.Euler(-90, 0, 0);
            }
            else if (currentSide == 2)
            {
                transform.parent.parent.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if (currentSide == 3)
            {
                transform.parent.parent.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (currentSide == 4)
            {
                transform.parent.parent.localRotation = Quaternion.Euler(0, 0, -90);
            }
            else if (currentSide == 1)
            {
                transform.parent.parent.localRotation = Quaternion.Euler(90, 0, 0);
            }
        }
        else
        {
            transform.parent.parent.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void reset_parentRotation()
    {
        transform.parent.parent.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
