using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioMixerControler : MonoBehaviour
{
    static public AudioMixerControler instance;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField]private string master;
    [SerializeField] private string music ;
    [SerializeField] private string sfx;
    private void Awake()
    {
        masterSlider.value = PlayerPrefs.GetFloat(master);
        musicSlider.value = PlayerPrefs.GetFloat(music);
        sfxSlider.value = PlayerPrefs.GetFloat(sfx);

        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetSFXVolume(sfxSlider.value);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat(master, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(master, volume);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(music, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(music, volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat(sfx, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(sfx, volume);
    }
}
