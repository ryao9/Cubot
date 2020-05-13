using UnityEngine;

public class ObstacleTile : Tile
{
    public bool doNotApplyMaterial = false;
    private void Start()
    {
        if (doNotApplyMaterial) return;

        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        // Had to put obstacle_tile_material into the Resources folder to load.
        // TODO: reorganize folders or remove this material after we change obstacle's look.
        int random_int = Random.Range(0, 6);
        Material obstacleMaterial;
        if (random_int == 0) obstacleMaterial = Resources.Load("obstacle_tile_material_0") as Material;
        else if(random_int == 1) obstacleMaterial = Resources.Load("obstacle_tile_material_1") as Material;
        else if(random_int == 2) obstacleMaterial = Resources.Load("obstacle_tile_material_2") as Material;
        else if(random_int == 3) obstacleMaterial = Resources.Load("obstacle_tile_material_3") as Material;
        else if(random_int == 4) obstacleMaterial = Resources.Load("obstacle_tile_material_4") as Material;
        else obstacleMaterial = Resources.Load("obstacle_tile_material_5") as Material;
        meshRenderer.material = obstacleMaterial;
    }
}