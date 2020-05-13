using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingTransition : MonoBehaviour
{
    private bool endingReached = false;
    private void OnEnable()
    {
        Debug.Log("asdffadsf");
        endingReached = true;
    }

    private void Update()
    {
        if (endingReached)
        {
            if (Input.anyKeyDown)
            {
                GameManager.instance.ResetGameData();
                SceneManager.LoadScene("logBackground");
            }
        }
    }
}
