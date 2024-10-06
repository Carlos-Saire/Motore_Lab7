using UnityEngine;
public class MusicControl : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake()
    { 
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        IndexMusic.eventMusic += NewIndex;
    }
    private void OnDisable()
    {
        IndexMusic.eventMusic -= NewIndex;
    }
    private void NewIndex(AudioClip audioClip)
    {
        if (audioSource.clip != audioClip)
        {
            audioSource.clip = audioClip;
            audioSource.time = 0f;
            audioSource.Play();
        }
    }
}
