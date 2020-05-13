using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstract tile base class.
public abstract class Tile : MonoBehaviour
{
    public enum Direction
    {
        left,
        right,
        up,
        down
    }

    public Color tileColor;
    public virtual bool canWalkOnTile()
    {
        return false;
    }

    protected bool colorIsSet()
    {
        bool rEqual = tileColor.r == 0;
        bool gEqual = tileColor.g == 0;
        bool bEqual = tileColor.b == 0;
        return !(rEqual && gEqual && bEqual);
    }

    private static bool cheat = false;

    public static void setCheat(bool cheatIn)
    {
        cheat = cheatIn;
    }

    public static bool getCheat()
    {
        return cheat;
    }

    // public abstract bool canLeaveWithDirection(Direction direction);
    public virtual void onPlayerEnter(GameObject player)
    {
        return;
    }
    public static Tile fromObject(GameObject obj)
    {
        if (cheat || obj.tag != "Tile")
        {
            return null;
        }
        Component tile = obj.GetComponentInChildren(typeof(Tile));
        return (Tile) tile;
    }
}