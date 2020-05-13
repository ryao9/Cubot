using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    private PlayerMovement player_move;
    private CubeController cube;
    private bool player_move_enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        cube = GetComponent<CubeController>();
        player_move = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cube.isRotating())
        {
            player_move.enabled = false;
            player_move_enabled = false;
        }
        else if (!player_move_enabled)
        {
            player_move.enabled = true;
            player_move_enabled = true;
        }

        if (Input.GetKey(InputManager.instance.rot_c) && !cube.isRotating())
        {
            //Debug.Log("findEdge returned " + cube.findEdge(player_move.getCurrentTileObject()));
            //Debug.Log("findCenter returned " + cube.findCenter(player_move.getCurrentTileObject()));
            //Debug.Log("findCorner returned " + cube.findCorner(player_move.getCurrentTileObject()));

            switch (cube.findEdge(player_move.getCurrentTileObject()))
            {
                case EdgeSticker.UF:
                    //Debug.Log("UF");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.FU:
                    //Debug.Log("FU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.UL:
                    //Debug.Log("UL");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.LU:
                    //Debug.Log("LU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.UB:
                    //Debug.Log("UB");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.BU:
                    //Debug.Log("BU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.UR:
                    //Debug.Log("UR");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.RU:
                    //Debug.Log("RU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.DF:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.FD:
                    //Debug.Log("FD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.DL:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.LD:
                    //Debug.Log("LD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.DB:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.BD:
                    //Debug.Log("BD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.DR:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.RD:
                    //Debug.Log("RD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.FR:
                    //Debug.Log("FR");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateU(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateD(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.RF:
                    //Debug.Log("RF");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateD(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateU(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.FL:
                    //Debug.Log("FL");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateU(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateD(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.LF:
                    //Debug.Log("LF");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateU(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateD(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.BL:
                    //Debug.Log("BL");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateD(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateU(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.LB:
                    //Debug.Log("LB");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateU(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateD(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.BR:
                    //Debug.Log("BR");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateD(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateU(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.RB:
                    //Debug.Log("RB");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateD(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateU(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }

                    break;
            }

            switch (cube.findCenter(player_move.getCurrentTileObject()))
            {
                case CenterSticker.U:
                    //Debug.Log("U");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.clockwise);
                    }

                    break;
                case CenterSticker.D:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CenterSticker.F:
                    //Debug.Log("F");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateU(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateD(CubeDirection.clockwise);
                    }

                    break;
                case CenterSticker.B:
                    //Debug.Log("B");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateD(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateU(CubeDirection.clockwise);
                    }

                    break;
                case CenterSticker.L:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateU(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateD(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.clockwise);
                    }

                    break;
                case CenterSticker.R:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateD(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateU(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.clockwise);
                    }

                    break;
            }

            switch (cube.findCorner(player_move.getCurrentTileObject()))
            {
                case CornerSticker.UFL:
                    //Debug.Log("UFL");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.FLU:
                    //Debug.Log("FLU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }

                    break;
                case CornerSticker.LUF:
                    //Debug.Log("LUF");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.ULB:
                    //Debug.Log("ULB");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }

                    break;
                case CornerSticker.LBU:
                    //Debug.Log("LBU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }

                    break;
                case CornerSticker.BUL:
                    //Debug.Log("BUL");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.UBR:
                    //Debug.Log("UBR");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }

                    break;
                case CornerSticker.BRU:
                    //Debug.Log("BRU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.RUB:
                    //Debug.Log("RUB");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }

                    break;
                case CornerSticker.URF:
                    //Debug.Log("URF");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.RFU:
                    //Debug.Log("RFU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.FUR:
                    //Debug.Log("FUR");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }

                    break;
                case CornerSticker.DLF:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.LFD:
                    //Debug.Log("LFD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.FDL:
                    //Debug.Log("FDL");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.DBL:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.BLD:
                    //Debug.Log("BLD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }

                    break;
                case CornerSticker.LDB:
                    //Debug.Log("LBD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }

                    break;
                case CornerSticker.DRB:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.RBD:
                    //Debug.Log("RBD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }

                    break;
                case CornerSticker.BDR:
                    //Debug.Log("BDR");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }

                    break;
                case CornerSticker.DFR:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.FRD:
                    //Debug.Log("FRD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.RDF:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
            }

        }
        if (Input.GetKey(InputManager.instance.rot_a) && !cube.isRotating())
        {
            switch (cube.findEdge(player_move.getCurrentTileObject()))
            {
                case EdgeSticker.UF:
                    //Debug.Log("UF");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.FU:
                    //Debug.Log("FU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.UL:
                    //Debug.Log("UL");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.LU:
                    //Debug.Log("LU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.UB:
                    //Debug.Log("UB");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.BU:
                    //Debug.Log("BU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.UR:
                    //Debug.Log("UR");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.RU:
                    //Debug.Log("RU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.DF:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.FD:
                    //Debug.Log("FD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.DL:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.LD:
                    //Debug.Log("LD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.DB:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.BD:
                    //Debug.Log("BD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }

                    break;
                case EdgeSticker.DR:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.RD:
                    //Debug.Log("RD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.FR:
                    //Debug.Log("FR");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateU(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateD(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.RF:
                    //Debug.Log("RF");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateD(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateU(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.FL:
                    //Debug.Log("FL");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateU(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateD(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.LF:
                    //Debug.Log("LF");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateU(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateD(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case EdgeSticker.BL:
                    //Debug.Log("BL");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateD(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateU(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.LB:
                    //Debug.Log("LB");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateU(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateD(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.BR:
                    //Debug.Log("BR");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateD(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateU(CubeDirection.anticlockwise);
                    }

                    break;
                case EdgeSticker.RB:
                    //Debug.Log("RB");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateD(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateU(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }

                    break;
            }

            switch (cube.findCenter(player_move.getCurrentTileObject()))
            {
                case CenterSticker.U:
                    //Debug.Log("U");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.anticlockwise);
                    }

                    break;
                case CenterSticker.D:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CenterSticker.F:
                    //Debug.Log("F");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateU(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateD(CubeDirection.anticlockwise);
                    }

                    break;
                case CenterSticker.B:
                    //Debug.Log("B");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateR(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateL(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateD(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateU(CubeDirection.anticlockwise);
                    }

                    break;
                case CenterSticker.L:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateU(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateD(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.anticlockwise);
                    }

                    break;
                case CenterSticker.R:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateD(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateU(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateB(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateF(CubeDirection.anticlockwise);
                    }

                    break;
            }

            switch (cube.findCorner(player_move.getCurrentTileObject()))
            {
                case CornerSticker.UFL:
                    //Debug.Log("UFL");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.FLU:
                    //Debug.Log("FLU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }

                    break;
                case CornerSticker.LUF:
                    //Debug.Log("LUF");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.ULB:
                    //Debug.Log("ULB");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }

                    break;
                case CornerSticker.LBU:
                    //Debug.Log("LBU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }

                    break;
                case CornerSticker.BUL:
                    //Debug.Log("BUL");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.UBR:
                    //Debug.Log("UBR");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }

                    break;
                case CornerSticker.BRU:
                    //Debug.Log("BRU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.RUB:
                    //Debug.Log("RUB");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }

                    break;
                case CornerSticker.URF:
                    //Debug.Log("URF");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.RFU:
                    //Debug.Log("RFU");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.FUR:
                    //Debug.Log("FUR");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateE(CubeDirection.anticlockwise);
                    }

                    break;
                case CornerSticker.DLF:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.LFD:
                    //Debug.Log("LFD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.FDL:
                    //Debug.Log("FDL");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.DBL:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.BLD:
                    //Debug.Log("BLD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateM(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }

                    break;
                case CornerSticker.LDB:
                    //Debug.Log("LBD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }

                    break;
                case CornerSticker.DRB:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.RBD:
                    //Debug.Log("RBD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateS(CubeDirection.anticlockwise);
                    }

                    break;
                case CornerSticker.BDR:
                    //Debug.Log("BDR");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }

                    break;
                case CornerSticker.DFR:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.FRD:
                    //Debug.Log("FRD");
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateM(CubeDirection.anticlockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
                case CornerSticker.RDF:
                    if (player_move.getCurrentPlayerDirection() == Vector3.forward)
                    { }
                    if (player_move.getCurrentPlayerDirection() == Vector3.back)
                    {
                        cube.rotateE(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.left)
                    {
                        cube.rotateS(CubeDirection.clockwise);
                    }
                    if (player_move.getCurrentPlayerDirection() == Vector3.right)
                    { }

                    break;
            }
        }
    }

}