using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabOnTile : MonoBehaviour
{   
    public GameObject prefab;

    void Start()
    {
        // tree obstacle
        if (prefab.name == "tree")
        {
            instantiateTree();
        }
        else if (prefab.name == "mushroom_brown"
                || prefab.name == "mushroom_red")
        {
            instantiateMushroom();
        }
        else if (prefab.name == "flowerBush")
        {
            instantiateFlowerBush();
        }
        else {
            if (prefab.name == "rock"
                || prefab.name == "buriedRock")
            {
                instantiateRock(new Vector3(1f, 10f, 1f));
            }
            else if (prefab.name == "treetrunk")
            {
                instantiateRock(new Vector3(0.7f, 7f, 0.7f));
            }
        }
    }

    void instantiateTree()
    {
        if (transform.name[0] == 'L')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0f, 0f, -0.3f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
        }
        else if (transform.name[0] == 'R')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0f, 0f, 0.3f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        }
        else if (transform.name[0] == 'U')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0f, 0.3f, 0f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
        }
        else if (transform.name[0] == 'F')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0.3f, 0f, 0f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
        }
        else if (transform.name[0] == 'B')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(-0.3f, 0f, 0f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
        }
        else if (transform.name[0] == 'D')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0f, -0.3f, 0f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(180f, 0f, 0f));
        }
    }

    void instantiateRock(Vector3 scale)
    {
        GameObject childObject = Instantiate(prefab, transform.position, Quaternion.identity);
        childObject.transform.parent = gameObject.transform;
        childObject.transform.localScale = scale;
        if (transform.name[0] == 'L')
        {
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
        }
        else if (transform.name[0] == 'R')
        {
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        }
        else if (transform.name[0] == 'U')
        {
        }
        else if (transform.name[0] == 'F')
        {
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
        }
        else if (transform.name[0] == 'B')
        {
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
        }
        else if (transform.name[0] == 'D')
        {
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(180f, 0f, 0f));
        }
    }

    void instantiateMushroom()
    {
        if (transform.name[0] == 'L')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0f, 0f, 0.05f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
        }
        else if (transform.name[0] == 'R')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0f, 0f, -0.05f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        }
        else if (transform.name[0] == 'U')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0f, -0.05f, 0f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
        }
        else if (transform.name[0] == 'F')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(-0.05f, 0f, 0f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
        }
        else if (transform.name[0] == 'B')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0.05f, 0f, 0f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
        }
        else if (transform.name[0] == 'D')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0f, 0.05f, 0f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(180f, 0f, 0f));
        }
    }

    void instantiateFlowerBush()
    {
        if (transform.name[0] == 'L')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0f, 0f, 0.3f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(-90f, 0f, 0f));
        }
        else if (transform.name[0] == 'R')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0f, 0f, -0.3f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));
        }
        else if (transform.name[0] == 'U')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0f, -0.3f, 0f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
        }
        else if (transform.name[0] == 'F')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(-0.3f, 0f, 0f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -90f));
        }
        else if (transform.name[0] == 'B')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0.3f, 0f, 0f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 90f));
        }
        else if (transform.name[0] == 'D')
        {
            GameObject childObject = Instantiate(prefab, transform.position + new Vector3(0f, 0.3f, 0f), Quaternion.identity);
            childObject.transform.parent = gameObject.transform;
            childObject.transform.localScale = new Vector3(0.7f, 7f, 0.7f);
            childObject.transform.localRotation = Quaternion.Euler(new Vector3(180f, 0f, 0f));
        }
    }

}
