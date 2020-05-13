using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class textAppearing : MonoBehaviour
{
    // Start is called before the first frame update

    public string text;
    public bool done = false;
    string st = "!@#$%^&*()abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ12345678";
    bool blink = false;

    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = "";
    }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name == "logBackground")
        {
            if (InputManager.instance.controller_mode == false)
            {
                text = "Press Any Key to Start";
            }
            else
            {
                text = "Press Any Button to Start";
            }
        }
        StartCoroutine(OpeningRoutine());
    }

    IEnumerator OpeningRoutine()
    {
        string currentText = "> ";
        string underscore = "_";
        GetComponent<UnityEngine.UI.Text>().text = currentText + underscore;
        yield return new WaitForSeconds(0.3f);
        GetComponent<UnityEngine.UI.Text>().text = "";
        yield return null;
        GetComponent<UnityEngine.UI.Text>().text = currentText + underscore;
        AudioManager.PlayClip(AudioManager.instance.robot, Camera.main.transform.position);

        for (int i = 0; i < text.Length; ++i)
        {
            //GetComponent<UnityEngine.UI.Text>().text = currentText + underscore;
            //yield return null;
            GetComponent<UnityEngine.UI.Text>().text = currentText + st[Random.Range(0, st.Length)] + underscore;
            yield return null;
            GetComponent<UnityEngine.UI.Text>().text = currentText + st[Random.Range(0, st.Length)] + underscore;
            yield return null;
            GetComponent<UnityEngine.UI.Text>().text = currentText + text[i] + underscore;
            yield return null;
            //yield return null;
            currentText += text[i];
        }

        GetComponent<UnityEngine.UI.Text>().text = currentText;
        blink = true;
        done = true;
    }
}
