    using System.Collections.Generic;
    using System.Collections;
    using UnityEngine;

    public class pickUp : MonoBehaviour
    {
        public GameObject batteryView;
        public float playerYLevel = 0f;
        private GameObject playerMovement;
        public int amount;

        bool picked = false;
        // Start is called before the first frame update
        void Start()
        {
            playerMovement = GameObject.Find("PlayerMovement");

            if (amount == 0 && GameManager.instance.diff == inventoryManager.Difficulty.extreme 
            && gameObject.name != "Normal" && gameObject.name != "Hard" && gameObject.name != "Extreme")
            {
                transform.parent.gameObject.SetActive(false);
            }
        }

    void OnTriggerEnter(Collider other)
        {
            if (other.transform.tag == "Player")
            {
                GameObject inventoryManagerObject = GameObject.Find("InventoryManager");
                if (inventoryManagerObject != null)
                {
                    inventoryManager manager = GameObject.Find("InventoryManager").GetComponent<inventoryManager>();
                    if (gameObject.name == "Normal")
                    {
                        manager.difficulty = global::inventoryManager.Difficulty.normal;
                        //GameObject.Find("Difficulty Selection").SetActive(false);
                    }
                    if (gameObject.name == "Hard")
                    {
                        manager.difficulty = global::inventoryManager.Difficulty.hard;
                        //GameObject.Find("Difficulty Selection").SetActive(false);
                    }
                    if (gameObject.name == "Extreme")
                    {
                        manager.difficulty = global::inventoryManager.Difficulty.extreme;
                        //GameObject.Find("Difficulty Selection").SetActive(false);
                    }

                }
                if (!picked)
                {
                    if (GameObject.Find("InventoryManager") != null)
                    {
                        GameObject.Find("InventoryManager").GetComponent<inventoryManager>().batteryPicked(amount);
                    }

                    transform.parent.Find("batttery").gameObject.SetActive(false);
                    StartCoroutine(PickUpAni());
                    picked = true;
                }
            }
        }

        IEnumerator PickUpAni()
        {
            if (batteryView != null) batteryView.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            if (batteryView != null) batteryView.SetActive(false);
            gameObject.SetActive(false);
            if (GameObject.Find("Difficulty Selection") != null) GameObject.Find("Difficulty Selection").SetActive(false);
        }
        
        void OnEnable()
        {
            picked = false;
        }
    }