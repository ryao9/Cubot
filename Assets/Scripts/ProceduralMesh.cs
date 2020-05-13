using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ProceduralMesh : MonoBehaviour
{
    // 0: top vertice == (0,0,1)
    // 1: top vertice == (0.5,0,1)
    // 2: top vertice == (1,0,1)
    // 3: square
    public int triangle_option;
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeMeshData();
        CreateMesh();
    }

    // Update is called once per frame
    void MakeMeshData()
    {
        // create an array of vertices
        if (triangle_option == 0)
        {
            vertices = new Vector3[] { new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 1.0f), new Vector3(1.0f, 0.0f, 0.0f) };
        }
        else if (triangle_option == 1)
        {
            vertices = new Vector3[] { new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.5f, 0.0f, 0.75f), new Vector3(1.0f, 0.0f, 0.0f) };
        } 
        else if (triangle_option == 2)
        {
            vertices = new Vector3[] { new Vector3(0.0f, 0.0f, 0.0f), new Vector3(1.0f, 0.0f, 1.0f), new Vector3(1.0f, 0.0f, 0.0f) };
        } else if (triangle_option == 3)
        {
            vertices = new Vector3[] { new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.0f, 1.0f), new Vector3(1.0f, 0.0f, 0.0f), new Vector3(1.0f, 0.0f, 1.0f) };
        }
        else if (triangle_option == 4)
        {
            vertices = new Vector3[] { new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), new Vector3(1.0f, 0.0f, 0.0f) };
        }

        // create an array of integers
        if (triangle_option == 3)
        {
            triangles = new int[] { 0, 1, 2, 2, 1, 3 };
        } else
        {
            triangles = new int[] { 0, 1, 2 };
        }
    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
