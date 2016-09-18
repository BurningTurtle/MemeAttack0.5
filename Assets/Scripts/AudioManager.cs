using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void ChangeMusic(AudioClip music)
    {
        source.clip = music;
        source.Play();
    }
}
