using UnityEngine;

public class SoundFxManager : MonoBehaviour
{
    [SerializeField] private AudioSource SoundFXSource;
    public static SoundFxManager Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }
    public void AudioManager(AudioClip audioClip , Transform spawnTransform , float volume)
    {
       AudioSource audioSource = Instantiate(SoundFXSource, spawnTransform.position, Quaternion.identity);
        
       audioSource.clip = audioClip;
       audioSource.volume = volume;
       audioSource.Play();

       float audioLength = audioSource.clip.length;
       Destroy(audioSource.gameObject, audioLength);


    }

    public void RandomAudioManager(AudioClip[] audioClip , Transform spawnTransform , float volume)
    {
        int rand = Random.Range(0, audioClip.Length);
       AudioSource audioSource = Instantiate(SoundFXSource, spawnTransform.position, Quaternion.identity);

       audioSource.clip = audioClip[rand];
       audioSource.volume = volume;
       audioSource.Play();

       float audioLength = audioSource.clip.length;
       Destroy(audioSource.gameObject, audioLength);


    }
    public void StopMusicFx(){
        SoundFXSource.Stop();
    }
}

