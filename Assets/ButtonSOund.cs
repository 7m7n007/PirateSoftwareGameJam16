using UnityEngine;

public class ButtonSOund : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AudioClip ClickButtonSound;

    public void PlayButtonSound()
    {
        SoundFxManager.Instance.AudioManager(ClickButtonSound, transform, 1f);
    }
}
