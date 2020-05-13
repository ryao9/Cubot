using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public inventoryManager.Difficulty diff;
    public int num_logs = 0;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    public void ResetGameData()
    {
        num_logs = 0;
    }

    public void SaveData()
    {
        if (GameObject.Find("InventoryManager") != null) diff = GameObject.Find("InventoryManager").GetComponent<inventoryManager>().difficulty;
    }

    public void LoadData()
    {
        if (GameObject.Find("InventoryManager") != null) GameObject.Find("InventoryManager").GetComponent<inventoryManager>().difficulty = diff;
    }
}
