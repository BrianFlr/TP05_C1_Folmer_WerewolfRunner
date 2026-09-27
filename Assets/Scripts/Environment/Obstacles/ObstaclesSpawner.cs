using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [Header ("Object Pools")]
    [SerializeField] private CrowObjectPool crowPool;
    [SerializeField] private SkullObjectPool skullPool;
    [SerializeField] private ToadObjectPool toadPool;

    // Creo variables GameObject para luego asignarle el objeto que tomare de mis pools
    private GameObject crowClone;
    private GameObject skullClone;
    private GameObject toadClone;

    private float crowSpawnRate = 0f;
    private float toadSpawnRate = 0f;
    private float crowSpawnTimer = 0f;
    private float toadSpawnTimer = 0f;
    private float crowRrandomPositionY = 0f;

    void Update()
    {
        crowSpawnTimer += Time.deltaTime;
        toadSpawnTimer += Time.deltaTime;

        // Comparo con si el tiempo paso lo suficiente para volver a spawnear otro cuervo
        if (Time.time >= crowSpawnRate)
        {
            crowRrandomPositionY = Random.Range(-1.5f,5f);
            SpawnCrow();

            crowSpawnTimer -= crowSpawnRate;
            crowSpawnRate = Random.Range(1.5f, 3f);
        }

        // Comparo con si el tiempo paso lo suficiente para volver a spawnear otro cuervo
        if (Time.time >= toadSpawnRate)
        {
            SpawnToad();

            toadSpawnTimer -= toadSpawnRate;
            toadSpawnRate = Random.Range(4f, 5f);
        }
    }

    // Funcion para spawnear los cuervos
    private void SpawnCrow()
    {
        // Tomo un objeto de mi pool
        crowClone = crowPool.GetObjectCrow();

        // Ubico el objeto en la posicion X del spawner y en una posicion aleatoria en Y
        crowClone.transform.position = new Vector2(transform.position.x, crowRrandomPositionY);
    }

    // Funcion para spawnear los cuervos
    private void SpawnToad()
    {
        // Tomo un objeto de mi pool
        toadClone = toadPool.GetObjectToad();

        // Ubico el objeto en la posicion X del spawner y en una posicion definida en Y
        toadClone.transform.position = new Vector2(transform.position.x, -3.20f);
    }
}
