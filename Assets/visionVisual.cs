using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visionVisual : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.num_logs < 7)
        {
            Destroy(gameObject);
        }
    }
}
