using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTrailer0 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveout());
    }

    // Update is called once per frame
    IEnumerator moveout()
    {
        yield return new WaitForSeconds(3.0f);

        Vector3 new_position = new Vector3(7f, 4f, 22f);
        float startTime = Time.time;
        Vector3 lerp_initial_position = transform.position;
        float journeyLength = Vector3.Distance(lerp_initial_position, new_position);

        float fractionOfJourney = 0;

        while (fractionOfJourney < 0.99f)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * 1.0f;

            // Fraction of journey completed equals current distance divided by total distance.
            fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(lerp_initial_position, new_position, fractionOfJourney);

            yield return null;
        }

        new_position = new Vector3(8f, 20f, 55f);
        startTime = Time.time;
        lerp_initial_position = transform.position;
        journeyLength = Vector3.Distance(lerp_initial_position, new_position);

        Quaternion initial_rotation = transform.rotation;
        Quaternion new_rotation = Quaternion.Euler(70, 160, -5);

        fractionOfJourney = 0;

        while (fractionOfJourney < 0.99f)
        {
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * (1.0f + (fractionOfJourney * 5f));

            // Fraction of journey completed equals current distance divided by total distance.
            fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.rotation = Quaternion.Lerp(initial_rotation, new_rotation, fractionOfJourney * 2.0f);
            transform.position = Vector3.Lerp(lerp_initial_position, new_position, fractionOfJourney);

            yield return null;
        }
    }
}
