using System;
using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public GameObject[] edges = new GameObject[(int) EdgeSticker.numEdges];
    public GameObject[] corners = new GameObject[(int) EdgeSticker.numEdges];
    public GameObject[] centers = new GameObject[(int) CenterSticker.numCenters];
    public Cube cube = new Cube();
    public Camera main_camera; // cube rotate audio
    private bool rotating = false;
    private Vector3 pivotBegin;

    private delegate void RotationFunction(CubeDirection direction);

    public bool isRotating() { return rotating; }

    public AnimationCurve cubeRotationCurve;
    float animationDuration = 0.7f;

    /* Find functions. Find the index which the given tile lies. */
    public EdgeSticker findEdge(GameObject tile)
    {
        foreach (EdgeSticker edge in Enum.GetValues(typeof(EdgeSticker)))
        {
            if (edge != EdgeSticker.numEdges && tileAt(edge) == tile)
            {
                return edge;
            }
        }
        return EdgeSticker.numEdges;
    }

    public CornerSticker findCorner(GameObject tile)
    {
        foreach (CornerSticker corner in Enum.GetValues(typeof(CornerSticker)))
        {
            if (corner != CornerSticker.numCorners && tileAt(corner) == tile)
            {
                return corner;
            }
        }
        return CornerSticker.numCorners;
    }

    public CenterSticker findCenter(GameObject tile)
    {
        foreach (CenterSticker center in Enum.GetValues(typeof(CenterSticker)))
        {
            if (center != CenterSticker.numCenters && tileAt(center) == tile)
            {
                return center;
            }
        }
        return CenterSticker.numCenters;
    }

    // Rotation functions. Animate the rotation and rotate the cube.
    // NOT responsible for disabling player controls, etc.
    public void rotateR(CubeDirection direction)
    {
        StartCoroutine(rotateCoroutine(cube.rotatingPiecesR(direction), getAxisAround(CenterSticker.R), cube.rotateR));
    }

    public void rotateL(CubeDirection direction)
    {
        StartCoroutine(rotateCoroutine(cube.rotatingPiecesL(direction), getAxisAround(CenterSticker.L), cube.rotateL));
    }
    public void rotateU(CubeDirection direction)
    {
        StartCoroutine(rotateCoroutine(cube.rotatingPiecesU(direction), getAxisAround(CenterSticker.U), cube.rotateU));
    }
    public void rotateD(CubeDirection direction)
    {
        StartCoroutine(rotateCoroutine(cube.rotatingPiecesD(direction), getAxisAround(CenterSticker.D), cube.rotateD));
    }
    public void rotateF(CubeDirection direction)
    {
        StartCoroutine(rotateCoroutine(cube.rotatingPiecesF(direction), getAxisAround(CenterSticker.F), cube.rotateF));
    }
    public void rotateB(CubeDirection direction)
    {
        StartCoroutine(rotateCoroutine(cube.rotatingPiecesB(direction), getAxisAround(CenterSticker.B), cube.rotateB));
    }
    public void rotateE(CubeDirection direction)
    {
        StartCoroutine(rotateCoroutine(cube.rotatingPiecesE(direction), getAxisAround(CenterSticker.D), cube.rotateE));
    }
    public void rotateM(CubeDirection direction)
    {
        StartCoroutine(rotateCoroutine(cube.rotatingPiecesM(direction), getAxisAround(CenterSticker.L), cube.rotateM));
    }
    public void rotateS(CubeDirection direction)
    {
        StartCoroutine(rotateCoroutine(cube.rotatingPiecesS(direction), getAxisAround(CenterSticker.F), cube.rotateS));
    }

    // Returns tile at given position
    public GameObject tileAt(EdgeSticker edge)
    {
        return edges[(int) cube.getEdge(edge)];
    }
    public GameObject tileAt(CornerSticker corner)
    {
        return corners[(int) cube.getCorner(corner)];
    }
    public GameObject tileAt(CenterSticker center)
    {
        return centers[(int) cube.getCenter(center)];
    }

    int roundFloat(float x)
    {
        float absX = Mathf.Abs(x);
        int absXInt = (int) (absX + 0.5);
        return x > 0 ? absXInt : -absXInt;
    }

    Vector3 roundVector(Vector3 vector)
    {
        vector.x = roundFloat(vector.x);
        vector.y = roundFloat(vector.y);
        vector.z = roundFloat(vector.z);
        return vector;
    }

    void roundRotation(GameObject obj)
    {
        Vector3 rotation = obj.transform.rotation.eulerAngles;
        obj.transform.rotation = Quaternion.Euler(roundVector(rotation));
    }

    void roundPosition(GameObject obj)
    {
        Vector3 position = obj.transform.position;
        obj.transform.position = roundVector(position * 2) / 2;
    }

    // Manages animating the rotation of the pieces as well as rotating the underlying cube.
    IEnumerator rotateCoroutine(RotatingPieces pieces, Vector3 axis, RotationFunction func)
    {
        GameObject.Find("InventoryManager").GetComponent<inventoryManager>().decrementBatteryCount();
        AudioManager.PlayClip(AudioManager.instance.cube_rotate, main_camera.transform.position, 0.3f);

        cubeIsMoved();
        rotating = true;
        float angle = 0;
        float duration = animationDuration;
        float journey = 0;
        float previousAngle = 0;
        CubeDirection direction = pieces.direction;
        switch (direction)
        {
            case CubeDirection.clockwise:
                angle = 90;
                break;
            case CubeDirection.anticlockwise:
                angle = -90;
                break;
            case CubeDirection.doubleTurn:
                angle = 180;
                break;
        }
        while (journey < duration)
        {
            float duationPercentage = journey / duration;
            float curvePercentage = cubeRotationCurve.Evaluate(duationPercentage);
            float newAngle = Mathf.Lerp(0, angle, curvePercentage);
            float anglePerUpdate = newAngle - previousAngle;
            previousAngle = newAngle;
            foreach (EdgeSticker piece in pieces.edges)
            {
                GameObject edgeObj = tileAt(piece);
                edgeObj.transform.RotateAround(pivotBegin, axis, anglePerUpdate);
            }
            foreach (CornerSticker piece in pieces.corners)
            {
                GameObject cornergObj = tileAt(piece);
                cornergObj.transform.RotateAround(pivotBegin, axis, anglePerUpdate);
            }
            foreach (CenterSticker piece in pieces.centers)
            {
                GameObject centerObj = tileAt(piece);
                centerObj.transform.RotateAround(pivotBegin, axis, anglePerUpdate);
            }
            journey += Time.deltaTime;
            yield return null;
        }
        foreach (EdgeSticker piece in pieces.edges)
        {
            roundRotation(tileAt(piece));
            roundPosition(tileAt(piece));
        }
        foreach (CornerSticker piece in pieces.corners)
        {
            roundRotation(tileAt(piece));
            roundPosition(tileAt(piece));
        }
        foreach (CenterSticker piece in pieces.centers)
        {
            roundRotation(tileAt(piece));
            roundPosition(tileAt(piece));
        }
        func(direction);
        rotating = false;
    }

    Vector3 getAxisAround(CenterSticker center)
    {
        return tileAt(center).transform.position - pivotBegin;
    }

    public void cubeIsMoved()
    {
        Vector3 uFacePos = tileAt(CenterSticker.U).transform.position;
        Vector3 dFacePos = tileAt(CenterSticker.D).transform.position;
        pivotBegin = (uFacePos + dFacePos) / 2;
    }

    private void Start()
    {
        cubeIsMoved();
    }

    /*
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                rotateR(CubeDirection.clockwise);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                rotateL(CubeDirection.clockwise);
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                rotateU(CubeDirection.clockwise);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                rotateD(CubeDirection.clockwise);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                rotateF(CubeDirection.clockwise);
            }
            if (Input.GetKeyDown(KeyCode.B))
            {
                rotateB(CubeDirection.clockwise);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                rotateE(CubeDirection.clockwise);
            }
            if (Input.GetKeyDown(KeyCode.M))
            {
                rotateM(CubeDirection.clockwise);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                rotateS(CubeDirection.clockwise);
            }
        }
        */

}