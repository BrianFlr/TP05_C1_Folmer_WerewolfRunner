using System.Collections;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    [SerializeField] GameObject lifePowerUp;
    [SerializeField] GameObject shieldPowerUp;

    private int playerLayer = 0;
    private int enemiesLayer = 0;
    public float damageInvulnerabilityTime = 1f;
    public float powerUpInvulnerabilityTime = 6f;

    private void Start()
    {
        // Tomo el id de cada layer
        playerLayer = LayerMask.NameToLayer("Player");
        enemiesLayer = LayerMask.NameToLayer("Enemies");

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
