using System.Collections;
using UnityEngine;

class LateColorTeleportingTile : TeleportingTile
{
    public bool pointToPuzzle;

    private void Start()
    {
        loadMaterial();
        findCamera();
        if (pointToPuzzle)
        {
            tileColor = Color.green;
        }
        else
        {
            tileColor = Color.yellow;
        }
        // setColor();
    }

    public override void onPlayerEnter(GameObject player)
    {
        base.onPlayerEnter(player);
        if (teleportAttempted())
        {
            setColor();
        }
    }
}