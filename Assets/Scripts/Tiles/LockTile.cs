using UnityEngine;

class LockTile : Tile
{
    private Renderer meshRenderer;
    bool isUnlocked = false;
    public void unlock()
    {
        if (!isUnlocked)
        {
            AudioManager.PlayClip(AudioManager.instance.unlock, Camera.main.transform.position);
        }
        isUnlocked = true;
        Material unlockedMat = Resources.Load("unlocked_tile") as Material;
        meshRenderer.material = unlockedMat;
    }

    private void Start()
    {
        meshRenderer = GetComponentInParent<MeshRenderer>();
        Material lockedMat = Resources.Load("locked_tile") as Material;
        meshRenderer.material = lockedMat;
    }

    public override bool canWalkOnTile()
    {
        return isUnlocked;
    }
}