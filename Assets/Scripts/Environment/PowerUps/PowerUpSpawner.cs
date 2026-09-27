using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header ("PowerUps Array")]
    [SerializeField] private GameObject[] powerUps;

    private float powerUpSpawnRate = 0f;
    private float powerUpSpawnTimer = 10f;
    private float powerUpMinSpawnTime = 15f;
    private float powerUpMaxSpawnTime = 30f;

    private float powerUpMinSpawnRange = -1f;
    private float powerUpMaxSpawnRange = -2.90f;
    private float powerUpRrandomPositionY = 0f;

    private void Start()
    {
        powerUpSpawnRate = powerUpMinSpawnTime;
    }

    private void Update()
    {
        powerUpSpawnTimer += Time.deltaTime;

        // Spawneo un power up después de un tiempo
        if (powerUpSpawnTimer >= powerUpSpawnRate)
        {
            powerUpRrandomPositionY = Random.Range(powerUpMinSpawnRange, powerUpMaxSpawnRange);
            SpawnPowerUp();

            powerUpSpawnTimer -= powerUpSpawnRate;
            powerUpSpawnRate = Random.Range(powerUpMinSpawnTime, powerUpMaxSpawnTime);
        }
    }

    // Funcion para spawnear los power ups
    private void SpawnPowerUp()
    {
        // Tomo un objeto de mi array
        int idPowerUP = Random.Range(0, powerUps.Length);
        GameObject powerUp = powerUps[idPowerUP];

        // Activo el objeto
        powerUp.SetActive(true);

        // Ubico el objeto en la posicion X del spawner
        powerUp.transform.position = new Vector2(transform.position.x, powerUpRrandomPositionY);
    }
}
