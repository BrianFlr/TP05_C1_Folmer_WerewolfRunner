using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] PlayerDataSo playerData;
    [SerializeField] GameplayDataSo gameplayData;

    [SerializeField] GameObject crowObstacle;
    [SerializeField] GameObject skullObstacle;
    [SerializeField] GameObject toadObstacle;

    [SerializeField] private int playerHealth = 0;
    private float displacementSpeed = 0f;
    private float crowDisplacementSpeed = 0f;
    private float playerPoints = 0f;
    private float timerPlayerPoints = 0f;
    private float ratePlayerPoints = 0.4f;
    private float powerUpTime = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        displacementSpeed = gameplayData.displacementSpeed;
        crowDisplacementSpeed = gameplayData.displacementSpeed * 1.2f;
        playerHealth = playerData.health;
    }

    private void Update()
    {
        timerPlayerPoints += Time.deltaTime;

        // Sumo continuamente puntos al jugador
        if (timerPlayerPoints >= ratePlayerPoints)
        {
            playerPoints++;
            timerPlayerPoints -= ratePlayerPoints;
        }
    }

    // Get para llevar con facilidad la velocidad de dezplazamiento adonde se requiera
    public float GetDisplacementSpeed()
    {
        return displacementSpeed;
    }
    
    // Get de la velocidad de desplazamientos del cuervo
    public float GetCrowDisplacementSpeed()
    {
        return crowDisplacementSpeed;
    }

    // Get para mostrar los puntos del player
    public float GetPlayerPoints()
    {
        return playerPoints;
    }


    public float GetPowerUpTime()
    {
        return powerUpTime;
    }


    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public void AddPlayerHealth()
    {
        if (playerHealth < 3)
        {
            playerHealth++;
        }
    }

    public void RemovePlayerHealth()
    {
        playerHealth--;
    }
}
