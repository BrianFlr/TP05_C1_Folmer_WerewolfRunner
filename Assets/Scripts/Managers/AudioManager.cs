using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip gameOverSound;

    void Update()
    {
        // Reprodir sonido de derrota.
        if (GameManager.Instance.GetPlayerHealth() <= 0)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(gameOverSound);
        }
    }
}
