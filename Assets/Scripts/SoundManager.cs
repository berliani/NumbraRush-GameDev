using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip correctSound;
    public AudioClip wrongSound;
    public AudioClip clickSound;
    public AudioClip failedSound;
    public AudioClip finishSound;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayCorrectSound()
    {
        audioSource.PlayOneShot(correctSound);
    }

    public void PlayWrongSound()
    {
        audioSource.PlayOneShot(wrongSound);
    }

    public void PlayClick()
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void PlayFailedSound()
    {
        audioSource.PlayOneShot(failedSound);
    }

    public void PlayFinishSound()
    {
        audioSource.PlayOneShot(finishSound);
    }
}
