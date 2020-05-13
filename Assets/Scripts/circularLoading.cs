using UnityEngine;
using UnityEngine.UI;
 
public class circularLoading : MonoBehaviour
{
    float currentValue;
    public float speed;
    public Image center_dot;

    bool clip_played = false;
    int play_delay = 0;

    // Update is called once per frame
    void Update()
    {
        if (!clip_played && play_delay > 30)
        {
            AudioManager.PlayClip(AudioManager.instance.boot, Camera.main.transform.position);
            clip_played = true;
        }

        if (currentValue < 100)
        {
            currentValue += speed * Time.deltaTime;
        }

        GetComponent<UnityEngine.UI.Image>().fillAmount = currentValue / 100;
        center_dot.fillAmount = currentValue / 100;

        ++play_delay;
    }
}