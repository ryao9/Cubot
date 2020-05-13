using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float turnSpeed = 90f;
    public float cameraRotateTime = 0.8f;
    public bool isRotating = false;

    public Vector3 offset = new Vector3(0f, 6.0f, -5f);
    Vector3 originalOffset = new Vector3(0f, 6.0f, -5f);

    // data for peek mode
    private Vector3 peekModeOffset;
    private float peekModeScale = 1f;
    public float peekModeScaleUpperBound = 2f;
    public float peekModeScaleLowerBound = 0.8f;
    float peekModeRotateSpeed = 2.5f;
    bool isPeekMode = false;
    private GameObject peekModeUI;

    string[] cameraDirections = { "forward", "left", "back", "right" };
    int currentCameraDirectionIdx = 0;
    string currentCameraDirection;

    private PlayerMovement playerMovement;

    void Start()
    {
        peekModeUI = GameObject.Find("PeekModeCanvas");
        Debug.Log("ahhhhh");
        Debug.Log(peekModeUI);
        playerMovement = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>();
        transform.position = player.position + offset;
        transform.LookAt(player.position);
        currentCameraDirection = cameraDirections[currentCameraDirectionIdx];

        ResetPeekModeData();
    }

    private void Update()
    {
        if (isRotating) return;

        bool updateForPeekMode = false;

        if (InputManager.instance.controller_mode)
        {
            if (Input.GetAxis("RHorizontal") == -1) // continuously rotate cube counterclockwise
            {
                updateForPeekMode = true;
                peekModeOffset = Quaternion.AngleAxis(peekModeRotateSpeed, Vector3.up) * peekModeOffset;
            }
            else if (Input.GetAxis("RHorizontal") == 1) // continuously rotate cube clockwise
            {
                updateForPeekMode = true;
                peekModeOffset = Quaternion.AngleAxis(-1 * peekModeRotateSpeed, Vector3.up) * peekModeOffset;
            }
            else if (Input.GetAxis("RVertical") == 1) // Zoom out
            {
                updateForPeekMode = true;
                if (peekModeScale * 1.1f > peekModeScaleUpperBound) return;
                peekModeScale *= 1.1f;
            }
            else if (Input.GetAxis("RVertical") == -1) // Zoom in
            {
                updateForPeekMode = true;
                if (peekModeScale * 0.9f < peekModeScaleLowerBound) return;
                peekModeScale *= 0.9f;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow)) // continuously rotate cube counterclockwise
            {
                updateForPeekMode = true;
                peekModeOffset = Quaternion.AngleAxis(peekModeRotateSpeed, Vector3.up) * peekModeOffset;
            }
            else if (Input.GetKey(KeyCode.RightArrow)) // continuously rotate cube clockwise
            {
                updateForPeekMode = true;
                peekModeOffset = Quaternion.AngleAxis(-1 * peekModeRotateSpeed, Vector3.up) * peekModeOffset;
            }
            else if (Input.GetKey(KeyCode.UpArrow)) // Zoom out
            {
                updateForPeekMode = true;
                if (peekModeScale * 1.1f > peekModeScaleUpperBound) return;
                peekModeScale *= 1.1f;
            }
            else if (Input.GetKey(KeyCode.DownArrow)) // Zoom in
            {
                updateForPeekMode = true;
                if (peekModeScale * 0.9f < peekModeScaleLowerBound) return;
                peekModeScale *= 0.9f;
            }
        }

        if (updateForPeekMode)
        {
            isPeekMode = true;
            peekModeUI.GetComponent<Canvas>().enabled = true;
            playerMovement.enabled = false;
            transform.position = player.position + peekModeOffset * peekModeScale;
            transform.LookAt(player.position);
        }

        else if (isPeekMode && Input.anyKey) // Exit from peek mode
        {
            // allow cube rotate
            if (GameObject.Find("PlayerMovement") != null && GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>() != null)
            {
                if (GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().getOnCube())
                {
                    if (Input.GetKey(InputManager.instance.rot_c) || Input.GetKey(InputManager.instance.rot_a))
                    {
                        return;
                    }
                }
            }
            StartCoroutine(RotateBackToPlayer());
        }
        else if (!isPeekMode) // Not peek mode: update camera position according to player
        {
            transform.position = player.position + offset;
            transform.LookAt(player.position);
        }
    }

    void UpdateCurrentCameraDirection(bool isLeftPressed)
    {
        currentCameraDirectionIdx += isLeftPressed ? 1 : -1;
        if (currentCameraDirectionIdx == 4) currentCameraDirectionIdx = 0;
        else if (currentCameraDirectionIdx == -1) currentCameraDirectionIdx = 3;
        currentCameraDirection = cameraDirections[currentCameraDirectionIdx];
    }

    public string GetCurrentCameraDirection()
    {
        return currentCameraDirection;
    }

    public void RotateCameraClockwise()
    {
        if (isRotating) return;
        // TODO: check that player won't move fast enough to trigger a second
        // camera rotation when the first is not done.
        StartCoroutine(RotateCameraWithAngle(-90));
        UpdateCurrentCameraDirection(false);
    }

    public void RotateCameraCounterClockwise()
    {
        if (isRotating) return;
        StartCoroutine(RotateCameraWithAngle(90));
        UpdateCurrentCameraDirection(true);
    }

    public void RotateCameraTwice()
    {
        if (isRotating) return;
        StartCoroutine(RotateCameraWithAngle(180));
        UpdateCurrentCameraDirection(true);
        UpdateCurrentCameraDirection(true);
    }

    IEnumerator ReturnToOriginalPosition()
    {
        isRotating = true;

        Vector3 targetPos = player.position + offset;
        float elapsedTime = 0;
        float waitTime = cameraRotateTime;
        Vector3 currentPos = transform.position;

        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(currentPos, targetPos, (elapsedTime / waitTime));
            transform.LookAt(player.position);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = player.position + offset;
        transform.LookAt(player.position);

        playerMovement.setAllowInput(true);
        isRotating = false;
    }

    IEnumerator RotateBackToPlayer()
    {
        isRotating = true;
        playerMovement.enabled = false;

        Vector3 targetPos = player.position + offset;
        float elapsedTime = 0;
        float waitTime = 0.3f;
        Vector3 currentPos = transform.position;

        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Slerp(currentPos, targetPos, (elapsedTime / waitTime));
            transform.LookAt(player.position);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = player.position + offset;
        transform.LookAt(player.position);

        playerMovement.enabled = true;
        isRotating = false;
        isPeekMode = false;
        ResetPeekModeData();
        peekModeUI.GetComponent<Canvas>().enabled = false;
    }


    // GENERALIZING CODE!!!!

    IEnumerator RotateCameraWithAngle(int angle)
    {
        isRotating = true;
        playerMovement.enabled = false;

        Vector3 originalMoveDist = Quaternion.AngleAxis(angle, Vector3.up) * offset;
        Vector3 moveDist;
        float elapsedTime = 0;
        float deltaTime = 0;
        float waitTime = cameraRotateTime;

        // Calculate a portion of the angel at a time, eventually adding up to 180
        while (elapsedTime < waitTime)
        {
            moveDist = Quaternion.AngleAxis(angle * (deltaTime / waitTime), Vector3.up) * offset;
            transform.position = player.position + moveDist;
            transform.LookAt(player.position);
            elapsedTime += Time.deltaTime;
            deltaTime = Time.deltaTime;
            offset = moveDist;
            yield return null;
        }

        transform.position = player.position + originalMoveDist;
        transform.LookAt(player.position);
        offset = originalMoveDist;
        ResetPeekModeData();

        playerMovement.enabled = true;
        isRotating = false;
    }

    void ResetPeekModeData()
    {
        peekModeOffset = offset;
        peekModeScale = 1f;
    }
    public bool isPeek()
    {
        return isPeekMode;
    }

}
