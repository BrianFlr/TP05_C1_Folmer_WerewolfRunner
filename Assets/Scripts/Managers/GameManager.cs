using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] PlayerDataSo playerData;
    [SerializeField] GameplayDataSo gameplayData;

    [SerializeField] GameObject crowObstacle;
    [SerializeField] GameObject skullObstacle;
    [SerializeField] GameObject toadObstacle;
    private int playerLayer = 0;
    private int enemiesLayer = 0;

    private float displacementSpeed = 0f;
    private float crowDisplacementSpeed = 0f;
    private float crowSpeedMultiplier = 1.2f;
    private float boosterDisplacementSpeed = 0.05f;
    private float maxDisplacementSpeed = 10f;
    private float boostSpeedTimer = 0f;
    private float rateBoostSpeed = 3f;
    
    [SerializeField] private int playerHealth = 0;
    [SerializeField] private float powerUpTimer = 0f;
    private float powerUpDefaultTime = 0f;
    private bool isShieldPowerUp = false;

    private float playerPoints = 0f;
    private float playerPointsTimer = 0f;
    private float ratePlayerPoints = 0.4f;

    private bool isDamage = false;
    private float noDamageTimer = 0f;
    private float noDamageDefaultTime = 1.5f;

    private bool isGameOver = false;

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
        playerLayer = LayerMask.NameToLayer("Player");
        enemiesLayer = LayerMask.NameToLayer("Enemies");

        displacementSpeed = gameplayData.displacementSpeed;
        crowDisplacementSpeed = gameplayData.displacementSpeed * crowSpeedMultiplier;
        boosterDisplacementSpeed = gameplayData.boosterDisplacementSpeed;

        playerHealth = playerData.health;
        powerUpTimer = powerUpDefaultTime;
        noDamageTimer = noDamageDefaultTime;
    }

    private void Update()
    {
        boostSpeedTimer += Time.deltaTime;
        playerPointsTimer += Time.deltaTime;

        // Sumo continuamente puntos al jugador 
        if (playerPointsTimer >= ratePlayerPoints)
        {
            playerPoints++;
            playerPointsTimer -= ratePlayerPoints;
        }

        // Aumento continuamente la velocidad de todos los objetos
        if (boostSpeedTimer >= rateBoostSpeed)
        {
            displacementSpeed = Mathf.Clamp(displacementSpeed + boosterDisplacementSpeed, 0f, maxDisplacementSpeed);
            crowDisplacementSpeed = Mathf.Clamp(crowDisplacementSpeed + boosterDisplacementSpeed, 0f, maxDisplacementSpeed * crowSpeedMultiplier);

            boostSpeedTimer -= rateBoostSpeed;
        }

        // Condicion de game over
        if (playerHealth <= 0)
        {
            isGameOver = true;
            playerHealth = playerData.health;
        }
    }

    private void FixedUpdate()
    {
        // Si el jugador tomo un power up de escudo
        if (isShieldPowerUp)
        {
            Physics2D.IgnoreLayerCollision(playerLayer, enemiesLayer, true);

            powerUpTimer -= Time.fixedDeltaTime;

            if (powerUpTimer <= 0)
            {
                isShieldPowerUp = false;
                Physics2D.IgnoreLayerCollision(playerLayer, enemiesLayer, false);
                ResetPowerUpTimer();
            }
        }

        // Si el jugador recibio daño
        if (isDamage)
        {
            // Ignoro las colisiones entre el layer del player y el de los enemigos
            Physics2D.IgnoreLayerCollision(playerLayer, enemiesLayer, true);

            noDamageTimer -= Time.fixedDeltaTime;

            if (noDamageTimer <= 0)
            {
                isDamage = false;
                Physics2D.IgnoreLayerCollision(playerLayer, enemiesLayer, false);
                ResetNoDamageTimer();
            }
        }
    }

    // Get para llevar con facilidad la velocidad de desplazamiento adonde se requiera
    public float GetDisplacementSpeed()
    {
        return displacementSpeed;
    }
    
    // Get de la velocidad de desplazamientos del cuervo
    public float GetCrowDisplacementSpeed()
    {
        return crowDisplacementSpeed;
    }

    // Funciones para la vida del jugador
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

    // Funciones para power ups
    public void SetShieldPowerUpState(bool isPowerUp)
    {
        isShieldPowerUp = isPowerUp;
    }

    public bool GetShieldPowerUpState()
    {
        return isShieldPowerUp;
    }

    public void SetPowerUpDefaultTime(float time)
    {
        powerUpDefaultTime = time;
    }

    public float GetPowerUpTimer()
    {
        return powerUpTimer;
    }

    private void ResetPowerUpTimer()
    {
        powerUpTimer = powerUpDefaultTime;
    }

    // Get para mostrar los puntos del player
    public float GetPlayerPoints()
    {
        return playerPoints;
    }

    // Set de la variable que me indica si recibio daño el jugador
    public void SetDamageState(bool damage)
    {
        isDamage = damage;
    }

    //Reset del contador de tiempo de invulnerabilidad
    private void ResetNoDamageTimer()
    {
        noDamageTimer = noDamageDefaultTime;
    }

    // Get de la variable game over
    public bool GetGameOverState()
    {
        return isGameOver;
    }

    // Reset de la variable GameOver
    public void ResetGameOverState()
    {
        isGameOver = false;
    }
}
