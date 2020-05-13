using System;
using System.Collections;
using UnityEngine;

class KeyTile : Tile
{
    public LockTile lockTile;
    CameraController cameraController;

    public bool moveCamera = false;

    public override bool canWalkOnTile()
    {
        return true;
    }

    private void Start()
    {
        Renderer render = GetComponentInParent<MeshRenderer>();
        render.material.color = Color.yellow;
        instantiateButton(new Vector3(1f, 10f, 1f));
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    bool unlocked = false;
    /*
    private void Update()
    {
        if (!unlocked)
        {
            if (lockTile != null) lockTile.unlock();
            unlocked = true;
        }
    }
    */

    public override void onPlayerEnter(GameObject player)
    {
        lockTile.unlock();
        if (transform.Find("button(Clone)") != null)
        {
            transform.Find("button(Clone)").GetComponent<Animator>().SetTrigger("buttonPress");
        }

        // TODO: camera move to lock tile
        if (!unlocked && moveCamera)
        {
            StartCoroutine(MoveCamera());
        }
        unlocked = true;
    }

    void instantiateButton(Vector3 scale)
    {
        GameObject childObject = Instantiate(Resources.Load("Prefabs/button", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        childObject.transform.parent = gameObject.transform;
        childObject.transform.localScale = scale;
        if (transform.name[0] == 'L')
        {
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
        }
        else if (transform.name[0] == 'R')
        {
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        }
        else if (transform.name[0] == 'U') { }
        else if (transform.name[0] == 'F')
        {
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
        }
        else if (transform.name[0] == 'B')
        {
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
        }
        else if (transform.name[0] == 'D')
        {
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(180f, 0f, 0f));
        }
    }

    IEnumerator MoveCamera()
    {
        GameObject player = GameObject.Find("PlayerMovement");
        
        yield return new WaitForSeconds(0.2f);

        Vector3 thisCubePos = transform.parent.transform.parent.transform.position;
        Vector3 targetCubePos = lockTile.transform.parent.transform.parent.transform.position;

        Vector3 thisTilePos = gameObject.transform.position;
        Vector3 targetTilePos = lockTile.transform.position;
        Vector3 moveDist = lockTile.transform.position - gameObject.transform.position;

        //int cubeSide = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().getCurrentCubeSide();
        //string cameraDirection = cameraController.GetCurrentCameraDirection();

        Vector3 originalCameraPos = GameObject.Find("Main Camera").transform.position;
        Vector3 targetCameraPos = originalCameraPos + moveDist;

        cameraController.enabled = false;

        // Move to lock tile
        if (thisCubePos != targetCubePos)
        {
            Vector3 fromPos = originalCameraPos;
            Vector3 toPos = targetCameraPos;

            float elapsedTime = 0;
            // Variable: time for camera movement
            float waitTime = 1f;

            while (elapsedTime <= waitTime)
            {
                GameObject.Find("Main Camera").transform.position = Vector3.Lerp(fromPos, toPos, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            GameObject.Find("Main Camera").transform.position = toPos;
        }
        Debug.Log(originalCameraPos);

        // Move back to player position
        if (thisCubePos != targetCubePos)
        {
            yield return new WaitForSeconds(0.5f);

            Vector3 fromPos = targetCameraPos;
            Vector3 toPos = cameraController.offset + player.transform.position;

            //Debug.Log("2!! curr = " + currCameraPos);
            //Debug.Log("2!! tar = " + targetCameraPos);

            float elapsedTime = 0;
            // Variable: time for camera movement
            float waitTime = 1f;

            while (elapsedTime <= waitTime)
            {
                GameObject.Find("Main Camera").transform.position = Vector3.Lerp(fromPos, toPos, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            GameObject.Find("Main Camera").transform.position = toPos;
        }

        Debug.Log(originalCameraPos);

        cameraController.enabled = true;
        //player.SetActive(true);

        //setCameraRotation(cubeSide, cameraDirection);


    }

    void setCameraRotation(int cubeSide, string cameraDirection)
    {
        if (cubeSide == 2)
        {
            if (cameraDirection == "forward") cameraController.RotateCameraCounterClockwise();
            else if (cameraDirection == "right") cameraController.RotateCameraTwice();
            else if (cameraDirection == "back") cameraController.RotateCameraClockwise();
        }
        else if (cubeSide == 5)
        {
            if (cameraDirection == "right") cameraController.RotateCameraCounterClockwise();
            else if (cameraDirection == "back") cameraController.RotateCameraTwice();
            else if (cameraDirection == "left") cameraController.RotateCameraClockwise();
        }
        else if (cubeSide == 1)
        {
            if (cameraDirection == "left") cameraController.RotateCameraCounterClockwise();
            else if (cameraDirection == "forward") cameraController.RotateCameraTwice();
            else if (cameraDirection == "right") cameraController.RotateCameraClockwise();
        }
        else if (cubeSide == 4)
        {
            if (cameraDirection == "back") cameraController.RotateCameraCounterClockwise();
            else if (cameraDirection == "left") cameraController.RotateCameraTwice();
            else if (cameraDirection == "forward") cameraController.RotateCameraClockwise();
        }
    }

}