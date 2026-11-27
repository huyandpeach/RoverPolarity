using UnityEngine;

// Plays sound effects and ambient clips through their assigned audio sources.
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource ambientAudioSource;
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayAmbientSound(AudioClip clip)
    {
        ambientAudioSource.PlayOneShot(clip);
    }
}
