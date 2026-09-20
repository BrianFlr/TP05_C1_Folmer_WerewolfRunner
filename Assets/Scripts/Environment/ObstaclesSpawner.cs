using UnityEngine;
using UnityEngine.Pool;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] private ObstaclesPool crowPool;

    [SerializeField] private float spawnRate = 2.0f;
    private float nextSpawnTime = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        // Comparo con si el tiempo paso lo suficiente para volver a spawnear otro obstaculo
        if(Time.time >= nextSpawnTime)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        // Al tiempo que transcurrio le sumo el ratio de spawn
        nextSpawnTime = Time.time + spawnRate;
    }
}
