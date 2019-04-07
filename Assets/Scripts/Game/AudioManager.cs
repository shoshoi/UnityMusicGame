using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    AudioSource myAudioSource;

    void Start () 
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    public void SetClip(AudioClip clip)
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.clip = clip;
    }
    public float GetTime()
    {
        return myAudioSource.time;
    }
    public void Play()
    {
        myAudioSource.Play();
    }
    public void Stop()
    {
        myAudioSource.Stop();
    }
}
