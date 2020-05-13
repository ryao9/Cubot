using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logOpening : MonoBehaviour
{
    public Image center_dot;
    public GameObject left_dot1;
    public GameObject left_dot2;
    public GameObject right_dot1;
    public GameObject right_dot2;
    public GameObject titleText;
    public GameObject start;
    public GameObject square;
    public GameObject circle;
    public GameObject logo;

    // Start is called before the first frame update
    void Start()
    { 
        center_dot.GetComponent<Animator>().SetBool("blink", true);
        left_dot1.SetActive(false);
        left_dot2.SetActive(false);
        right_dot1.SetActive(false);
        right_dot2.SetActive(false);
        titleText.SetActive(false);
        square.SetActive(false);
        logo.SetActive(false);
        StartCoroutine(OpeningRoutine());
    }

    IEnumerator OpeningRoutine()
    {
        yield return new WaitForSeconds(1.0f);
        circle.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        circle.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        circle.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        circle.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Destroy(center_dot);
        Destroy(circle);
        left_dot1.SetActive(true);
        left_dot2.SetActive(true);
        right_dot1.SetActive(true);
        right_dot2.SetActive(true);
        left_dot1.GetComponent<Animator>().SetTrigger("rightUp");
        left_dot2.GetComponent<Animator>().SetBool("leftDown", true);
        right_dot1.GetComponent<Animator>().SetTrigger("leftUp");
        right_dot2.GetComponent<Animator>().SetBool("rightDown", true);
        yield return new WaitForSeconds(0.7f);
        titleText.SetActive(true);
        square.SetActive(true);
        logo.SetActive(true);
        start.SetActive(true);
        yield return null;
        yield return null;
        titleText.SetActive(false);
        square.SetActive(false);
        logo.SetActive(false);
        start.SetActive(false);
        yield return null;
        yield return null;
        titleText.SetActive(true);
        square.SetActive(true);
        logo.SetActive(true);
        start.SetActive(true);
        yield return null;
        yield return null;
        titleText.SetActive(false);
        square.SetActive(false);
        logo.SetActive(false);
        start.SetActive(false);
        yield return null;
        yield return null;
        titleText.SetActive(true);
        square.SetActive(true);
        logo.SetActive(true);
        start.SetActive(true);
    }
}
