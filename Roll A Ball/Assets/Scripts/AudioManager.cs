using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip pickupSound1;
    public AudioClip pickupSound2;
    public AudioClip pickupSound3;
    public AudioClip winSound;

    private void Start()
    {
        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    private void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayRandomPickupSound()
    {
        AudioClip[] pickupSounds = { pickupSound1, pickupSound2, pickupSound3 };
        int idx = Random.Range(0, pickupSounds.Length);
        PlaySFX(pickupSounds[idx]);
    }

    public void PlayWinSound()
    {
        PlaySFX(winSound);
    }
}
