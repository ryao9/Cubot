using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfdestruct : MonoBehaviour
{
    bool activated;
    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated)
        {
            if (transform.gameObject.GetComponent<GuidanceActivator>().getStatus())
            {
                activated = true;
            }
        }
        else
        {
            if (!transform.gameObject.GetComponent<GuidanceActivator>().getStatus())
            {
                Destroy(transform.gameObject);
            }
        }
    }
}
