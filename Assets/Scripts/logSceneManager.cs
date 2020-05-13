using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logSceneManager : MonoBehaviour
{
    private string levelScene;
    private bool alreadyLoaded = false;
    private bool logLoaded = false;
    private bool choiceLoaded = true;
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("LogManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        levelScene = SceneManager.GetActiveScene().name;
        if (levelScene == "endingLevel") {
            choiceLoaded = false; 
        }
    }

    public void Update()
    {
        if (!choiceLoaded && Input.GetKeyDown(InputManager.instance.exit))
        {
            choiceLoaded = true;
            Debug.Log("choice Loaded");
        } else if (logLoaded && Input.GetKeyDown(InputManager.instance.exit))
        {
            if (!alreadyLoaded)
            {
                alreadyLoaded = true;
                logLoaded = false;
                GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().enabled = true;
                GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = true;
            }
        } else if (levelScene == "endingLevel" && choiceLoaded && Input.GetKeyDown(InputManager.instance.rot_c))
        {
            if (!alreadyLoaded)
            {
                alreadyLoaded = true;
                logLoaded = false;
                GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().enabled = true;
                GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = true;
            }
        }
    }

    public void ActivatePlayer()
    {
        logLoaded = true;
        alreadyLoaded = false;
    }

    //// Update is called once per frame
    //IEnumerator StartActivatePlayer()
    //{
    //    AsyncOperation ao = SceneManager.UnloadSceneAsync("log1");
    //    yield return ao;
    //    GameObject.Find("Main Camera").SetActive(true);
    //    GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().enabled = true;
    //}
}
