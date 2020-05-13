using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scrollScriptVision : MonoBehaviour
{
    // Update is called once per frame
    public float max_y;
    public float min_y;

    public GameObject zoomIn;
    public GameObject scrollBar;
    public string sceneName;
    public GameObject choice;
    public GameObject choiceSelection;

    bool imaged = false;
    bool choice_appeared = false;
    bool selection = true;

    void Update()
    {
        //Debug.Log(GetComponent<RectTransform>().anchoredPosition);
        if (!choice_appeared)
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") == -1) // Zoom out
            {
                RectTransform text_position = GetComponent<RectTransform>();
                RectTransform scroll_position = scrollBar.GetComponent<RectTransform>();
                if (text_position.anchoredPosition.y < max_y)
                {
                    text_position.anchoredPosition = new Vector3(text_position.anchoredPosition.x, text_position.anchoredPosition.y + 10f);
                    scroll_position.anchoredPosition = new Vector3(scroll_position.anchoredPosition.x, scroll_position.anchoredPosition.y - ((10f / (max_y - min_y)) * (155f - 6.5f)));
                }
            }
            else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("Vertical") == 1) // Zoom in
            {
                RectTransform text_position = GetComponent<RectTransform>();
                RectTransform scroll_position = scrollBar.GetComponent<RectTransform>();
                if (text_position.anchoredPosition.y > min_y)
                {
                    text_position.anchoredPosition = new Vector3(text_position.anchoredPosition.x, text_position.anchoredPosition.y - 10f);
                    scroll_position.anchoredPosition = new Vector3(scroll_position.anchoredPosition.x, scroll_position.anchoredPosition.y + ((10f / (max_y - min_y)) * (155f - 6.5f)));
                }
            }
            else if (Input.GetKeyDown(InputManager.instance.exit))
            {
                choice.SetActive(true);
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }
                if (GameObject.Find("scroll") != null)
                {
                    GameObject.Find("scroll").SetActive(false);
                }
                if (GameObject.Find("scrollBg") != null)
                {
                    GameObject.Find("scrollBg").SetActive(false);
                }
                if (GameObject.Find("exit") != null)
                {
                    GameObject.Find("exit").SetActive(false);
                }
                choice_appeared = true;
            }
            else if (Input.GetKeyDown(InputManager.instance.rot_c))
            {
                if (zoomIn != null)
                {
                    zoomIn.SetActive(!imaged);
                    imaged = !imaged;
                }
            }
        } 
        else
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") == -1) // Zoom out
            {
                if (!selection)
                {
                    RectTransform selection_position = choiceSelection.GetComponent<RectTransform>();
                    selection_position.anchoredPosition = new Vector3(selection_position.anchoredPosition.x - 250f, selection_position.anchoredPosition.y);
                    selection = true;
                }
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") == 1) // Zoom in
            {
                if (selection)
                {
                    RectTransform selection_position = choiceSelection.GetComponent<RectTransform>();
                    selection_position.anchoredPosition = new Vector3(selection_position.anchoredPosition.x + 250f, selection_position.anchoredPosition.y);
                    selection = false;
                }
            }
            else if (Input.GetKeyDown(InputManager.instance.rot_c))
            {
                if (GameObject.Find("Goal") != null)
                {
                    GameObject.Find("Goal").GetComponent<goalRobot>().visionActivated = selection;
                }

                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync(sceneName);
            }
        }
    }
}
