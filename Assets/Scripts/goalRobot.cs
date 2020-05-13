using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalRobot : MonoBehaviour
{
    public GameObject batteryView;
    public BackgroundMusicController bgm;
    bool picked = false;
    public bool visionActivated = false;
    public bool goalReached = false;
    // Start is called before the first frame update

    private void Start()
    {
        transform.Find("goalRobotPosition").localPosition = new Vector3(0f, 0.5f, 0f);    
    }

    public void goalAnimation()
    {
        if (!picked)
        {
            goalReached = true;
            GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().enabled = false;
            transform.Find("goalRobotPosition").Find("GoalRobot").GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<ParticleSystem>().enableEmission = false;
            Camera.main.GetComponent<CameraController>().RotateCameraTwice();
            StartCoroutine(PickUpAni());
            picked = true;
        }
    }

    IEnumerator PickUpAni()
    {
        yield return null;
        if (batteryView != null) batteryView.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        if (batteryView != null) batteryView.SetActive(false);
        //yield return new WaitForSeconds(0.5f);
        transform.Find("goalRobotPosition").localPosition = new Vector3(-8f, 0f, -18f);
        transform.Find("goalRobotPosition").Find("GoalRobot").GetComponent<Animator>().SetTrigger("pickup");
        Camera.main.GetComponent<CameraController>().enabled = false;

        Vector3 targetPos = Camera.main.transform.position + new Vector3(0.0f, -2.5f, -0.5f);
        float elapsedTime = 0;
        float waitTime = 2.0f;
        Vector3 currentPos = Camera.main.transform.position;

        while (elapsedTime < waitTime)
        {
            GameObject.Find("PlayerMovement").GetComponent<PlayerMovement>().enabled = false;
            Camera.main.transform.position = Vector3.Slerp(currentPos, targetPos, (elapsedTime / waitTime));
            Camera.main.transform.LookAt(GameObject.Find("PlayerMovement").transform.position);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(3.0f);
        string ending = GameManager.instance.num_logs >= 7 ? "endingLevel 1" : "endingLevel 2";
        ending = visionActivated ? ending : "endingLevel 2";
        SceneManager.LoadScene(ending);
    }
}
