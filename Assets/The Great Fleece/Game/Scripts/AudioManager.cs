using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance 
    {
        get 
        {
            if (_instance == null) 
            {
                Debug.LogError("Audio Manager is null");
            }
            return _instance;
        }
    }

    [SerializeField]
    private AudioSource _voiceOver;

    void Awake() 
    {
        if (_instance == null) 
        {
            _instance = this;
        }
    }

    public void PlayVoiceOver(AudioClip clipToPlay) 
    {
        _voiceOver.clip = clipToPlay;
        _voiceOver.Play();
    }

    public void StopAudio() 
    {
        AudioSource[] audioSources = GameObject.FindObjectsOfType<AudioSource>();

        foreach (AudioSource audioSource in audioSources) 
        {
            audioSource.Stop();
        }
    }
}
