
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioClip jump;
    [SerializeField] private AudioClip changeGravity;
    [SerializeField] private AudioClip enemyShoot;
    [SerializeField] private AudioClip die;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
        else
            Destroy(gameObject);
    }

    public void PlayJumpAudio()
    {
            audioSource.clip = jump;
            audioSource.volume = 0.3f;
            audioSource.Play();
    }
    public void PlayChangeGravityAudio()
    {
            audioSource.clip = changeGravity;
            audioSource.volume = 0.05f;
            audioSource.Play();
    }
    public void PlayerEnemyShootAudio()
    {
            audioSource.clip = enemyShoot;
            audioSource.volume = 0.3f;
            audioSource.Play();
    }
    public void PlayerDieAudio()
    {
            audioSource.clip = die;
            audioSource.volume = 0.05f;
            audioSource.Play();
    }

}
