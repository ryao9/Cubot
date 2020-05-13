﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerMovement");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }

    public void follow()
    {
        transform.position = player.transform.position;
    }
}
