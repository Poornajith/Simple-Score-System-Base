using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    
    public static AudioManager instance;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip powerUpSound;
    [SerializeField] private AudioClip buttonClickSound;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayShootSound()
    {
        audioSource.PlayOneShot(shootSound);
    }

    public void PlayExplosionSound()
    {
        audioSource.PlayOneShot(explosionSound);
    }

    public void PlayHitSound()
    {
        audioSource.PlayOneShot(hitSound);
    }

    public void PlayPowerUpSound()
    {
        audioSource.PlayOneShot(powerUpSound);
    }

    public void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }    
}
