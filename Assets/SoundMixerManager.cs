using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    public void SetMasterVolume(float level)
    {
       audioMixer.SetFloat("MasterVolume", Mathf.Log10(level) * 20f);
    }
    public void SetMusicVolume(float level)
    
    {
      audioMixer.SetFloat("MusicVolume", Mathf.Log10(level) * 20f);
    }
    public void SetSoundFXVolume(float level)
    {
      audioMixer.SetFloat("SoundFxVolume", Mathf.Log10(level) * 20f);
    }
}