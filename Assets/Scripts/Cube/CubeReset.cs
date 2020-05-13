using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeReset : MonoBehaviour
{
    private CubeController cube;

    private Vector3[] center_positions = new Vector3[(int)CenterSticker.numCenters];
    private Vector3[] edge_positions = new Vector3[(int)EdgeSticker.numEdges];
    private Vector3[] corner_positions = new Vector3[(int)CornerSticker.numCorners];
    private Quaternion[] center_rotations = new Quaternion[(int)CenterSticker.numCenters];
    private Quaternion[] edge_rotations = new Quaternion[(int)EdgeSticker.numEdges];
    private Quaternion[] corner_rotations = new Quaternion[(int)CornerSticker.numCorners];

    void Awake()
    {
        cube = GetComponent<CubeController>();

        cube.cube.ResetIndices();
        for (int i = 0; i < (int)CenterSticker.numCenters; ++i)
        {
            center_positions[i] = cube.centers[i].gameObject.transform.position;
            center_rotations[i] = cube.centers[i].gameObject.transform.rotation;
        }
        for (int i = 0; i < (int)EdgeSticker.numEdges; ++i)
        {
            edge_positions[i] = cube.edges[i].gameObject.transform.position;
            edge_rotations[i] = cube.edges[i].gameObject.transform.rotation;
        }
        for (int i = 0; i < (int)CornerSticker.numCorners; ++i)
        {
            corner_positions[i] = cube.corners[i].gameObject.transform.position;
            corner_rotations[i] = cube.corners[i].gameObject.transform.rotation;
        }
    }

    public void ResetCube()
    {
        cube.cube.ResetIndices();
        for (int i = 0; i < (int)CenterSticker.numCenters; ++i)
        {
            cube.centers[i].gameObject.transform.position = center_positions[i];
            cube.centers[i].gameObject.transform.rotation = center_rotations[i];
        }
        for (int i = 0; i < (int)EdgeSticker.numEdges; ++i)
        {
            cube.edges[i].gameObject.transform.position = edge_positions[i];
            cube.edges[i].gameObject.transform.rotation = edge_rotations[i];
        }
        for (int i = 0; i < (int)CornerSticker.numCorners; ++i)
        {
            cube.corners[i].gameObject.transform.position = corner_positions[i];
            cube.corners[i].gameObject.transform.rotation = corner_rotations[i];
        }
    }
}
