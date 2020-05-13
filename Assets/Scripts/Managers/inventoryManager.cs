using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    public int battery_count;
    //public int battery_increment;
    public int max_battery;
    public Text battery_count_text;

    public enum Difficulty { normal, hard, extreme }
    public Difficulty difficulty;

    int normal_pickup_count = 40;
    int hard_pickup_count = 20;
    int extreme_pickup_count = 10;

    public void decrementBatteryCount()
    {
        battery_count--;
        if (battery_count_text != null)
        {
            if (battery_count == max_battery) battery_count_text.text = " x " + battery_count + " max";
            else if (battery_count < 10) battery_count_text.text = " x " + battery_count;
            else battery_count_text.text = " x " + battery_count;
        }

        if (battery_count <= 0)
        {
            if (playerMovement.getCurrentCube() != null)
            {
                playerMovement.getCurrentCube().GetComponent<CubeRotate>().enabled = false;
                playerMovement.enabled = true;
            }
        }
    }

    public void batteryPicked(int amount)
    {
        AudioManager.PlayClip(AudioManager.instance.battery_pickup, Camera.main.transform.position);
        Debug.Log("batterpicked");
        int added_amount;
        switch (difficulty)
        {
            case Difficulty.normal:
                added_amount = normal_pickup_count;
                break;
            case Difficulty.hard:
                added_amount = hard_pickup_count;
                break;
            case Difficulty.extreme:
                Debug.Log("extreme");
                added_amount = amount;
                break;
            default:
                Debug.Log("default");
                added_amount = 0;
                break;
        }
        battery_count = Mathf.Min(battery_count + added_amount, max_battery);
        if (battery_count_text != null)
        {
            if (battery_count == max_battery) battery_count_text.text = " x " + battery_count + " max";
            else if (battery_count < 10) battery_count_text.text = " x " + battery_count;
            else battery_count_text.text = " x " + battery_count;
        }
    }

    void Awake()
    {
        battery_count_text.text = " x 0";
        playerMovement = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (battery_count < 3) battery_count_text.color = Color.red;
        else battery_count_text.color = Color.white;

        if (battery_count <= 0)
        {
            if (playerMovement.getCurrentCube() != null)
            {
                if (playerMovement.getCurrentCube().GetComponent<CubeRotate>() != null) playerMovement.getCurrentCube().GetComponent<CubeRotate>().enabled = false;
            }
        }
        else
        {
            if (playerMovement.getCurrentCube() != null)
            {
                if (playerMovement.getCurrentCube().GetComponent<CubeRotate>() != null)
                {
                    if (playerMovement.getCurrentCube().GetComponent<cubeState>() != null)
                    {
                        if (playerMovement.getCurrentCube().GetComponent<cubeState>().getRotatable())
                        {
                            playerMovement.getCurrentCube().GetComponent<CubeRotate>().enabled = true;
                        }
                    }
                }
            }
        }
    }
}