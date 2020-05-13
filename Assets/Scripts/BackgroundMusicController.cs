using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioSource player;
    public AudioSource player2;
    public AudioSource player3;

    bool turned_on = false;
    bool turned_on2 = false;
    bool turned_on3 = false;
    bool turned_on4 = false;

    // Update is called once per frame
    void Update()
    {
        if (!turned_on && (SceneManager.GetActiveScene().name == "Alpha_Level1" || SceneManager.GetActiveScene().name == "Alpha_Level2"))
        {
            player.enabled = true;
            player2.enabled = false;
            player3.enabled = false;
            turned_on = true;
            turned_on2 = false;
            turned_on3 = false;
        }
        if (!turned_on2 && SceneManager.GetActiveScene().name == "Beta_Level3")
        {
            player.enabled = false;
            player2.enabled = true;
            player3.enabled = false;
            turned_on2 = true;
            turned_on = false;
            turned_on3 = false;
        }
        if (!turned_on3 && SceneManager.GetActiveScene().name == "endingLevel")
        {
            player.enabled = false;
            player2.enabled = false;
            player3.enabled = true;
            turned_on = false;
            turned_on2 = false;
            turned_on3 = true;
        }
        if (!turned_on4 && (SceneManager.GetActiveScene().name == "endingLevel 1" || SceneManager.GetActiveScene().name == "endingLevel 2"))
        {
            player.enabled = false;
            player2.enabled = false;
            player3.enabled = false;
        }
    }
}
