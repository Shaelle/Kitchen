using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public static MusicManager Instance { get; private set; }

    const string musicString = "MusicVolume";

    AudioSource audioSource;

    float volume = 0.3f;


    private void Awake()
    {

        Instance = this;

        audioSource = GetComponent<AudioSource>();

        volume = PlayerPrefs.GetFloat(musicString, 0.3f);
        audioSource.volume = volume;
    }

    public void ChangeVolume()
    {
        volume += 0.1f;

        if (volume > 1) volume = 0;

        audioSource.volume = volume;

        PlayerPrefs.SetFloat(musicString, volume);
        PlayerPrefs.Save();
    }


    public float GetVolume()
    {
        return volume;
    }

}
