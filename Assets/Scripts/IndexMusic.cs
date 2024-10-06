using System;
using UnityEngine;
public class IndexMusic : MonoBehaviour
{
    [SerializeField] private Music music;
    static public event Action<AudioClip> eventMusic;
    static public event Action eventFade;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActiveEventMusic();
            ActiveEventFace();
        }
    }
    private void ActiveEventMusic()
    {
        eventMusic?.Invoke(music.musicClip);
    }
    private void ActiveEventFace()
    {
        eventFade?.Invoke();
    }  
}
