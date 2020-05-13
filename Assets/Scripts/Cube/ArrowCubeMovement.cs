using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCubeMovement : MonoBehaviour
{
    public Material newMat;

    public GameObject mesh0;
    public GameObject mesh1;
    public GameObject mesh2;
    public GameObject mesh3;
    public GameObject mesh4;

    public Vector3 movement;

    bool mesh0_done = false;
    bool mesh1_done = false;
    bool mesh2_done = false;
    bool mesh3_done = false;
    bool mesh4_done = false;
    bool pink_mesh0_done = false;
    bool pink_mesh1_done = false;
    bool pink_mesh2_done = false;
    bool pink_mesh3_done = false;
    bool pink_mesh4_done = false;
    bool moved_up = false;
    bool moved_down = true;

    // Update is called once per frame
    void LateUpdate()
    {
        if (!moved_up) CheckUp();
    }

    void CheckUp()
    {
        // mesh 0
        if (Mathf.Approximately(mesh0.transform.position.x, 4.5f)
                    && Mathf.Approximately(mesh0.transform.position.y, 3.06f)
                    && Mathf.Approximately(mesh0.transform.position.z, 0.5f))
        {
            mesh0_done = true;
        }
        else
        {
            mesh0_done = false;
        }
        // mesh 1
        if (Mathf.Approximately(mesh1.transform.position.x, 3.5f)
                    && Mathf.Approximately(mesh1.transform.position.y, 3.06f)
                    && Mathf.Approximately(mesh1.transform.position.z, -0.5f))
        {
            mesh1_done = true;
        }
        else
        {
            mesh1_done = false;
        }
        // mesh 2
        if (Mathf.Approximately(mesh2.transform.position.x, 4.5f)
                    && Mathf.Approximately(mesh2.transform.position.y, 3.06f)
                    && Mathf.Approximately(mesh2.transform.position.z, -0.5f))
        {
            mesh2_done = true;
        }
        else
        {
            mesh2_done = false;
        }
        // mesh 3
        if (Mathf.Approximately(mesh3.transform.position.x, 5.5f)
                    && Mathf.Approximately(mesh3.transform.position.y, 3.06f)
                    && Mathf.Approximately(mesh3.transform.position.z, -0.5f))
        {
            mesh3_done = true;
        }
        else
        {
            mesh3_done = false;
        }
        // mesh 4
        if (Mathf.Approximately(mesh4.transform.position.x, 4.5f)
                    && Mathf.Approximately(mesh4.transform.position.y, 3.06f)
                    && Mathf.Approximately(mesh4.transform.position.z, -1.5f))
        {
            mesh4_done = true;
        }
        else
        {
            mesh4_done = false;
        }

        if (mesh0_done && mesh1_done && mesh2_done && mesh3_done && mesh4_done)
        {
            MoveUp();
        }
    }

    void MoveUp()
    {
        if (!moved_up) { 
            StartCoroutine(MovingUp());
            moved_up = true;
            moved_down = false;
        }
    }

    //void CheckDown()
    //{
    //    // mesh 0
    //    if (Mathf.Approximately(pink_mesh0.transform.position.x, 4.5f)
    //                && Mathf.Approximately(pink_mesh0.transform.position.y, 3.05f)
    //                && Mathf.Approximately(pink_mesh0.transform.position.z, 0.5f))
    //    {
    //        pink_mesh0_done = true;
    //    }
    //    else
    //    {
    //        pink_mesh0_done = false;
    //    }
    //    // mesh 1
    //    if (Mathf.Approximately(pink_mesh1.transform.position.x, 4.5f)
    //                && Mathf.Approximately(pink_mesh1.transform.position.y, 3.05f)
    //                && Mathf.Approximately(pink_mesh1.transform.position.z, -0.5f))
    //    {
    //        pink_mesh1_done = true;
    //    }
    //    else
    //    {
    //        pink_mesh1_done = false;
    //    }
    //    // mesh 2
    //    if (Mathf.Approximately(pink_mesh2.transform.position.x, 5.5f)
    //                && Mathf.Approximately(pink_mesh2.transform.position.y, 3.05f)
    //                && Mathf.Approximately(pink_mesh2.transform.position.z, 0.5f))
    //    {
    //        pink_mesh2_done = true;
    //    }
    //    else
    //    {
    //        pink_mesh2_done = false;
    //    }
    //    // mesh 3
    //    if (Mathf.Approximately(pink_mesh3.transform.position.x, 4.5f)
    //                && Mathf.Approximately(pink_mesh3.transform.position.y, 3.05f)
    //                && Mathf.Approximately(pink_mesh3.transform.position.z, -0.5f))
    //    {
    //        pink_mesh3_done = true;
    //    }
    //    else
    //    {
    //        pink_mesh3_done = false;
    //    }
    //    // mesh 4
    //    if (Mathf.Approximately(pink_mesh4.transform.position.x, 3.5f)
    //                && Mathf.Approximately(pink_mesh4.transform.position.y, 3.05f)
    //                && Mathf.Approximately(pink_mesh4.transform.position.z, 0.5f))
    //    {
    //        pink_mesh4_done = true;
    //    }
    //    else
    //    {
    //        pink_mesh4_done = false;
    //    }

    //    if (pink_mesh0_done && pink_mesh1_done && pink_mesh2_done && pink_mesh3_done && pink_mesh4_done)
    //    {
    //        MoveDown();
    //    }
    //}

    //void MoveDown()
    //{
    //    if (!moved_down)
    //    {
    //        StartCoroutine(MovingDown());
    //        moved_down = true;
    //        moved_up = false;
    //    }
    //}

    void ChangeMaterial()
    {
        Renderer[] children;
        children = GameObject.Find("Cube1").GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = newMat;
            }
            rend.materials = mats;
        }
    }

    void ResetChildrenPosition()
    {
        foreach (Transform child in GameObject.Find("Cube1").transform)
        {
            foreach (Transform tile in child.transform)
            {
                Vector3 tile_p = tile.transform.localPosition;
                tile_p.z = Mathf.Round(tile_p.z * 2f) * 0.5f;
                tile.transform.localPosition = tile_p;
            }
        }
    }

    IEnumerator MovingUp()
    {
        if (GameObject.Find("PlayerMovement") != null) GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().enabled = false;
        if (GameObject.Find("Cube1") != null) GameObject.Find("Cube1").GetComponent<CubeRotate>().enabled = false;
        if (GameObject.Find("Cube1") != null) GameObject.Find("Cube1").GetComponent<CubeReset>().enabled = false;
        if (GameObject.Find("Cube1") != null) GameObject.Find("Cube1").GetComponent<CubeController>().enabled = false;
        if (GameObject.Find("Cube1") != null) GameObject.Find("Cube1").GetComponent<RotateHighlight>().enabled = false;
        ChangeMaterial();

        GameObject cube1 = GameObject.Find("Cube1");
        GameObject player = GameObject.Find("PlayerMovement");

        float startTime = Time.time;
        
        Vector3 cube1_new_position = cube1.transform.position + movement;
        Vector3 cube1_initial_position = cube1.transform.position;
        float cube1JourneyLength = Vector3.Distance(cube1_initial_position, cube1_new_position);

        Vector3 player_new_position = player.transform.position + movement;
        Vector3 player_initial_position = player.transform.position;
        float playerJourneyLength = Vector3.Distance(player_initial_position, player_new_position);

        float speed = 5.0f;
        float cube1FractionOfJourney = 0;
        float playerFractionOfJourney = 0;

        while (cube1FractionOfJourney < 0.99f)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            cube1FractionOfJourney = distCovered / cube1JourneyLength;
            playerFractionOfJourney = distCovered / playerJourneyLength;

            // Set our position as a fraction of the distance between the markers.
            cube1.transform.position = Vector3.Lerp(cube1_initial_position, cube1_new_position, cube1FractionOfJourney);
            ResetChildrenPosition();
            player.transform.position = Vector3.Lerp(player_initial_position, player_new_position, playerFractionOfJourney);

            yield return null;
        }

        cube1.transform.position = cube1_new_position;
        ResetChildrenPosition();
        player.transform.position = player_new_position;
        if (GameObject.Find("PlayerMovement") != null) GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().enabled = true;
    }

    //IEnumerator MovingDown()
    //{
    //    GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().enabled = false;
    //    float startTime = Time.time;

    //    Vector3 environment_new_position = environment.transform.position - movement;
    //    Vector3 environment_initial_position = environment.transform.position;
    //    float environmentJourneyLength = Vector3.Distance(environment_initial_position, environment_new_position);

    //    float speed = 5.0f;
    //    float environmentFractionOfJourney = 0;

    //    while (environmentFractionOfJourney < 0.99f)
    //    {
    //        // Distance moved equals elapsed time times speed..
    //        float distCovered = (Time.time - startTime) * speed;

    //        // Fraction of journey completed equals current distance divided by total distance.
    //        environmentFractionOfJourney = distCovered / environmentJourneyLength;

    //        // Set our position as a fraction of the distance between the markers.
    //        environment.transform.position = Vector3.Lerp(environment_initial_position, environment_new_position, environmentFractionOfJourney);

    //        yield return null;
    //    }
    //    GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().enabled = true;
    //    environment.transform.position = environment_new_position;
    //}
}
