using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toaster : MonoBehaviour
{
    float activated;
    float timer;
    public float offset;
    Vector3 original;
    Vector3 final;
    public GameObject anchor;
    bool isKeyboard;
    // Start is called before the first frame update
    void Start()
    {
        activated = 0;
        timer = 0;
        final = anchor.transform.position;
        final.x = final.x * (1 + offset);
        original = anchor.transform.position*1.5f;
        transform.position = original;
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
        if (activated > 0)
        {
            final = anchor.transform.position;
            final.x = final.x * (1 + offset);
            Lerp(final);
        }
        else
        {
            original = anchor.transform.position;
            original.y = original.y * 1.5f;
            original.x = original.x * (1 + offset);
            Lerp(original);
        }
        */
    }
    void Lerp(Vector3 final)
    {
        transform.position += (final - transform.position) / 15f;
    }
    public void setTrue()
    {
        if(activated == 0)
        {
            transform.position = final;
        }
        activated ++;
    }
    public void setFalse()
    {
        activated --;
        if (activated == 0)
        {
            transform.position = original;
        }
    }
}
