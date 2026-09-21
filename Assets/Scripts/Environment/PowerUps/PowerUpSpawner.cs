using UnityEngine;
using UnityEngine.Pool;

public class PowerUpSpawner : MonoBehaviour
{
    [Header ("Object Pools")]
    [SerializeField] private CoinObjectPool coinPool;

    // Creo variables GameObject para luego asignarle el objeto que tomare de mis pools
    private GameObject coinClone;

    [SerializeField] private float spawnRate = 2.0f;
    private float coinNextSpawnTime = 0f;
    private float coinRrandomPositionY = 0f;

    void Update()
    {
        // Comparo con si el tiempo paso lo suficiente para volver a spawnear otro cuervo
        if (Time.time >= coinNextSpawnTime)
        {
            spawnRate = Random.Range(5f, 10f);
            coinRrandomPositionY = Random.Range(-3,0);
            SpawnCoin();
        }
    }

    // Funcion para spawnear los cuervos
    private void SpawnCoin()
    {
        // Al tiempo que transcurrio le sumo el ratio de spawn
        coinNextSpawnTime = Time.time + spawnRate;

        // Tomo un objeto de mi pool
        coinClone = coinPool.GetObjectCoin();

        // Ubico el objeto en la posicion X del spawner y en una posicion aleatoria en Y
        coinClone.transform.position = new Vector2(transform.position.x, coinRrandomPositionY);
    }
}
