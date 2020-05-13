/* 
    Manages the internal representation of the cube. 
*/

using System;
using System.Collections;
using System.Collections.Generic;

/*
Enums for 
1. representing the corner/edge stickers of the cube 
2. indexing into the array of corner/edge stickers

Notation: 
U stands for top face (Up)
D stands for down face (Down)
L stands for left face (Left)
R stands for right face (Right)
F stands for front face (Front)
B stands for back face (Back)

Notation for edge sticker:
XY means the X sticker of the edge piece on the intersection between X face and Y face.
For example, if the cube is placed with the white face on top and the green face in front, then UF would mean the *position of* the white sticker on the white-green piece and FU would mean the *position of* the green sticker on that piece.
If the top face is rotated clockwise by 90 degrees then UF would point to the white sticker on the white-red sticker.

Notation for corner sticker:
XYZ means the X sticker of the corner piece on the intersection between X face, Y face, and the Z face.
For example, if the cube is placed with the white face on top and the green face in front, then UFL or ULF would mean the white sticker on the white-green-orange piece, FUL or FLU would mean the green sticker on that piece, and LUF or LFU would mean the orange sticker on that piece.
 */
public struct AdjacentSticker
{
    public CornerSticker corner;
    public EdgeSticker edge;
    public CenterSticker center;
}

public enum CenterSticker : int
{
    U,
    D,
    F,
    B,
    L,
    R,
    numCenters
}

public enum EdgeSticker : int
{
    UF,
    FU,
    UL,
    LU,
    UB,
    BU,
    UR,
    RU,
    DF,
    FD,
    DL,
    LD,
    DB,
    BD,
    DR,
    RD,
    FR,
    RF,
    FL,
    LF,
    BL,
    LB,
    BR,
    RB,
    numEdges
}
public enum CornerSticker : int
{
    UFL,
    FLU,
    LUF,
    ULB,
    LBU,
    BUL,
    UBR,
    BRU,
    RUB,
    URF,
    RFU,
    FUR,
    DLF,
    LFD,
    FDL,
    DBL,
    BLD,
    LDB,
    DRB,
    RBD,
    BDR,
    DFR,
    FRD,
    RDF,
    numCorners
}

public enum CubeDirection
{
    clockwise,
    anticlockwise,
    doubleTurn
}

public struct RotatingPieces
{
    public CubeDirection direction;
    public CenterSticker[] centers;
    public EdgeSticker[] edges;
    public CornerSticker[] corners;
    public RotatingPieces(CubeDirection directionIn)
    {
        direction = directionIn;
        centers = new CenterSticker[0];
        edges = new EdgeSticker[0];
        corners = new CornerSticker[0];
    }
}

public class Cube
{
    public static CenterSticker[] allCenters = {
        CenterSticker.U,
        CenterSticker.D,
        CenterSticker.F,
        CenterSticker.B,
        CenterSticker.L,
        CenterSticker.R,
    };
    public static EdgeSticker[] allEdges = {
        EdgeSticker.UF,
        EdgeSticker.FU,
        EdgeSticker.UL,
        EdgeSticker.LU,
        EdgeSticker.UB,
        EdgeSticker.BU,
        EdgeSticker.UR,
        EdgeSticker.RU,
        EdgeSticker.DF,
        EdgeSticker.FD,
        EdgeSticker.DL,
        EdgeSticker.LD,
        EdgeSticker.DB,
        EdgeSticker.BD,
        EdgeSticker.DR,
        EdgeSticker.RD,
        EdgeSticker.FR,
        EdgeSticker.RF,
        EdgeSticker.FL,
        EdgeSticker.LF,
        EdgeSticker.BL,
        EdgeSticker.LB,
        EdgeSticker.BR,
        EdgeSticker.RB,
    };
    private CenterSticker[] centers;
    private EdgeSticker[] edges;
    private CornerSticker[] corners;

