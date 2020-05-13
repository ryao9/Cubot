using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidanceActivator : MonoBehaviour
{
    public GameObject player;
    public GameObject camera;
    public GameObject instructionKey;
    public GameObject instructionCon;
    public float difference;
    public float xdifference;
    bool activated;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(player.transform.position.z - transform.position.z)< difference  &&
            Mathf.Abs(player.transform.position.x - transform.position.x) < xdifference
            )
        {
            if(!activated)
            {
                if (!camera.GetComponent<CameraController>().isPeek())
                {
                    setTrue();
                }
            }
            else
            {
                if (camera.GetComponent<CameraController>().isPeek())
                {
                    setFalse();
                }
            }
        }
        else if((Mathf.Abs(player.transform.position.z - transform.position.z) > difference ||
            Mathf.Abs(player.transform.position.x - transform.position.x) > xdifference )&& activated)
        {
            setFalse();
        }
    }
    public bool getStatus()
    {
        return activated;
    }
    public void setTrue()
    {
        if (InputManager.instance.controller_mode)
        {
            instructionCon.GetComponent<Toaster>().setTrue();
        }
        else
        {
            instructionKey.GetComponent<Toaster>().setTrue();
        }
        activated = true;
    }
    public void setFalse()
    {
        if (InputManager.instance.controller_mode)
        {
            instructionCon.GetComponent<Toaster>().setFalse();
        }
        else
        {
            instructionKey.GetComponent<Toaster>().setFalse();
        }
        activated = false;
    }
}
