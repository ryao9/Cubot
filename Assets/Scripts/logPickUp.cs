using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class logPickUp : MonoBehaviour
{
    public string logScene;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && logScene != "")
        {
            AudioManager.PlayClip(AudioManager.instance.battery_pickup, Camera.main.transform.position);
            GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = false;
            GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().enabled = false;
            GameObject.Find("LogManager").GetComponent<logSceneManager>().ActivatePlayer();
            SceneManager.LoadScene(logScene, LoadSceneMode.Additive);
            Destroy(gameObject);
            GameManager.instance.num_logs++;
        }
    }
}