    public Cube()
    {
        centers = new CenterSticker[(int) CenterSticker.numCenters];
        edges = new EdgeSticker[(int) EdgeSticker.numEdges];
        corners = new CornerSticker[(int) CornerSticker.numCorners];
        for (int i = 0; i < (int) CenterSticker.numCenters; ++i)
        {
            centers[i] = (CenterSticker) i;
        }
        for (int i = 0; i < (int) EdgeSticker.numEdges; ++i)
        {
            edges[i] = (EdgeSticker) i;
        }
        for (int i = 0; i < (int) CornerSticker.numCorners; ++i)
        {
            corners[i] = (CornerSticker) i;
        }
    }

    public void ResetIndices()
    {
        for (int i = 0; i < (int)CenterSticker.numCenters; ++i)
        {
            centers[i] = (CenterSticker)i;
        }
        for (int i = 0; i < (int)EdgeSticker.numEdges; ++i)
        {
            edges[i] = (EdgeSticker)i;
        }
        for (int i = 0; i < (int)CornerSticker.numCorners; ++i)
        {
            corners[i] = (CornerSticker)i;
        }
    }

    // Getters
    public EdgeSticker getEdge(EdgeSticker index)
    {
        return edges[(int) index];
    }
    public CornerSticker getCorner(CornerSticker index)
    {
        return corners[(int) index];
    }
    public CenterSticker getCenter(CenterSticker index)
    {
        return centers[(int) index];
    }

    private List<EdgeSticker> stickersOnEdge(EdgeSticker edge)
    {
        int pieceIndex = (int) edge / 2;
        EdgeSticker piece1 = (EdgeSticker) (pieceIndex * 2);
        EdgeSticker piece2 = (EdgeSticker) (pieceIndex * 2 + 1);
        return new List<EdgeSticker> { piece1, piece2 };
    }

    private List<CornerSticker> stickersOnCorner(CornerSticker corner)
    {
        int pieceIndex = (int) corner / 3;
        CornerSticker piece1 = (CornerSticker) (pieceIndex * 3);
        CornerSticker piece2 = (CornerSticker) (pieceIndex * 3 + 1);
        CornerSticker piece3 = (CornerSticker) (pieceIndex * 3 + 2);
        return new List<CornerSticker> { piece1, piece2, piece3 };
    }

    private CornerSticker[] mergeCornersOnPieces(CornerSticker[] cornerStickers)
    {
        List<CornerSticker> resultList = new List<CornerSticker>();
        foreach (CornerSticker sticker in cornerStickers)
        {
            resultList.AddRange(stickersOnCorner(sticker));
        }
        return resultList.ToArray();
    }

    private EdgeSticker[] mergeEdgesOnPieces(EdgeSticker[] edgeStickers)
    {
        List<EdgeSticker> resultList = new List<EdgeSticker>();
        foreach (EdgeSticker sticker in edgeStickers)
        {
            resultList.AddRange(stickersOnEdge(sticker));
        }
        return resultList.ToArray();
    }

    /*
        The Rotating pieces functions are used to obtain the pieces that are going to be rotated. The result is used to animate the movement of the cube.
     */
    public RotatingPieces rotatingPiecesR(CubeDirection direction)
    {
        RotatingPieces result = new RotatingPieces(direction);
        result.centers = new CenterSticker[] { CenterSticker.R };
        result.edges = mergeEdgesOnPieces(new EdgeSticker[] { EdgeSticker.RB, EdgeSticker.RD, EdgeSticker.RU, EdgeSticker.RF });
        result.corners = mergeCornersOnPieces(new CornerSticker[] { CornerSticker.RUB, CornerSticker.RBD, CornerSticker.RDF, CornerSticker.RFU });
        return result;
    }

    public RotatingPieces rotatingPiecesL(CubeDirection direction)
    {
        RotatingPieces result = new RotatingPieces(direction);
        result.centers = new CenterSticker[] { CenterSticker.L };
        result.edges = mergeEdgesOnPieces(new EdgeSticker[] { EdgeSticker.LB, EdgeSticker.LD, EdgeSticker.LU, EdgeSticker.LF });
        result.corners = mergeCornersOnPieces(new CornerSticker[] { CornerSticker.LUF, CornerSticker.LDB, CornerSticker.LFD, CornerSticker.LBU });
        return result;
    }

