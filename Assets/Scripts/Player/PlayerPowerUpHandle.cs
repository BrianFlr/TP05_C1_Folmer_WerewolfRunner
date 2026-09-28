using UnityEngine;

public class PlayerPowerUpHandle : MonoBehaviour
{
    [SerializeField] GameObject lifePowerUp;
    [SerializeField] GameObject shieldPowerUp;

    public float powerUpInvulnerabilityTime = 6f;

    private void Start()
    {
        // Le paso el tiempo que durara mi power up a GameManager
        GameManager.Instance.SetPowerUpDefaultTime(powerUpInvulnerabilityTime);
    }

    // Trigger de los power ups
    private void OnTriggerEnter2D(Collider2D powerUp)
    {
        // Si el jugador toma el powerUp de salud
        if (powerUp.gameObject == lifePowerUp)
        {
            powerUp.gameObject.SetActive(false);
            GameManager.Instance.AddPlayerHealth();
        }

        // Si el jugador toma el powerUp de escudo
        if (powerUp.gameObject == shieldPowerUp)
        {
            powerUp.gameObject.SetActive(false);
            GameManager.Instance.SetShieldPowerUpState(true);
        }
    }
}
