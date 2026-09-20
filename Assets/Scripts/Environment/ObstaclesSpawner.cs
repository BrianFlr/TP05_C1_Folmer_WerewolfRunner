using UnityEngine;
using UnityEngine.Pool;

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

    [SerializeField] private float spawnRate = 2.0f;
    private float crowNextSpawnTime = 0f;
    private float crowRrandomPositionY = 0f;

    void Update()
    {
        // Comparo con si el tiempo paso lo suficiente para volver a spawnear otro cuervo
        if (Time.time >= crowNextSpawnTime)
        {
            spawnRate = Random.Range(0.5f, 3f);
            crowRrandomPositionY = Random.Range(-3,5);
            SpawnCrow();
        }
    }

    // Funcion para spawnear los cuervos
    private void SpawnCrow()
    {
        // Al tiempo que transcurrio le sumo el ratio de spawn
        crowNextSpawnTime = Time.time + spawnRate;
        
        // Tomo un objeto de mi pool
        crowClone = crowPool.GetObjectCrow();

        // Ubico el objeto en la posicion X del spawner y en una posicion aleatoria en Y
        crowClone.transform.position = new Vector2(transform.position.x, crowRrandomPositionY);
    }
}
