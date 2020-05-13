using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public int checkpoint_num;
    public LevelManager lm;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lm.reset_position = transform.position;
            transform.Find("checkpoint").GetComponent<Animator>().SetTrigger("reached");
            lm.checkpoint = checkpoint_num;
            lm.battery_count = GameObject.Find("InventoryManager").GetComponent<inventoryManager>().battery_count;
        }
    }
}