    public RotatingPieces rotatingPiecesU(CubeDirection direction)
    {
        RotatingPieces result = new RotatingPieces(direction);
        result.centers = new CenterSticker[] { CenterSticker.U };
        result.edges = mergeEdgesOnPieces(new EdgeSticker[] { EdgeSticker.UR, EdgeSticker.UB, EdgeSticker.UL, EdgeSticker.UF });
        result.corners = mergeCornersOnPieces(new CornerSticker[] { CornerSticker.UBR, CornerSticker.URF, CornerSticker.UFL, CornerSticker.ULB });
        return result;
    }

    public RotatingPieces rotatingPiecesD(CubeDirection direction)
    {
        RotatingPieces result = new RotatingPieces(direction);
        result.centers = new CenterSticker[] { CenterSticker.D };
        result.edges = mergeEdgesOnPieces(new EdgeSticker[] { EdgeSticker.DR, EdgeSticker.DB, EdgeSticker.DL, EdgeSticker.DF });
        result.corners = mergeCornersOnPieces(new CornerSticker[] { CornerSticker.DRB, CornerSticker.DBL, CornerSticker.DLF, CornerSticker.DFR });
        return result;
    }

    public RotatingPieces rotatingPiecesF(CubeDirection direction)
    {
        RotatingPieces result = new RotatingPieces(direction);
        result.centers = new CenterSticker[] { CenterSticker.F };
        result.edges = mergeEdgesOnPieces(new EdgeSticker[] { EdgeSticker.FR, EdgeSticker.FD, EdgeSticker.FU, EdgeSticker.FL });
        result.corners = mergeCornersOnPieces(new CornerSticker[] { CornerSticker.FDL, CornerSticker.FLU, CornerSticker.FUR, CornerSticker.FRD });
        return result;
    }

    public RotatingPieces rotatingPiecesB(CubeDirection direction)
    {
        RotatingPieces result = new RotatingPieces(direction);
        result.centers = new CenterSticker[] { CenterSticker.B };
        result.edges = mergeEdgesOnPieces(new EdgeSticker[] { EdgeSticker.BR, EdgeSticker.BD, EdgeSticker.BU, EdgeSticker.BL });
        result.corners = mergeCornersOnPieces(new CornerSticker[] { CornerSticker.BDR, CornerSticker.BRU, CornerSticker.BUL, CornerSticker.BLD });
        return result;
    }

    public RotatingPieces rotatingPiecesE(CubeDirection direction)
    {
        RotatingPieces result = new RotatingPieces(direction);
        result.centers = new CenterSticker[] { CenterSticker.F, CenterSticker.R, CenterSticker.B, CenterSticker.L };
        result.edges = mergeEdgesOnPieces(new EdgeSticker[] { EdgeSticker.FR, EdgeSticker.FL, EdgeSticker.BR, EdgeSticker.BL });
        return result;
    }

    public RotatingPieces rotatingPiecesM(CubeDirection direction)
    {
        RotatingPieces result = new RotatingPieces(direction);
        result.centers = new CenterSticker[] { CenterSticker.F, CenterSticker.U, CenterSticker.B, CenterSticker.D };
        result.edges = mergeEdgesOnPieces(new EdgeSticker[] { EdgeSticker.UF, EdgeSticker.DF, EdgeSticker.UB, EdgeSticker.DB });
        return result;
    }

    public RotatingPieces rotatingPiecesS(CubeDirection direction)
    {
        RotatingPieces result = new RotatingPieces(direction);
        result.centers = new CenterSticker[] { CenterSticker.L, CenterSticker.U, CenterSticker.R, CenterSticker.D };
        result.edges = mergeEdgesOnPieces(new EdgeSticker[] { EdgeSticker.UR, EdgeSticker.DR, EdgeSticker.UL, EdgeSticker.DL });
        return result;
    }

