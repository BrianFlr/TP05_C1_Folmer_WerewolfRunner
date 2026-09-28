using UnityEngine;

public class UiAudioManager : MonoBehaviour
{
    public static UiAudioManager Instance;

    private AudioSource audioSource;

    [Header("UI Sounds")]
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
        if (audioSource != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }
    }
}
