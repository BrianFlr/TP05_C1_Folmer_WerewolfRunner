using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] PlayerDataSo playerData;
    [SerializeField] GameplayDataSo gameplayData;

    [SerializeField] private int playerHealth = 0;
    private float displacementSpeed = 0f;
    private float crowDisplacementSpeed = 0f;
    private float playerPoints = 0f;
    private float ratePlayerPoints = 0.4f;
    private float timerPlayerPoints = 0f;
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

    void Start()
    {
        displacementSpeed = gameplayData.displacementSpeed;
        crowDisplacementSpeed = gameplayData.displacementSpeed * 1.2f;
        playerHealth = playerData.health;
    }

    void Update()
    {
        if (Time.time > timerPlayerPoints)
        {
            playerPoints++;
            timerPlayerPoints = Time.time + ratePlayerPoints;
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

    public void SetPlayerHealth()
    {
        if (playerHealth < 3)
        {
            playerHealth++;
        }
    }
}
