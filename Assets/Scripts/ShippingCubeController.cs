using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingCubeController : MonoBehaviour
{
    public Vector3 movement;

    // Start is called before the first frame update
    public void Move()
    {
        StartCoroutine(MovingUp());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ResetChildrenPosition()
    {
        foreach (Transform child in GameObject.Find("Ship").transform)
        {
            foreach (Transform tile in child.transform)
            {
                Vector3 tile_p = tile.transform.localPosition;
                tile_p.z = Mathf.Round(tile_p.z * 2f) * 0.5f;
                tile_p.x = Mathf.Round(tile_p.x * 2f) * 0.5f;
                tile_p.y = Mathf.Round(tile_p.y * 2f) * 0.5f;
                tile.transform.localPosition = tile_p;
            }
        }
    }

    IEnumerator MovingUp()
    {
        if (GameObject.Find("PlayerMovement") != null)
        {
            Debug.Log("turning off!!!!!!");
            GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().enabled = false;
        }

        GameObject cube1 = GameObject.Find("Ship");
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
}
