using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scrollScript : MonoBehaviour
{
    // Update is called once per frame
    public float max_y;
    public float min_y;

    public GameObject zoomIn;
    public GameObject scrollBar;
    public string sceneName;

    bool imaged = false;

    void Update()
    {
        //Debug.Log(GetComponent<RectTransform>().anchoredPosition);
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
        } else if (Input.GetKeyDown(InputManager.instance.exit))
        {
            Time.timeScale = 1;
            SceneManager.UnloadSceneAsync(sceneName);
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
}
