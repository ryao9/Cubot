using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreCameraController : MonoBehaviour
{
    public PlayerMovement pm;
    public playerVisualRotation pvr;

    private void OnTriggerEnter(Collider other)
    {
        pm.resetCameraRotation();
        pvr.reset_parentRotation();
    }
}
