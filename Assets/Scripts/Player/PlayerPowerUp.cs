using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    [SerializeField] GameObject lifePowerUp;
    [SerializeField] GameObject shieldPowerUp;

    private void OnTriggerEnter2D(Collider2D powerUp)
    {
        if (powerUp.gameObject == lifePowerUp)
        {
            GameManager.Instance.AddPlayerHealth();
            powerUp.gameObject.SetActive(false);
        }

        if (powerUp.gameObject == shieldPowerUp)
        {
            GameManager.Instance.AddPlayerHealth();
            powerUp.gameObject.SetActive(false);
        }
    }
}
