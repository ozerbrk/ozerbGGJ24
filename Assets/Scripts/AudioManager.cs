using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource narratorAudioSource;  // Reference to the AudioSource component
    public AudioClip[] narrationClips;
    // Add methods for playing, stopping, adjusting volume, etc.
    public void PlayNarration(AudioClip clip)
    {
        narratorAudioSource.clip = clip;
        narratorAudioSource.Play();
    }

    // Add more methods as needed
}
