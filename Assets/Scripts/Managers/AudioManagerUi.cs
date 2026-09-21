using UnityEngine;

public class AudioManagerUi : MonoBehaviour
{
    public static AudioManagerUi Instance;

    private AudioSource audioSource;

    [SerializeField] private AudioClip buttonSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Funciones para reproducir sonidos
    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}
