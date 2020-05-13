//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class RotateDirection : MonoBehaviour
//{
//    private PlayerMovement player_move;
//    private CubeController cube;

//    void Start()
//    {
//        player_move = GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>();
//        cube = GetComponent<CubeController>();
//    }

      // Returns true if Q is left of player, false otherwise
//    public bool Direction()
//    {
//        switch (cube.findEdge(player_move.getCurrentTileObject()))
//        {
//            case EdgeSticker.UF:
//                //Debug.Log("UF");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    return true;
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    return true;
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    return false;
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case EdgeSticker.FU:
//                //Debug.Log("FU");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesR(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesL(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.UL:
//                //Debug.Log("UL");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesB(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesF(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.LU:
//                //Debug.Log("LU");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesB(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesF(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.UB:
//                //Debug.Log("UB");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesR(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesL(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.BU:
//                //Debug.Log("BU");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesR(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesL(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case EdgeSticker.UR:
//                //Debug.Log("UR");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesB(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesF(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.RU:
//                //Debug.Log("RU");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesB(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesF(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.DF:
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                }

//                break;
//            case EdgeSticker.FD:
//                //Debug.Log("FD");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesR(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesL(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case EdgeSticker.DL:
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                }

//                break;
//            case EdgeSticker.LD:
//                //Debug.Log("LD");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesB(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesF(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.DB:
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                }

//                break;
//            case EdgeSticker.BD:
//                //Debug.Log("BD");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesR(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesL(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.DR:
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                }

//                break;
//            case EdgeSticker.RD:
//                //Debug.Log("RD");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesB(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesF(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.FR:
//                //Debug.Log("FR");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesU(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesD(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.RF:
//                //Debug.Log("RF");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesD(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesU(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case EdgeSticker.FL:
//                //Debug.Log("FL");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesU(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesD(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.LF:
//                //Debug.Log("LF");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesU(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesD(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case EdgeSticker.BL:
//                //Debug.Log("BL");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesD(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesU(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.LB:
//                //Debug.Log("LB");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesU(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesD(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.BR:
//                //Debug.Log("BR");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesD(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesU(CubeDirection.clockwise));

//                }

//                break;
//            case EdgeSticker.RB:
//                //Debug.Log("RB");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesD(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesU(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }

//                break;
//        }

//        switch (cube.findCenter(player_move.getCurrentTileObject()))
//        {
//            case CenterSticker.U:
//                //Debug.Log("U");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesR(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesL(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesB(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesF(CubeDirection.clockwise));

//                }

//                break;
//            case CenterSticker.D:
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                }

//                break;
//            case CenterSticker.F:
//                //Debug.Log("F");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesR(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesL(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesU(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesD(CubeDirection.clockwise));

//                }

//                break;
//            case CenterSticker.B:
//                //Debug.Log("B");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesR(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesL(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesD(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesU(CubeDirection.clockwise));

//                }

//                break;
//            case CenterSticker.L:
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesU(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesD(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesB(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesF(CubeDirection.clockwise));

//                }

//                break;
//            case CenterSticker.R:
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesD(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesU(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesB(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesF(CubeDirection.clockwise));

//                }

//                break;
//        }

//        switch (cube.findCorner(player_move.getCurrentTileObject()))
//        {
//            case CornerSticker.UFL:
//                //Debug.Log("UFL");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case CornerSticker.FLU:
//                //Debug.Log("FLU");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }

//                break;
//            case CornerSticker.LUF:
//                //Debug.Log("LUF");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case CornerSticker.ULB:
//                //Debug.Log("ULB");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }

//                break;
//            case CornerSticker.LBU:
//                //Debug.Log("LBU");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }

//                break;
//            case CornerSticker.BUL:
//                //Debug.Log("BUL");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case CornerSticker.UBR:
//                //Debug.Log("UBR");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }

//                break;
//            case CornerSticker.BRU:
//                //Debug.Log("BRU");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case CornerSticker.RUB:
//                //Debug.Log("RUB");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }

//                break;
//            case CornerSticker.URF:
//                //Debug.Log("URF");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case CornerSticker.RFU:
//                //Debug.Log("RFU");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case CornerSticker.FUR:
//                //Debug.Log("FUR");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }

//                break;
//            case CornerSticker.DLF:
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                }

//                break;
//            case CornerSticker.LFD:
//                //Debug.Log("LFD");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case CornerSticker.FDL:
//                //Debug.Log("FDL");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case CornerSticker.DBL:
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                }

//                break;
//            case CornerSticker.BLD:
//                //Debug.Log("BLD");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }

//                break;
//            case CornerSticker.LDB:
//                //Debug.Log("LBD");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }

//                break;
//            case CornerSticker.DRB:
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                }

//                break;
//            case CornerSticker.RBD:
//                //Debug.Log("RBD");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }

//                break;
//            case CornerSticker.BDR:
//                //Debug.Log("BDR");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }

//                break;
//            case CornerSticker.DFR:
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                }

//                break;
//            case CornerSticker.FRD:
//                //Debug.Log("FRD");
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesM(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//            case CornerSticker.RDF:
//                if (player_move.getCurrentPlayerDirection() == Vector3.forward)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.back)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesE(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.left)
//                {
//                    HighlightSide(cube.cube.rotatingPiecesS(CubeDirection.clockwise));

//                }
//                if (player_move.getCurrentPlayerDirection() == Vector3.right)
//                {
//                    HighlightSide(new RotatingPieces(CubeDirection.anticlockwise));
//                }

//                break;
//        }
//    }
//}
