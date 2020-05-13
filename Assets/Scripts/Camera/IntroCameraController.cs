using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCameraController : MonoBehaviour
{
    GameObject mainCamera;
    public GameObject[] instructions;

    private PlayerMovement playerMovement;

    public Transform[] stopPoints;

    public float moveTimeOnUnitDist = 0.2f;
    public AnimationCurve cameraMovementCurve;

    public GameObject Ship;

    void Start()
    {
        // Turn off main camera
        mainCamera = GameObject.Find("Main Camera");

        // Turn off player movement control
        playerMovement = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>();
        playerMovement.enabled = false;

        if (stopPoints.Length >= 2)
        {
            // Set camera starting position
            transform.position = stopPoints[0].position;
            transform.rotation = stopPoints[0].rotation;
            StartCoroutine(IntroMovement());
        }
        else
        {
            playerMovement.enabled = true;
            gameObject.SetActive(false);
        }
    }


    IEnumerator IntroMovement()
    {
        mainCamera.GetComponent<CameraController>().enabled = false;
        mainCamera.GetComponent<Camera>().enabled = false;

        foreach (GameObject inst in instructions)
        {
            inst.SetActive(false);
        }

        yield return new WaitForSeconds(0.8f);

        Transform posFrom = stopPoints[0];
        Transform posTo;
        for (int i = 1; i < stopPoints.Length; i++)
        {
            posTo = stopPoints[i];

            float elapsedTime = 0;
            float dist = Vector3.Distance(posFrom.position, posTo.position);
            float waitTime = dist * moveTimeOnUnitDist;

            while (elapsedTime <= waitTime)
            {
                transform.position = Vector3.Lerp(posFrom.position, posTo.position, (elapsedTime / waitTime));
                transform.rotation = Quaternion.Lerp(posFrom.rotation, posTo.rotation, (elapsedTime / waitTime));

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            //float _animationTimePosition = 0f;
            //while (transform.position != posTo.position)
            //{
            //    _animationTimePosition += Time.deltaTime;
            //    transform.position = Vector3.Lerp(posFrom.position, posTo.position, cameraMovementCurve.Evaluate(_animationTimePosition));
            //    transform.rotation = Quaternion.Lerp(posFrom.rotation, posTo.rotation, cameraMovementCurve.Evaluate(_animationTimePosition));
            //    yield return null;
            //}

            transform.position = posTo.position;
            transform.rotation = posTo.rotation;
            posFrom = posTo;
        }

        //mainCamera.SetActive(true);
        mainCamera.GetComponent<CameraController>().enabled = true;
        mainCamera.GetComponent<Camera>().enabled = true;
        playerMovement.enabled = true;

        if (Ship != null)
        {
            Ship.GetComponent<ShippingCubeController>().Move();
        }

        // Turn on instruction
        foreach (GameObject inst in instructions)
        {
            inst.SetActive(true);
        }

        // Turn itself (this intro camera) off

        if (GameObject.Find("particles") != null)
        {
            Debug.Log("particles");
            foreach (Transform child in GameObject.Find("particles").transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        gameObject.SetActive(false);
    }
}
