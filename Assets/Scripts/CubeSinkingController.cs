using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSinkingController : MonoBehaviour
{
    public static Material newMat;
    public GameObject Cube;
    public float sinkTime = 1f;

    public GameObject[] InstructionsToDelete;

    // Start is called before the first frame update
    void Start()
    {
        newMat = Resources.Load("Materials/Black") as Material;
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(CubeSink());
    }

    IEnumerator CubeSink()
    {
        // Change material to black
        Renderer[] children = Cube.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                mats[j] = newMat;
            }
            rend.materials = mats;
        }

        // Change cube to unwalkable
        foreach (Transform child in Cube.GetComponentsInChildren<Transform>(true))
        {
            child.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }

        float elapsedTime = 0;

        Vector3 currPos = Cube.transform.position;
        Vector3 targetPos = currPos + new Vector3(0, -3, 0);

        while (elapsedTime <= sinkTime)
        {
            Cube.transform.position = Vector3.Lerp(currPos, targetPos, (elapsedTime / sinkTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Cube.transform.position = targetPos;

		// disable cube rotation and highlight
        if (Cube.GetComponent("CubeRotate") != null)
        {
            Destroy(Cube.GetComponent("CubeRotate"));
        }
        if (Cube.GetComponent("RotateHighlight") != null)
        {
            Destroy(Cube.GetComponent("RotateHighlight"));
        }

        foreach (GameObject obj in InstructionsToDelete)
        {
            obj.SetActive(false);
        }

        // turn off this trigger
        gameObject.SetActive(false);
    }
}
