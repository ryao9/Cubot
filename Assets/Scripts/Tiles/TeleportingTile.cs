using System.Collections;
using UnityEngine;

class TeleportingTile : Tile
{
    public TeleportingTile other;
    public bool canDepartFromThisTile;
    CameraController cameraController;
    private bool teleported = false;

    protected bool teleportAttempted() { return teleported; }

    private static bool isTeleporting;

    private void Start()
    {
        loadMaterial();
        findCamera();
        setColor();
    }

    protected void loadMaterial()
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        Material teleportMaterial = Resources.Load("teleport_tile_material") as Material;
        GameObject teleport = Resources.Load("Prefabs/teleport") as GameObject;
        meshRenderer.material = teleportMaterial;
        GameObject childObject = Instantiate(teleport, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
        childObject.transform.parent = gameObject.transform;
        childObject.transform.localScale = new Vector3(0.9f, 7f, 0.9f);
        if (transform.name[0] == 'L')
        {
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
        }
        else if (transform.name[0] == 'R')
        {
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        }
        else if (transform.name[0] == 'U')
        {
        }
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

    protected void findCamera()
    {
        cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
    }

    protected void setColor()
    {
        if (colorIsSet())
        {
            if (other != null)
            {
                other.gameObject.GetComponent<Renderer>().material.color = tileColor;
                if (tileColor == Color.green)
                {
                    if (other.gameObject.transform.Find("teleport(Clone)") != null)
                    {
                        foreach (Transform eachChild in other.gameObject.transform.Find("teleport(Clone)"))
                        {
                            if (eachChild.name == "cylinder")
                            {
                                eachChild.GetComponent<MeshRenderer>().material = Resources.Load("Materials/teleport_green") as Material;
                            }
                            else
                            {
                                eachChild.GetComponent<MeshRenderer>().material = Resources.Load("Materials/teleport_green_ring") as Material;
                            }
                        }
                    }
                }
                else if (tileColor == Color.yellow)
                {
                    if (other.gameObject.transform.Find("teleport(Clone)") != null)
                    {
                        foreach (Transform eachChild in other.gameObject.transform.Find("teleport(Clone)"))
                        {
                            if (eachChild.name == "cylinder")
                            {
                                eachChild.GetComponent<MeshRenderer>().material = Resources.Load("Materials/teleport_yellow") as Material;
                            }
                            else
                            {
                                eachChild.GetComponent<MeshRenderer>().material = Resources.Load("Materials/teleport_yellow_ring") as Material;
                            }
                        }
                    }
                }
                else if (tileColor == Color.red)
                {
                    if (other.gameObject.transform.Find("teleport(Clone)") != null)
                    {
                        foreach (Transform eachChild in other.gameObject.transform.Find("teleport(Clone)"))
                        {
                            if (eachChild.name == "cylinder")
                            {
                                eachChild.GetComponent<MeshRenderer>().material = Resources.Load("Materials/teleport_red") as Material;
                            }
                            else
                            {
                                eachChild.GetComponent<MeshRenderer>().material = Resources.Load("Materials/teleport_red_ring") as Material;
                            }
                        }
                    }
                }
            }
            GetComponent<Renderer>().material.color = tileColor;
            if (tileColor == Color.green)
            {
                if (transform.Find("teleport(Clone)") != null)
                {
                    foreach (Transform eachChild in transform.Find("teleport(Clone)"))
                    {
                        if (eachChild.name == "cylinder")
                        {
                            eachChild.GetComponent<MeshRenderer>().material = Resources.Load("Materials/teleport_green") as Material;
                        }
                        else
                        {
                            eachChild.GetComponent<MeshRenderer>().material = Resources.Load("Materials/teleport_green_ring") as Material;
                        }
                    }
                }
            }
            else if (tileColor == Color.yellow)
            {
                if (transform.Find("teleport(Clone)") != null)
                {
                    foreach (Transform eachChild in transform.Find("teleport(Clone)"))
                    {
                        if (eachChild.name == "cylinder")
                        {
                            eachChild.GetComponent<MeshRenderer>().material = Resources.Load("Materials/teleport_yellow") as Material;
                        }
                        else
                        {
                            eachChild.GetComponent<MeshRenderer>().material = Resources.Load("Materials/teleport_yellow_ring") as Material;
                        }
                    }
                }
            }
            else if (tileColor == Color.red)
            {
                if (transform.Find("teleport(Clone)") != null)
                {
                    foreach (Transform eachChild in transform.Find("teleport(Clone)"))
                    {
                        if (eachChild.name == "cylinder")
                        {
                            eachChild.GetComponent<MeshRenderer>().material = Resources.Load("Materials/teleport_red") as Material;
                        }
                        else
                        {
                            eachChild.GetComponent<MeshRenderer>().material = Resources.Load("Materials/teleport_red_ring") as Material;
                        }
                    }
                }
            }
        }
    }
    public override bool canWalkOnTile()
    {
        return true;
    }

    public override void onPlayerEnter(GameObject player)
    {
        Debug.Log(isTeleporting);
        if (canDepartFromThisTile && !isTeleporting)
        {
            if (Input.GetKeyDown(InputManager.instance.action))
            {
                teleported = true;
                isTeleporting = true;
                Vector3 localPos = other.transform.localPosition;
                Vector3 pos = other.transform.position;

                Vector3 currPlayerPos = player.transform.position;
                Vector3 newPlayerPos = currPlayerPos;
                if (Mathf.Approximately(localPos.x, -1.5f))
                {
                    newPlayerPos = pos + new Vector3(-0.5f, 0, 0);
                }
                else if (Mathf.Approximately(localPos.x, 1.5f))
                {
                    newPlayerPos = pos + new Vector3(0.5f, 0, 0);
                }
                else if (Mathf.Approximately(localPos.z, -1.5f))
                {
                    newPlayerPos = pos + new Vector3(0, 0, -0.5f);
                }
                else if (Mathf.Approximately(localPos.z, 1.5f))
                {
                    newPlayerPos = pos + new Vector3(0, 0, 0.5f);
                }
                else if (Mathf.Approximately(localPos.y, 3f))
                {
                    newPlayerPos = pos + new Vector3(0, 0.5f, 0);
                }
                if (GameObject.Find("PlayerMovement") != null)
                {
                    Vector3 diff = newPlayerPos - currPlayerPos;
                    StartCoroutine(MoveCamera(diff, newPlayerPos, player));
                }
            }
        }
    }

    IEnumerator MoveCamera(Vector3 moveDist, Vector3 newPlayerPos, GameObject playerObject)
    {
        AudioManager.PlayClip(AudioManager.instance.teleport, Camera.main.transform.position, 0.7f);

        GameObject player = null;
        if (GameObject.Find("PlayerRobot") != null)
        {
            player = GameObject.Find("PlayerRobot");
            player.gameObject.SetActive(false);
        }

        // Find how to lerp camera from this cube to the target cube
        Vector3 thisCubePos = transform.parent.transform.parent.transform.position;
        Vector3 targetCubePos = other.transform.parent.transform.parent.transform.position;

        // if target tile is on a different tile - move camera before rotating direction
        if (thisCubePos != targetCubePos)
        {
            Vector3 currCameraPos = GameObject.Find("Main Camera").transform.position;
            Vector3 targetCameraPos = currCameraPos + moveDist;

            cameraController.enabled = false;

            float elapsedTime = 0;
            // Variable: time for camera movement
            float waitTime = 1f;

            while (elapsedTime <= waitTime)
            {
                GameObject.Find("Main Camera").transform.position = Vector3.Lerp(currCameraPos, targetCameraPos, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            cameraController.enabled = true;
        }

        if (player != null)
        {
            //player.gameObject.SetActive(true);
            playerObject.transform.position = newPlayerPos;
            if (GameObject.Find("PlayerVisual") != null)
            {
                GameObject.Find("PlayerVisual").GetComponent<FollowPlayer>().follow();
            }
            GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().OnCube();
            player.GetComponent<playerVisualRotation>().parentRotation();
            player.gameObject.SetActive(true);
        }

        int cubeSide = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().getCurrentCubeSide();
        string cameraDirection = cameraController.GetCurrentCameraDirection();
        Debug.Log(cubeSide);
        Debug.Log(cameraDirection);

        setCameraRotation(cubeSide, cameraDirection);
        isTeleporting = false;
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

    IEnumerator PlayerDisappear()
    {
        if (GameObject.Find("PlayerRobot") != null)
        {
            GameObject player = GameObject.Find("PlayerRobot");
            player.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            player.gameObject.SetActive(true);
        }
    }
}