    // rotate the indices in the array in this order:
    // Clockwise:  1->2->3->4->1
    // Anticlockwise:  4->3->2->1->4
    // DoubleTurn: 1<->3, 2<->4
    private void rotate<T, IntLike>(T[] arr, IntLike index1, IntLike index2, IntLike index3, IntLike index4, CubeDirection direction) where IntLike : IConvertible
    {
        switch (direction)
        {
            case CubeDirection.clockwise:
                T temp = arr[index4.ToInt32(null)];
                arr[index4.ToInt32(null)] = arr[index3.ToInt32(null)];
                arr[index3.ToInt32(null)] = arr[index2.ToInt32(null)];
                arr[index2.ToInt32(null)] = arr[index1.ToInt32(null)];
                arr[index1.ToInt32(null)] = temp;
                break;
            case CubeDirection.anticlockwise:
                temp = arr[index1.ToInt32(null)];
                arr[index1.ToInt32(null)] = arr[index2.ToInt32(null)];
                arr[index2.ToInt32(null)] = arr[index3.ToInt32(null)];
                arr[index3.ToInt32(null)] = arr[index4.ToInt32(null)];
                arr[index4.ToInt32(null)] = temp;
                break;
            case CubeDirection.doubleTurn:
                temp = arr[index1.ToInt32(null)];
                arr[index1.ToInt32(null)] = arr[index3.ToInt32(null)];
                arr[index3.ToInt32(null)] = temp;
                temp = arr[index2.ToInt32(null)];
                arr[index2.ToInt32(null)] = arr[index4.ToInt32(null)];
                arr[index4.ToInt32(null)] = temp;
                break;
        }
    }

    public void rotateR(CubeDirection direction)
    {
        rotate(edges, EdgeSticker.UR, EdgeSticker.BR, EdgeSticker.DR, EdgeSticker.FR, direction);
        rotate(edges, EdgeSticker.RU, EdgeSticker.RB, EdgeSticker.RD, EdgeSticker.RF, direction);
        rotate(corners, CornerSticker.URF, CornerSticker.BRU, CornerSticker.DRB, CornerSticker.FRD, direction);
        rotate(corners, CornerSticker.RFU, CornerSticker.RUB, CornerSticker.RBD, CornerSticker.RDF, direction);
        rotate(corners, CornerSticker.FUR, CornerSticker.UBR, CornerSticker.BDR, CornerSticker.DFR, direction);
    }

    public void rotateL(CubeDirection direction)
    {
        rotate(edges, EdgeSticker.LU, EdgeSticker.LF, EdgeSticker.LD, EdgeSticker.LB, direction);
        rotate(edges, EdgeSticker.UL, EdgeSticker.FL, EdgeSticker.DL, EdgeSticker.BL, direction);
        rotate(corners, CornerSticker.LUF, CornerSticker.LFD, CornerSticker.LDB, CornerSticker.LBU, direction);
        rotate(corners, CornerSticker.UFL, CornerSticker.FDL, CornerSticker.DBL, CornerSticker.BUL, direction);
        rotate(corners, CornerSticker.FLU, CornerSticker.DLF, CornerSticker.BLD, CornerSticker.ULB, direction);
    }

    public void rotateU(CubeDirection direction)
    {
        rotate(edges, EdgeSticker.UR, EdgeSticker.UF, EdgeSticker.UL, EdgeSticker.UB, direction);
        rotate(edges, EdgeSticker.RU, EdgeSticker.FU, EdgeSticker.LU, EdgeSticker.BU, direction);
        rotate(corners, CornerSticker.URF, CornerSticker.UFL, CornerSticker.ULB, CornerSticker.UBR, direction);
        rotate(corners, CornerSticker.RFU, CornerSticker.FLU, CornerSticker.LBU, CornerSticker.BRU, direction);
        rotate(corners, CornerSticker.FUR, CornerSticker.LUF, CornerSticker.BUL, CornerSticker.RUB, direction);
    }

    public void rotateD(CubeDirection direction)
    {
        rotate(edges, EdgeSticker.DF, EdgeSticker.DR, EdgeSticker.DB, EdgeSticker.DL, direction);
        rotate(edges, EdgeSticker.FD, EdgeSticker.RD, EdgeSticker.BD, EdgeSticker.LD, direction);
        rotate(corners, CornerSticker.DFR, CornerSticker.DRB, CornerSticker.DBL, CornerSticker.DLF, direction);
        rotate(corners, CornerSticker.FRD, CornerSticker.RBD, CornerSticker.BLD, CornerSticker.LFD, direction);
        rotate(corners, CornerSticker.RDF, CornerSticker.BDR, CornerSticker.LDB, CornerSticker.FDL, direction);
    }

