using System.Collections;
using UnityEngine;

class FakeTeleportingTile : TeleportingTile
{

    private void Start()
    {
        loadMaterial();
        findCamera();
        tileColor = Color.red;
        // setColor();
    }

    public override void onPlayerEnter(GameObject player)
    {
        if (Input.GetKeyDown(InputManager.instance.action))
        {
            setColor();
        }
    }
}