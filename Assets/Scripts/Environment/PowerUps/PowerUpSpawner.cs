using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [Header ("Object Array")]
    [SerializeField] private GameObject[] powerUps;

    private float spawnRate = 2.0f;
    private float powerUpNextSpawnTime = 10f;
    private float powerUpRrandomPositionY = 0f;

    void Update()
    {
        // Comparo con si el tiempo paso lo suficiente para volver a spawnear otro
        if (Time.time >= powerUpNextSpawnTime)
        {
            spawnRate = Random.Range(15f, 30f);
            powerUpRrandomPositionY = Random.Range(-1f,-2.90f);
            SpawnPowerUp();
        }
    }

    // Funcion para spawnear los power ups
    private void SpawnPowerUp()
    {
        // Al tiempo que transcurrio le sumo el ratio de spawn
        powerUpNextSpawnTime = Time.time + spawnRate;

        // Tomo un objeto de mi array
        int idPowerUP = Random.Range(0, powerUps.Length);
        GameObject powerUp = powerUps[idPowerUP];

        // Activo el objeto
        powerUp.SetActive(true);

        // Ubico el objeto en la posicion X del spawner
        powerUp.transform.position = new Vector2(transform.position.x, powerUpRrandomPositionY);
    }
}
