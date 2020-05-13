using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameEnd : MonoBehaviour
{
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -1) SceneManager.LoadScene(0);
    }
}
