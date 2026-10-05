using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceSfx;
    [SerializeField] private AudioSource audioSourceBackground;
    [SerializeField] private AudioClip gameOverSound;

    void Update()
    {
        // Reproducir sonido de derrota.
        if (GameManager.Instance.GetPlayerHealth() <= 0)
        {
            audioSourceBackground.Stop();
            audioSourceSfx.PlayOneShot(gameOverSound);
        }
    }
}
