using UnityEngine;

// Normal tile. Exactly what you would expect.
public class NormalTile : Tile
{
    public override bool canWalkOnTile()
    {
        return true;
    }
}