    public void rotateF(CubeDirection direction)
    {
        rotate(edges, EdgeSticker.FU, EdgeSticker.FR, EdgeSticker.FD, EdgeSticker.FL, direction);
        rotate(edges, EdgeSticker.UF, EdgeSticker.RF, EdgeSticker.DF, EdgeSticker.LF, direction);
        rotate(corners, CornerSticker.FUR, CornerSticker.FRD, CornerSticker.FDL, CornerSticker.FLU, direction);
        rotate(corners, CornerSticker.URF, CornerSticker.RDF, CornerSticker.DLF, CornerSticker.LUF, direction);
        rotate(corners, CornerSticker.RFU, CornerSticker.DFR, CornerSticker.LFD, CornerSticker.UFL, direction);
    }

    public void rotateB(CubeDirection direction)
    {
        rotate(edges, EdgeSticker.BU, EdgeSticker.BL, EdgeSticker.BD, EdgeSticker.BR, direction);
        rotate(edges, EdgeSticker.UB, EdgeSticker.LB, EdgeSticker.DB, EdgeSticker.RB, direction);
        rotate(corners, CornerSticker.BRU, CornerSticker.BUL, CornerSticker.BLD, CornerSticker.BDR, direction);
        rotate(corners, CornerSticker.RUB, CornerSticker.ULB, CornerSticker.LDB, CornerSticker.DRB, direction);
        rotate(corners, CornerSticker.UBR, CornerSticker.LBU, CornerSticker.DBL, CornerSticker.RBD, direction);
    }

    public void rotateE(CubeDirection direction)
    {
        rotate(centers, CenterSticker.F, CenterSticker.R, CenterSticker.B, CenterSticker.L, direction);
        rotate(edges, EdgeSticker.FR, EdgeSticker.RB, EdgeSticker.BL, EdgeSticker.LF, direction);
        rotate(edges, EdgeSticker.RF, EdgeSticker.BR, EdgeSticker.LB, EdgeSticker.FL, direction);
    }

    public void rotateM(CubeDirection direction)
    {
        rotate(centers, CenterSticker.F, CenterSticker.D, CenterSticker.B, CenterSticker.U, direction);
        rotate(edges, EdgeSticker.UF, EdgeSticker.FD, EdgeSticker.DB, EdgeSticker.BU, direction);
        rotate(edges, EdgeSticker.FU, EdgeSticker.DF, EdgeSticker.BD, EdgeSticker.UB, direction);
    }

