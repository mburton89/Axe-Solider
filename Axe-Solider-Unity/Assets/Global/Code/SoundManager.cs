using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource coinAudio;
    public AudioSource failAudio;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayCoinSound()
    {
        coinAudio.Play();
    }

    public void PlayFailSound()
    {
        failAudio.Play();
    }
}
