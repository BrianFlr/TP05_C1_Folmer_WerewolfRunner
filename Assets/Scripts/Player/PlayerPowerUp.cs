using System.Collections;
using UnityEngine;

public class PlayerPowerUp : MonoBehaviour
{
    [SerializeField] GameObject lifePowerUp;
    [SerializeField] GameObject shieldPowerUp;

    private int playerLayer = 0;
    private int enemiesLayer = 0;
    public float invulnerabilityTime = 0f;

    private void Start()
    {
        // Tomo el id de cada layer
        playerLayer = LayerMask.NameToLayer("Player");
        enemiesLayer = LayerMask.NameToLayer("Enemies");
    }

    private void Update()
    {
        
    }

    // Colision con los enemigos u obstaculos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            GameManager.Instance.RemovePlayerHealth();
            invulnerabilityTime = 1f;
            StartCoroutine("Invulnerability");
        }
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
            invulnerabilityTime = 5f;
            StartCoroutine("Invulnerability");
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(playerLayer, enemiesLayer, true);
        yield return new WaitForSeconds(invulnerabilityTime);
        Physics2D.IgnoreLayerCollision(playerLayer, enemiesLayer, false);
    }
}
