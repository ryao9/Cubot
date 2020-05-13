using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip cube_rotate;
    public AudioClip battery_pickup;
    public AudioClip teleport;
    public AudioClip robot;
    public AudioClip boot;
    public AudioClip unlock;
    public AudioClip walking;

    void Awake()
    {
        // Typical singleton initialization code.
        if (instance != null && instance != this)
        {
            // If there already exists a AudioManager, we need to go away.
            Destroy(gameObject);
            return;
        }
        else
        {
            // If we are the first AudioManager, we claim the "instance" variable so others go away.
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void PlayClip(AudioClip clip, Vector3 position, float volume = 1f)
    {
        Debug.Log("playing clip");
        AudioSource.PlayClipAtPoint(clip, position, volume);
    }
}
