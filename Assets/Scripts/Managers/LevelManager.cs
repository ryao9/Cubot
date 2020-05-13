using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject[] cubes;
    public GameObject[] batteries;
    public Vector3 reset_position;
    public int battery_count = 0;
    public int checkpoint = 0;
    public int num_cubes;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("PlayerMovement");
        reset_position = player.transform.position;
        GameManager.instance.LoadData();
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;

        if (checkpoint == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        GameObject.Find("InventoryManager").GetComponent<inventoryManager>().battery_count = battery_count;
        if (GameObject.Find("InventoryManager").GetComponent<inventoryManager>().battery_count == 80)
        {
            GameObject.Find("InventoryManager").GetComponent<inventoryManager>().battery_count_text.text
                = "x " + (GameObject.Find("InventoryManager").GetComponent<inventoryManager>().battery_count) + " max";
        } else
        {
            GameObject.Find("InventoryManager").GetComponent<inventoryManager>().battery_count_text.text
                = "x " + (GameObject.Find("InventoryManager").GetComponent<inventoryManager>().battery_count);
        }

        if (SceneManager.GetActiveScene().name == "Beta_Level3") { 
            for (int i = num_cubes - 1; i >= 0; --i)
            {
                if (cubes[i].GetComponent<CubeReset>() != null) cubes[i].GetComponent<CubeReset>().ResetCube();
                if (cubes[i].GetComponent<RotateHighlight>() != null) cubes[i].GetComponent<RotateHighlight>().UnhiglightAll();
            }        
        }
        else
        {
            for (int i = num_cubes - 1; i >= checkpoint; --i)
            {
                if (cubes[i].GetComponent<CubeReset>() != null) cubes[i].GetComponent<CubeReset>().ResetCube();
                if (cubes[i].GetComponent<RotateHighlight>() != null) cubes[i].GetComponent<RotateHighlight>().UnhiglightAll();
            }
        }

        player.transform.position = reset_position;

        foreach (GameObject battery in batteries)
        {
            battery.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(InputManager.instance.reset))
        {
            ResetLevel();
        }

        if (Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
