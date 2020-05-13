using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// VUBE SUMMARY
    /// GOAL
    /// SIDE 1
    /// SIDE 2 SIDE3 (TOP) SIDE4
    /// SIDE5
    /// VUBE SUMMARY

    public AnimationCurve playerMovementCurve;

    public bool allowInput = true;
    private float speed = 5.0f;
    public float hold_threshold = 0.09f; // required hold length before moving
    public float tap_threshold = 0.01f; // frames held to consider as tapping

    private int currentSide = 0; // currentSide == 0, not on cube
    private float distanceFromCube = 0.5f;
    private bool onCube = false;
    private playerVisualRotation playerVisualRotation;
    private Vector3 previousDirection = Vector3.forward;
    private Vector3 previousLocation;
    private Vector3 initial_direction;
    private int previousSide = 0;
    private CameraController cameraControl;
    private Animator playerAnimator;
    private MovementKeyHold key_hold;

    private Vector3 movement1;
    private Vector3 movement2;
    private Vector3 initial_position;
    private string cameraRotation = "";
    private string playerRotation = "";

    // for teleporting only
    bool isTeleported = false;

    public void setAllowInput(bool input)
    {
        allowInput = input;
    }

    // return tile object that the player is in contact with
    public GameObject getCurrentTileObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.z - hit.transform.position.z), distanceFromCube))
            {
                return hit.transform.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.back, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.z - hit.transform.position.z), distanceFromCube))
            {
                return hit.transform.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.x - hit.transform.position.x), distanceFromCube))
            {
                return hit.transform.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.x - hit.transform.position.x), distanceFromCube))
            {
                return hit.transform.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.y - hit.transform.position.y), distanceFromCube))
            {
                return hit.transform.gameObject;
            }
        }
        return null;
    }

    public CubeController getCurrentCubeController()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.z - hit.transform.position.z), distanceFromCube))
            {
                return hit.transform.parent.parent.GetComponent<CubeController>();
            }
        }
        if (Physics.Raycast(transform.position, Vector3.back, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.z - hit.transform.position.z), distanceFromCube))
            {
                return hit.transform.parent.parent.GetComponent<CubeController>();
            }
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.x - hit.transform.position.x), distanceFromCube))
            {
                return hit.transform.parent.parent.GetComponent<CubeController>();
            }
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.x - hit.transform.position.x), distanceFromCube))
            {
                return hit.transform.parent.parent.GetComponent<CubeController>();
            }
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.y - hit.transform.position.y), distanceFromCube))
            {
                return hit.transform.parent.parent.GetComponent<CubeController>();
            }
        }
        return null;
    }

    public GameObject getCurrentCube()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.z - hit.transform.position.z), distanceFromCube))
            {
                return hit.transform.parent.parent.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.back, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.z - hit.transform.position.z), distanceFromCube))
            {
                return hit.transform.parent.parent.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.x - hit.transform.position.x), distanceFromCube))
            {
                return hit.transform.parent.parent.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.x - hit.transform.position.x), distanceFromCube))
            {
                return hit.transform.parent.parent.gameObject;
            }
        }
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.y - hit.transform.position.y), distanceFromCube))
            {
                return hit.transform.parent.parent.gameObject;
            }
        }
        return null;
    }

    // returns current player's direction
    public Vector3 getCurrentPlayerDirection()
    {
        return previousDirection;
    }

    // returns current player's cube side
    public int getCurrentCubeSide()
    {
        return currentSide;
    }

    // returns whether the player is on Cube or not
    public bool getOnCube()
    {
        return onCube;
    }

    public void Right()
    {
        bool turn = false;
        setPreviousLocation();
        if (cameraControl.GetCurrentCameraDirection() == "back")
        {
            if (previousDirection != Vector3.left)
            {
                playerVisualRotation.faceLeft();
                previousDirection = Vector3.left;
                turn = true;
            }
        }
        else if (cameraControl.GetCurrentCameraDirection() == "left")
        {
            if (previousDirection != Vector3.back)
            {
                playerVisualRotation.faceBack();
                previousDirection = Vector3.back;
                turn = true;
            }
        }
        else if (cameraControl.GetCurrentCameraDirection() == "right")
        {
            if (previousDirection != Vector3.forward)
            {
                playerVisualRotation.faceForward();
                previousDirection = Vector3.forward;
                turn = true;
            }
        }
        else if (cameraControl.GetCurrentCameraDirection() == "forward")
        {
            if (previousDirection != Vector3.right)
            {
                playerVisualRotation.faceRight();
                previousDirection = Vector3.right;
                turn = true;
            }
        }

        if (!turn)
        {
            if (cameraControl.GetCurrentCameraDirection() == "forward") RightMove();
            else if (cameraControl.GetCurrentCameraDirection() == "right") UpMove();
            else if (cameraControl.GetCurrentCameraDirection() == "left") BackMove();
            else LeftMove();
            if (onCube) MovingOutOfCubeSide();
        }
    }

    public void Down()
    {
        bool turn = false;
        setPreviousLocation();
        if (cameraControl.GetCurrentCameraDirection() == "back")
        {
            if (previousDirection != Vector3.forward)
            {
                playerVisualRotation.faceForward();
                previousDirection = Vector3.forward;
                turn = true;
            }
        }
        else if (cameraControl.GetCurrentCameraDirection() == "left")
        {
            if (previousDirection != Vector3.left)
            {
                playerVisualRotation.faceLeft();
                previousDirection = Vector3.left;
                turn = true;
            }
        }
        else if (cameraControl.GetCurrentCameraDirection() == "right")
        {
            if (previousDirection != Vector3.right)
            {
                playerVisualRotation.faceRight();
                previousDirection = Vector3.right;
                turn = true;
            }
        }
        else if (cameraControl.GetCurrentCameraDirection() == "forward")
        {
            if (previousDirection != Vector3.back)
            {
                playerVisualRotation.faceBack();
                previousDirection = Vector3.back;
                turn = true;
            }
        }

        if (!turn)
        {
            if (cameraControl.GetCurrentCameraDirection() == "forward") BackMove();
            else if (cameraControl.GetCurrentCameraDirection() == "right") RightMove();
            else if (cameraControl.GetCurrentCameraDirection() == "left") LeftMove();
            else UpMove();
            if (onCube) MovingOutOfCubeSide();
        }
    }

    public void Up()
    {
        bool turn = false;
        setPreviousLocation();
        if (cameraControl.GetCurrentCameraDirection() == "back")
        {
            if (previousDirection != Vector3.back)
            {
                playerVisualRotation.faceBack();
                previousDirection = Vector3.back;
                turn = true;
            }
        }
        else if (cameraControl.GetCurrentCameraDirection() == "left")
        {
            if (previousDirection != Vector3.right)
            {
                playerVisualRotation.faceRight();
                previousDirection = Vector3.right;
                turn = true;
            }
        }
        else if (cameraControl.GetCurrentCameraDirection() == "right")
        {
            if (previousDirection != Vector3.left)
            {
                playerVisualRotation.faceLeft();
                previousDirection = Vector3.left;
                turn = true;
            }
        }
        else if (cameraControl.GetCurrentCameraDirection() == "forward")
        {
            if (previousDirection != Vector3.forward)
            {
                playerVisualRotation.faceForward();
                previousDirection = Vector3.forward;
                turn = true;
            }
        }

        if (!turn)
        {
            if (cameraControl.GetCurrentCameraDirection() == "forward") UpMove();
            else if (cameraControl.GetCurrentCameraDirection() == "right") LeftMove();
            else if (cameraControl.GetCurrentCameraDirection() == "left") RightMove();
            else BackMove();
            if (onCube) MovingOutOfCubeSide();
        }
    }

    public void Left()
    {
        bool turn = false;
        setPreviousLocation();
        if (cameraControl.GetCurrentCameraDirection() == "back")
        {
            if (previousDirection != Vector3.right)
            {
                playerVisualRotation.faceRight();
                previousDirection = Vector3.right;
                turn = true;
            }
        }
        else if (cameraControl.GetCurrentCameraDirection() == "left")
        {
            if (previousDirection != Vector3.forward)
            {
                playerVisualRotation.faceForward();
                previousDirection = Vector3.forward;
                turn = true;
            }
        }
        else if (cameraControl.GetCurrentCameraDirection() == "right")
        {
            if (previousDirection != Vector3.back)
            {
                playerVisualRotation.faceBack();
                previousDirection = Vector3.back;
                turn = true;
            }
        }
        else if (cameraControl.GetCurrentCameraDirection() == "forward")
        {
            if (previousDirection != Vector3.left)
            {
                playerVisualRotation.faceLeft();
                previousDirection = Vector3.left;
                turn = true;
            }
        }

        if (!turn)
        {
            if (cameraControl.GetCurrentCameraDirection() == "forward") LeftMove();
            else if (cameraControl.GetCurrentCameraDirection() == "right") BackMove();
            else if (cameraControl.GetCurrentCameraDirection() == "left") UpMove();
            else RightMove();
            if (onCube) MovingOutOfCubeSide();
        }
    }

    public void MovementCoroutine()
    {
        if (moveBack())
        {
            previousDirection = initial_direction;
        };

        if (isTeleported)
        {
            isTeleported = false;
            return;
        }

        transform.position = initial_position;
        if ((!Mathf.Approximately(initial_position.x, movement2.x) ||
                !Mathf.Approximately(initial_position.y, movement2.y) ||
                !Mathf.Approximately(initial_position.z, movement2.z)) &&
            (!Mathf.Approximately(movement1.x, movement2.x) ||
                !Mathf.Approximately(movement1.y, movement2.y) ||
                !Mathf.Approximately(movement1.z, movement2.z)))
        {
            StartCoroutine(doubleMoveCoroutine(movement1, movement2));

            if (cameraRotation != "")
            {
                if (cameraRotation == "c")
                {
                    cameraControl.RotateCameraClockwise();
                }
                else if (cameraRotation == "cc")
                {
                    cameraControl.RotateCameraCounterClockwise();
                }
                else if (cameraRotation == "t")
                {
                    cameraControl.RotateCameraTwice();
                }
            }

            if (playerRotation != "")
            {
                if (playerRotation == "f") playerVisualRotation.faceForward();
                else if (playerRotation == "r") playerVisualRotation.faceRight();
                else if (playerRotation == "l") playerVisualRotation.faceLeft();
                else if (playerRotation == "b") playerVisualRotation.faceBack();
            }

            playerVisualRotation.parentRotation();
        }
        else if (!Mathf.Approximately(initial_position.x, movement1.x) ||
            !Mathf.Approximately(initial_position.y, movement1.y) ||
            !Mathf.Approximately(initial_position.z, movement1.z))
        {
            StartCoroutine(moveCoroutine(movement1));
        }
        else
        {
            OnCube();
        }

        cameraRotation = "";
        playerRotation = "";
    }

    void Start()
    {
        playerVisualRotation = GameObject.Find("PlayerRobot").GetComponent<playerVisualRotation>();
        cameraControl = GameObject.Find("Main Camera").GetComponent<CameraController>();
        previousDirection = Vector3.forward;
        movement1 = transform.position;
        movement2 = transform.position;
        playerAnimator = GameObject.Find("PlayerRobot").GetComponent<Animator>();
        key_hold = GetComponent<MovementKeyHold>();
    }

    void Update()
    {
        if (allowInput)
        {
            initial_direction = previousDirection;
            movement1 = transform.position;
            movement2 = transform.position;
            initial_position = transform.position;

            if (Input.GetKeyDown(InputManager.instance.cheat))
            {
                Tile.setCheat(!Tile.getCheat());
            }

            if (InputManager.instance.controller_mode == false)
            {
                if (Input.GetKeyDown(InputManager.instance.right) || key_hold.right_held_duration > hold_threshold && key_hold.right_held_duration > key_hold.left_held_duration &&
                                                            key_hold.right_held_duration > key_hold.up_held_duration &&
                                                            key_hold.right_held_duration > key_hold.down_held_duration)
                {
                    Right();
                }
                else if (Input.GetKeyDown(InputManager.instance.left) || key_hold.left_held_duration > hold_threshold && key_hold.left_held_duration > key_hold.right_held_duration &&
                                                                key_hold.left_held_duration > key_hold.up_held_duration &&
                                                                key_hold.left_held_duration > key_hold.down_held_duration)
                {
                    Left();
                }
                else if (Input.GetKeyDown(InputManager.instance.down) || key_hold.down_held_duration > hold_threshold && key_hold.down_held_duration > key_hold.left_held_duration &&
                                                                key_hold.down_held_duration > key_hold.up_held_duration &&
                                                                key_hold.down_held_duration > key_hold.right_held_duration)
                {
                    Down();
                }
                else if (Input.GetKeyDown(InputManager.instance.up) || key_hold.up_held_duration > hold_threshold && key_hold.up_held_duration > key_hold.left_held_duration &&
                                                                key_hold.up_held_duration > key_hold.right_held_duration &&
                                                                key_hold.up_held_duration > key_hold.down_held_duration)
                {
                    Up();

                }
            }

            if (InputManager.instance.controller_mode == true)
            {
                if (key_hold.right_held_duration > hold_threshold)
                {
                    Right();
                }
                else if (key_hold.left_held_duration > hold_threshold)
                {
                    Left();
                }
                else if (key_hold.down_held_duration > hold_threshold)
                {
                    Down();
                }
                else if (key_hold.up_held_duration > hold_threshold)
                {
                    Up();
                }
            }

            MovementCoroutine();
        }
    }



    // Determines where to go when player press Up
    private void UpMove()
    {
        Vector3 current_position = transform.position;

        // if camera direction is forward
        if (onCube)
        {
            if (currentSide == 5)
            {
                current_position.y += 1;
            }
            else if (currentSide == 2 || currentSide == 3 || currentSide == 4)
            {
                current_position.z += 1;
            }
            else if (currentSide == 1)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit))
                {
                    if (hit.transform.tag == "water" && Mathf.Abs(transform.position.y - hit.transform.position.y) <= 0.60f)
                    {
                        return;
                    }
                    if (hit.transform.tag == "ground" && Mathf.Abs(transform.position.y - hit.transform.position.y) <= 0.50f)
                    {
                        current_position.z += 1;
                        movement1 = current_position;
                        transform.position = current_position;
                        return;
                    }
                }
                current_position.y -= 1;
            }
        }
        else
        {
            current_position.z += 1;
        }

        movement1 = current_position;
        transform.position = current_position;

        // else if camera direction is right

    }

    // Determines where to go when player press Up
    private void LeftMove()
    {
        Vector3 current_position = transform.position;

        // if camera direction is forward
        if (onCube)
        {
            if (currentSide == 5 || currentSide == 3 || currentSide == 1)
            {
                current_position.x -= 1;
            }
            else if (currentSide == 2)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit))
                {
                    if (hit.transform.tag == "water" && Mathf.Abs(transform.position.y - hit.transform.position.y) <= 0.60f)
                    {
                        return;
                    }
                    if (hit.transform.tag == "ground" && Mathf.Abs(transform.position.y - hit.transform.position.y) <= 0.50f)
                    {
                        current_position.x -= 1;
                        movement1 = current_position;
                        transform.position = current_position;
                        return;
                    }
                }

                current_position.y -= 1;
            }
            else if (currentSide == 4)
            {
                current_position.y += 1;
            }
        }
        else
        {
            current_position.x -= 1;
        }

        movement1 = current_position;
        transform.position = current_position;
    }

    // Determines where to go when player press Up
    private void BackMove()
    {
        Vector3 current_position = transform.position;

        // if camera direction is forward
        if (onCube)
        {
            if (currentSide == 5)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit))
                {
                    if (hit.transform.tag == "water" && Mathf.Abs(transform.position.y - hit.transform.position.y) <= 0.60f)
                    {
                        return;
                    }
                    if (hit.transform.tag == "ground" && Mathf.Abs(transform.position.y - hit.transform.position.y) <= 0.50f)
                    {
                        current_position.z -= 1;
                        movement1 = current_position;
                        transform.position = current_position;
                        return;
                    }
                }
                current_position.y -= 1;
            }
            else if (currentSide == 2 || currentSide == 3 || currentSide == 4)
            {
                current_position.z -= 1;
            }
            else if (currentSide == 1)
            {
                current_position.y += 1;
            }
        }
        else
        {
            current_position.z -= 1;
        }

        movement1 = current_position;
        transform.position = current_position;
    }

    // Determines where to go when player press Up
    private void RightMove()
    {
        Vector3 current_position = transform.position;

        // if camera direction is forward
        if (onCube)
        {
            if (currentSide == 5 || currentSide == 3 || currentSide == 1)
            {
                current_position.x += 1;
            }
            else if (currentSide == 2)
            {
                current_position.y += 1;
            }
            else if (currentSide == 4)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Vector3.down, out hit))
                {
                    if (hit.transform.tag == "water" && Mathf.Abs(transform.position.y - hit.transform.position.y) <= 0.60f)
                    {
                        return;
                    }
                    if (hit.transform.tag == "ground" && Mathf.Abs(transform.position.y - hit.transform.position.y) <= 0.50f)
                    {
                        current_position.x += 1;
                        movement1 = current_position;
                        transform.position = current_position;
                        return;
                    }
                }

                current_position.y -= 1;
            }
        }
        else
        {
            current_position.x += 1;
        }

        movement1 = current_position;
        transform.position = current_position;
    }

    // Updates the state of player whether the player is on cube or not
    public void OnCube()
    {
        RaycastHit hit;
        int tmpSide = 0;
        bool tmpOnCube = false;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit) && Mathf.Approximately(Mathf.Abs(transform.position.z - hit.transform.position.z), distanceFromCube))
        {
            if (hit.transform.tag == "Tile")
            {
                tmpSide = 5;
                tmpOnCube = true;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.back, out hit) && Mathf.Approximately(Mathf.Abs(transform.position.z - hit.transform.position.z), distanceFromCube))
        {
            if (hit.transform.tag == "Tile")
            {
                tmpSide = 1;
                tmpOnCube = true;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.left, out hit) && Mathf.Approximately(Mathf.Abs(transform.position.x - hit.transform.position.x), distanceFromCube))
        {
            if (hit.transform.tag == "Tile")
            {
                tmpSide = 4;
                tmpOnCube = true;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.right, out hit) && Mathf.Approximately(Mathf.Abs(transform.position.x - hit.transform.position.x), distanceFromCube))
        {
            if (hit.transform.tag == "Tile")
            {
                tmpSide = 2;
                tmpOnCube = true;
            }
        }
        else if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.transform.tag == "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.y - hit.transform.position.y), distanceFromCube))
            {
                tmpSide = 3;
                tmpOnCube = true;
            }
            else if (hit.transform.tag != "Tile" && Mathf.Approximately(Mathf.Abs(transform.position.y - hit.transform.position.y), 0.5f))
            {
                currentSide = 0;
                playerVisualRotation.parentRotation();
                onCube = false;
                return;
            }
        }

        if (tmpSide != 0)
        {
            playerVisualRotation.parentRotation();
            currentSide = tmpSide;
            if (!onCube && tmpOnCube)
            {
                if (currentSide == 5)
                {
                    if (cameraControl.GetCurrentCameraDirection() == "right")
                    {
                        cameraControl.RotateCameraCounterClockwise();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "left")
                    {
                        cameraControl.RotateCameraClockwise();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "back")
                    {
                        cameraControl.RotateCameraTwice();
                    }
                }
                else if (currentSide == 2)
                {
                    if (cameraControl.GetCurrentCameraDirection() == "right")
                    {
                        cameraControl.RotateCameraTwice();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "forward")
                    {
                        cameraControl.RotateCameraClockwise();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "back")
                    {
                        cameraControl.RotateCameraCounterClockwise();
                    }
                }
                else if (currentSide == 4)
                {
                    if (cameraControl.GetCurrentCameraDirection() == "left")
                    {
                        cameraControl.RotateCameraTwice();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "forward")
                    {
                        cameraControl.RotateCameraClockwise();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "back")
                    {
                        cameraControl.RotateCameraCounterClockwise();
                    }
                }
                else if (currentSide == 1)
                {
                    if (cameraControl.GetCurrentCameraDirection() == "left")
                    {
                        cameraControl.RotateCameraCounterClockwise();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "forward")
                    {
                        cameraControl.RotateCameraTwice();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "right")
                    {
                        cameraControl.RotateCameraClockwise();
                    }
                }
            }

            onCube = tmpOnCube;
        }
    }

    public void resetCameraRotation()
    {
        if (cameraControl.GetCurrentCameraDirection() == "left")
        {
            cameraControl.RotateCameraClockwise();
        }
        else if (cameraControl.GetCurrentCameraDirection() == "back")
        {
            cameraControl.RotateCameraTwice();
        }
        else if (cameraControl.GetCurrentCameraDirection() == "right")
        {
            cameraControl.RotateCameraCounterClockwise();
        }
    }

    private void setPreviousLocation()
    {
        previousLocation = transform.position;
        previousSide = currentSide;
    }

    // move the player back if on obstacle when not on the cube
    private bool moveBack()
    {
        bool return_value = false;
        RaycastHit hit;
        if (!onCube)
        {
            // if on water, do not walk on it
            if (Physics.Raycast(transform.position, Vector3.down, out hit))
            {
                if (hit.transform.tag == "water" && Mathf.Abs(transform.position.y - hit.transform.position.y) <= 5.05f)
                {
                    movement1 = initial_position;
                    return_value = true;
                }
                else if (hit.transform.tag == "goal" && Mathf.Abs(transform.position.y - hit.transform.position.y) <= 5.05f)
                {
                    if (GameObject.Find("Goal") != null)
                    {
                        GameObject.Find("Goal").GetComponent<goalRobot>().goalAnimation();
                    }
                    movement1 = initial_position;
                    return_value = true;
                }
            }

        }

        GameObject tileObject = getCurrentTileObject();
        if (tileObject != null)
        {
            Tile tile = Tile.fromObject(tileObject);
            if (tile == null) return false;
            if (!tile.canWalkOnTile())
            {
                movement1 = initial_position;
                movement2 = initial_position;
                currentSide = previousSide;
                return_value = true;
            }
            else
            {
                tile.onPlayerEnter(gameObject);
                if (transform.position != movement1
                    && transform.position != movement2)
                {
                    isTeleported = true;
                    return false;
                }
            }
        }

        return return_value;
    }

    // determines the new position of player when moving out of a cube's side
    private void MovingOutOfCubeSide()
    {
        Vector3 current_position = transform.position;
        RaycastHit hit;

        // if on ground, do not turn
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.transform.tag != "Tile"
                && hit.transform.tag != "water"
                && Mathf.Approximately(Mathf.Abs(transform.position.y - hit.transform.position.y), 0.5f))
            {
                return;
            }
        }

        if (currentSide == 5)
        {
            if (!Physics.Raycast(transform.position, Vector3.forward, out hit)
                || (Physics.Raycast(transform.position, Vector3.forward, out hit) &&
                    hit.transform.tag == "Tile" &&
                    !Mathf.Approximately(Mathf.Abs(transform.position.z - hit.transform.position.z), distanceFromCube)))
            {
                if (previousDirection == Vector3.right)
                {
                    playerRotation = "f";
                    //playerVisualRotation.faceForward();
                    previousDirection = Vector3.forward;
                    cameraRotation = "c";
                    //cameraControl.RotateCameraClockwise();
                    currentSide = 4;
                }
                else if (previousDirection == Vector3.left)
                {
                    playerRotation = "f";
                    //playerVisualRotation.faceForward();
                    previousDirection = Vector3.forward;
                    cameraRotation = "cc";
                    //cameraControl.RotateCameraCounterClockwise();
                    currentSide = 2;
                }
                else if (previousDirection == Vector3.forward)
                {
                    currentSide = 3;
                }
                else if (previousDirection == Vector3.back)
                {
                    currentSide = 0;
                }
                current_position.z += 1;
            }
        }
        else if (currentSide == 2)
        {
            if (!Physics.Raycast(transform.position, Vector3.right, out hit)
                || (Physics.Raycast(transform.position, Vector3.right, out hit) &&
                    hit.transform.tag == "Tile" &&
                    !Mathf.Approximately(Mathf.Abs(transform.position.x - hit.transform.position.x), distanceFromCube)))
            {
                if (previousDirection == Vector3.right)
                {
                    currentSide = 3;
                }
                else if (previousDirection == Vector3.left)
                {
                    currentSide = 0;
                }
                else if (previousDirection == Vector3.forward)
                {
                    playerRotation = "r";
                    previousDirection = Vector3.right;
                    cameraRotation = "cc";
                    currentSide = 1;
                }
                else if (previousDirection == Vector3.back)
                {
                    playerRotation = "r";
                    previousDirection = Vector3.right;
                    cameraRotation = "c";
                    currentSide = 5;
                }
                current_position.x += 1;
            }
        }
        else if (currentSide == 3)
        {
            if (!Physics.Raycast(transform.position, Vector3.down, out hit) ||
                (Physics.Raycast(transform.position, Vector3.down, out hit) && hit.transform.tag != "Tile") ||
                (Physics.Raycast(transform.position, Vector3.down, out hit) && hit.transform.tag == "Tile"
                    && !Mathf.Approximately(Mathf.Abs(transform.position.y - hit.transform.position.y), distanceFromCube)))
            {
                if (previousDirection == Vector3.right)
                {
                    if (cameraControl.GetCurrentCameraDirection() == "forward")
                    {
                        cameraRotation = "c";
                        //cameraControl.RotateCameraClockwise();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "back")
                    {
                        cameraRotation = "cc";
                        //cameraControl.RotateCameraCounterClockwise();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "left")
                    {
                        cameraRotation = "t";
                        //cameraControl.RotateCameraTwice();
                    }

                    currentSide = 4;
                }
                else if (previousDirection == Vector3.left)
                {
                    if (cameraControl.GetCurrentCameraDirection() == "forward")
                    {
                        cameraRotation = "cc";
                        //cameraControl.RotateCameraCounterClockwise();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "back")
                    {
                        cameraRotation = "c";
                        //cameraControl.RotateCameraClockwise();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "right")
                    {
                        cameraRotation = "t";
                        //cameraControl.RotateCameraTwice();
                    }

                    currentSide = 2;
                }
                else if (previousDirection == Vector3.forward)
                {
                    if (cameraControl.GetCurrentCameraDirection() == "forward")
                    {
                        cameraRotation = "t";
                        //cameraControl.RotateCameraTwice();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "left")
                    {
                        cameraRotation = "cc";
                        //cameraControl.RotateCameraCounterClockwise();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "right")
                    {
                        cameraRotation = "c";
                        //cameraControl.RotateCameraClockwise();
                    }

                    currentSide = 1;
                }
                else if (previousDirection == Vector3.back)
                {
                    if (cameraControl.GetCurrentCameraDirection() == "back")
                    {
                        cameraRotation = "t";
                        //cameraControl.RotateCameraTwice();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "left")
                    {
                        cameraRotation = "c";
                        //cameraControl.RotateCameraClockwise();
                    }
                    else if (cameraControl.GetCurrentCameraDirection() == "right")
                    {
                        cameraRotation = "cc";
                        //cameraControl.RotateCameraCounterClockwise();
                    }

                    currentSide = 5;
                }
                current_position.y -= 1;
            }
        }
        else if (currentSide == 4)
        {
            if (!Physics.Raycast(transform.position, Vector3.left, out hit)
                || (Physics.Raycast(transform.position, Vector3.left, out hit) &&
                    hit.transform.tag == "Tile" &&
                    !Mathf.Approximately(Mathf.Abs(transform.position.x - hit.transform.position.x), distanceFromCube)))
            {
                if (previousDirection == Vector3.right)
                {
                    currentSide = 0;
                }
                else if (previousDirection == Vector3.left)
                {
                    currentSide = 3;
                }
                else if (previousDirection == Vector3.forward)
                {
                    playerRotation = "l";
                    previousDirection = Vector3.left;
                    cameraRotation = "c";
                    currentSide = 1;
                }
                else if (previousDirection == Vector3.back)
                {
                    playerRotation = "l";
                    previousDirection = Vector3.left;
                    cameraRotation = "cc";
                    currentSide = 5;
                }
                current_position.x -= 1;
            }
        }
        else if (currentSide == 1)
        {
            if (!Physics.Raycast(transform.position, Vector3.back, out hit)
                || (Physics.Raycast(transform.position, Vector3.back, out hit) &&
                    hit.transform.tag == "Tile" &&
                    !Mathf.Approximately(Mathf.Abs(transform.position.z - hit.transform.position.z), distanceFromCube)))
            {
                if (previousDirection == Vector3.right)
                {
                    playerRotation = "b";
                    //playerVisualRotation.faceBack();
                    previousDirection = Vector3.back;
                    cameraRotation = "cc";
                    //cameraControl.RotateCameraCounterClockwise();
                    currentSide = 4;
                }
                else if (previousDirection == Vector3.left)
                {
                    playerRotation = "b";
                    //playerVisualRotation.faceBack();
                    previousDirection = Vector3.back;
                    cameraRotation = "c";
                    //cameraControl.RotateCameraClockwise();
                    currentSide = 2;
                }
                else if (previousDirection == Vector3.forward)
                {
                    currentSide = 0;
                }
                else if (previousDirection == Vector3.back)
                {
                    currentSide = 3;
                }
                current_position.z -= 1;
            }
        }

        transform.position = current_position;
        movement2 = current_position;
    }

    IEnumerator moveCoroutine(Vector3 new_position)
    {
        AudioManager.PlayClip(AudioManager.instance.walking, Camera.main.transform.position, 0.08f);

        // prevent the player sliding on the ground when moving away from the cube
        if (new_position.y == transform.position.y)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit)
                && hit.transform.tag != "Tile"
                && Mathf.Approximately(Mathf.Abs(transform.position.y - hit.transform.position.y), 0.5f))
            {
                if (currentSide == 5 || currentSide == 1)
                {
                    if ((previousDirection == Vector3.right || previousDirection == Vector3.left)
                        && Mathf.Approximately(new_position.x, transform.position.x)
                        && !Mathf.Approximately(new_position.z, transform.position.z))
                    {
                        currentSide = 0;
                        onCube = false;
                        playerVisualRotation.parentRotation();
                    }
                    else if ((previousDirection == Vector3.forward || previousDirection == Vector3.back)
                            && !Mathf.Approximately(new_position.z, transform.position.z)
                            && Mathf.Approximately(new_position.x, transform.position.x))
                    {
                        currentSide = 0;
                        onCube = false;
                        playerVisualRotation.parentRotation();
                    }
                }
                else if (currentSide == 2 || currentSide == 4)
                {
                    if ((previousDirection == Vector3.right || previousDirection == Vector3.left)
                        && !Mathf.Approximately(new_position.x, transform.position.x)
                        && Mathf.Approximately(new_position.z, transform.position.z))
                    {
                        currentSide = 0;
                        onCube = false;
                        playerVisualRotation.parentRotation();
                    }
                    else if ((previousDirection == Vector3.forward || previousDirection == Vector3.back)
                            && Mathf.Approximately(new_position.z, transform.position.z)
                            && !Mathf.Approximately(new_position.x, transform.position.x))
                    {
                        currentSide = 0;
                        onCube = false;
                        playerVisualRotation.parentRotation();
                    }
                }
            }
        }

        allowInput = false;
        float startTime = Time.time;
        Vector3 initial_position = transform.position;
        float journeyLength = Vector3.Distance(initial_position, new_position);

        float fractionOfJourney = 0;

        while (fractionOfJourney < 0.99f)
        {
            playerAnimator.SetTrigger("walk");
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;
            // Fraction of journey completed equals current distance divided by total distance.
            fractionOfJourney = distCovered / journeyLength;
            float curvePercentage = playerMovementCurve.Evaluate(fractionOfJourney);

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(initial_position, new_position, curvePercentage);

            yield return null;
        }

        transform.position = new_position;
        allowInput = true;
        OnCube();
    }

    IEnumerator doubleMoveCoroutine(Vector3 new_position1, Vector3 new_position2)
    {
        bool highlight_already_disabled = false;
        if (getCurrentCube() != null)
        {
            if (!getCurrentCube().GetComponent<RotateHighlight>().enabled) highlight_already_disabled = true;
            else getCurrentCube().GetComponent<RotateHighlight>().enabled = false;
        }

        allowInput = false;
        float startTime = Time.time;
        Vector3 lerp_initial_position = transform.position;
        float journeyLength = Vector3.Distance(lerp_initial_position, new_position1);

        float fractionOfJourney = 0;

        while (fractionOfJourney < 0.99f)
        {
            playerAnimator.SetTrigger("walk");
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            fractionOfJourney = distCovered / journeyLength;
            float curvePercentage = playerMovementCurve.Evaluate(fractionOfJourney);

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(lerp_initial_position, new_position1, curvePercentage);

            yield return null;
        }

        transform.position = new_position1;

        startTime = Time.time;
        lerp_initial_position = transform.position;
        journeyLength = Vector3.Distance(lerp_initial_position, new_position2);
        fractionOfJourney = 0;

        while (fractionOfJourney < 0.99f)
        {
            playerAnimator.SetTrigger("walk");
            // Distance moved equals elapsed time times speed..
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            fractionOfJourney = distCovered / journeyLength;
            float curvePercentage = playerMovementCurve.Evaluate(fractionOfJourney);

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(lerp_initial_position, new_position2, curvePercentage);

            yield return null;
        }

        transform.position = new_position2;
        allowInput = true;
        if (getCurrentCube() != null)
        {
            if (!highlight_already_disabled) getCurrentCube().GetComponent<RotateHighlight>().enabled = true;
        }
        OnCube();
    }
}