    public void rotateS(CubeDirection direction)
    {
        rotate(centers, CenterSticker.U, CenterSticker.R, CenterSticker.D, CenterSticker.L, direction);
        rotate(edges, EdgeSticker.UR, EdgeSticker.RD, EdgeSticker.DL, EdgeSticker.LU, direction);
        rotate(edges, EdgeSticker.RU, EdgeSticker.DR, EdgeSticker.LD, EdgeSticker.UL, direction);
    }
    private AdjacentSticker[] convertStringToSticker(string[] adjSticker)
    {
        AdjacentSticker[] adj_sticker_enum = new AdjacentSticker[4];
        for (int i = 0; i < 4; i++)
        {
            if (adjSticker[i].Length == 1)
            {
            if (adjSticker[i] == "U") adj_sticker_enum[i].center = CenterSticker.U;
            if (adjSticker[i] == "D") adj_sticker_enum[i].center = CenterSticker.D;
            if (adjSticker[i] == "L") adj_sticker_enum[i].center = CenterSticker.L;
            if (adjSticker[i] == "R") adj_sticker_enum[i].center = CenterSticker.R;
            if (adjSticker[i] == "F") adj_sticker_enum[i].center = CenterSticker.F;
            if (adjSticker[i] == "B") adj_sticker_enum[i].center = CenterSticker.B;
            }
            else if (adjSticker[i].Length == 2)
            {
                if (adjSticker[i] == "UF") adj_sticker_enum[i].edge = EdgeSticker.UL;
                if (adjSticker[i] == "UR") adj_sticker_enum[i].edge = EdgeSticker.UR;
                if (adjSticker[i] == "UF") adj_sticker_enum[i].edge = EdgeSticker.UF;
                if (adjSticker[i] == "UB") adj_sticker_enum[i].edge = EdgeSticker.UB;
                if (adjSticker[i] == "DL") adj_sticker_enum[i].edge = EdgeSticker.DL;
                if (adjSticker[i] == "DR") adj_sticker_enum[i].edge = EdgeSticker.DR;
                if (adjSticker[i] == "DF") adj_sticker_enum[i].edge = EdgeSticker.DF;
                if (adjSticker[i] == "DB") adj_sticker_enum[i].edge = EdgeSticker.DB;
                if (adjSticker[i] == "LU") adj_sticker_enum[i].edge = EdgeSticker.LU;
                if (adjSticker[i] == "LD") adj_sticker_enum[i].edge = EdgeSticker.LD;
                if (adjSticker[i] == "LF") adj_sticker_enum[i].edge = EdgeSticker.LF;
                if (adjSticker[i] == "LB") adj_sticker_enum[i].edge = EdgeSticker.LB;
                if (adjSticker[i] == "RU") adj_sticker_enum[i].edge = EdgeSticker.RU;
                if (adjSticker[i] == "RD") adj_sticker_enum[i].edge = EdgeSticker.RD;
                if (adjSticker[i] == "RF") adj_sticker_enum[i].edge = EdgeSticker.RF;
                if (adjSticker[i] == "RB") adj_sticker_enum[i].edge = EdgeSticker.RB;
                if (adjSticker[i] == "FU") adj_sticker_enum[i].edge = EdgeSticker.FU;
                if (adjSticker[i] == "FD") adj_sticker_enum[i].edge = EdgeSticker.FD;
                if (adjSticker[i] == "FL") adj_sticker_enum[i].edge = EdgeSticker.FL;
                if (adjSticker[i] == "FR") adj_sticker_enum[i].edge = EdgeSticker.FR;
                if (adjSticker[i] == "BU") adj_sticker_enum[i].edge = EdgeSticker.BU;
                if (adjSticker[i] == "BD") adj_sticker_enum[i].edge = EdgeSticker.BD;
                if (adjSticker[i] == "BL") adj_sticker_enum[i].edge = EdgeSticker.BL;
                if (adjSticker[i] == "BR") adj_sticker_enum[i].edge = EdgeSticker.BR;
            }
            else
            {
                if (adjSticker[i] == "ULB") adj_sticker_enum[i].corner = CornerSticker.ULB;
                if (adjSticker[i] == "UBR") adj_sticker_enum[i].corner = CornerSticker.UBR;
                if (adjSticker[i] == "UFL") adj_sticker_enum[i].corner = CornerSticker.UFL;
                if (adjSticker[i] == "URF") adj_sticker_enum[i].corner = CornerSticker.URF;
                if (adjSticker[i] == "DBL") adj_sticker_enum[i].corner = CornerSticker.DBL;
                if (adjSticker[i] == "DFR") adj_sticker_enum[i].corner = CornerSticker.DFR;
                if (adjSticker[i] == "DLF") adj_sticker_enum[i].corner = CornerSticker.DLF;
                if (adjSticker[i] == "DRB") adj_sticker_enum[i].corner = CornerSticker.DRB;
                if (adjSticker[i] == "LBU") adj_sticker_enum[i].corner = CornerSticker.LBU;
                if (adjSticker[i] == "LDB") adj_sticker_enum[i].corner = CornerSticker.LDB;
                if (adjSticker[i] == "LFD") adj_sticker_enum[i].corner = CornerSticker.LFD;
                if (adjSticker[i] == "LUF") adj_sticker_enum[i].corner = CornerSticker.LUF;
                if (adjSticker[i] == "RBD") adj_sticker_enum[i].corner = CornerSticker.RBD;
                if (adjSticker[i] == "RDF") adj_sticker_enum[i].corner = CornerSticker.RDF;
                if (adjSticker[i] == "RFU") adj_sticker_enum[i].corner = CornerSticker.RFU;
                if (adjSticker[i] == "RUB") adj_sticker_enum[i].corner = CornerSticker.RUB;
                if (adjSticker[i] == "FDL") adj_sticker_enum[i].corner = CornerSticker.FDL;
                if (adjSticker[i] == "FLU") adj_sticker_enum[i].corner = CornerSticker.FLU;
                if (adjSticker[i] == "FRD") adj_sticker_enum[i].corner = CornerSticker.FRD;
                if (adjSticker[i] == "FUR") adj_sticker_enum[i].corner = CornerSticker.FUR;
                if (adjSticker[i] == "BDR") adj_sticker_enum[i].corner = CornerSticker.BDR;
                if (adjSticker[i] == "BLD") adj_sticker_enum[i].corner = CornerSticker.BLD;
                if (adjSticker[i] == "BRU") adj_sticker_enum[i].corner = CornerSticker.BRU;
                if (adjSticker[i] == "BUL") adj_sticker_enum[i].corner = CornerSticker.BUL;
            }
        }
        return adj_sticker_enum;
    }
    public AdjacentSticker[] adjacentStickers(string sticker)
    {

        if (sticker.Length == 1)
        {
            if (sticker == "U") return convertStringToSticker(new string[] { "UL", "UR", "UB", "UF" });
            else if (sticker == "D") return convertStringToSticker(new string[] { "DL", "DR", "DF", "DB" });
            else if (sticker == "L") return convertStringToSticker(new string[] { "LU", "LD", "LF", "LB" });
            else if (sticker == "R") return convertStringToSticker(new string[] { "RU", "RD", "RF", "RB" });
            else if (sticker == "F") return convertStringToSticker(new string[] { "FU", "FD", "FL", "FR" });
            else return convertStringToSticker(new string[] { "BU", "BD", "BL", "BR" });
        }
        else if (sticker.Length == 2)
        {
            string[] adjacent_Stickers = new string[4];
            string center = sticker[0].ToString();
            string adj_center = sticker[1].ToString();
            adjacent_Stickers[0] = center;
            adjacent_Stickers[1] = adj_center + center;
            if (center == "U" || center == "D")
            {
                if (adj_center == "L" || adj_center == "R")
                {
                    adjacent_Stickers[2] = center + "F" + adj_center;
                    adjacent_Stickers[3] = center + "B" + adj_center;
                }
                else
                {
                    adjacent_Stickers[2] = center + "L" + adj_center;
                    adjacent_Stickers[3] = center + "R" + adj_center;
                }
            }
            else if (center == "L" || center == "R")
            {
                if (adj_center == "U" || adj_center == "D")
                {
                    adjacent_Stickers[2] = center + "F" + adj_center;
                    adjacent_Stickers[3] = center + "B" + adj_center;
                }
                else
                {
                    adjacent_Stickers[2] = center + "U" + adj_center;
                    adjacent_Stickers[3] = center + "D" + adj_center;
                }
            }
            else
            {
                if (adj_center == "U" || adj_center == "D")
                {
                    adjacent_Stickers[2] = center + "L" + adj_center;
                    adjacent_Stickers[3] = center + "R" + adj_center;
                }
                else
                {
                    adjacent_Stickers[2] = center + "U" + adj_center;
                    adjacent_Stickers[3] = center + "D" + adj_center;
                }
            }
            return convertStringToSticker(adjacent_Stickers);
        }
        else
        {
            string[] adjacent_Stickers = new string[4];
            string center = sticker[0].ToString();
            string adj_center_1 = sticker[1].ToString();
            string adj_center_2 = sticker[2].ToString();
            adjacent_Stickers[0] = center + adj_center_1;
            adjacent_Stickers[1] = center + adj_center_2;
            adjacent_Stickers[2] = adj_center_2 + center + adj_center_1;
            adjacent_Stickers[3] = adj_center_1 + adj_center_2 + center;
            return convertStringToSticker(adjacent_Stickers);
        }

    }
};