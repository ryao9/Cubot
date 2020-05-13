using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script for changing camera when player collides with object script is attached to
public class CameraTrigger : MonoBehaviour
{
    public int degree_rotation = 180;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (degree_rotation == 180)
            {
                GameObject.Find("Main Camera").transform.GetComponent<CameraController>().RotateCameraTwice();
            }
            else if (degree_rotation == 90)
            {
                degree_rotation = -90;
                GameObject.Find("Main Camera").transform.GetComponent<CameraController>().RotateCameraCounterClockwise();
            }
            else if (degree_rotation == -90)
            {
                GameObject.Find("Main Camera").transform.GetComponent<CameraController>().RotateCameraClockwise();
                degree_rotation = 90;
            }

            Destroy(gameObject);
        }
    }
}
