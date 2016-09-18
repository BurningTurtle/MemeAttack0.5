using UnityEngine;
using System.Collections;

public class OnClick : MonoBehaviour {

    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }

    public void ChangeMusic(AudioClip music)
    {
        source.clip = music;
        source.Play();
    }
}
