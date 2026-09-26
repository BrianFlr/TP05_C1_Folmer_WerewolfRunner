using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameplayDataSo data;

    [SerializeField] private float displacementSpeed = 0f;
    [SerializeField] private float crowDisplacementSpeed = 0f;
    private float playerPoints = 0f;
    private float ratePlayerPoints = 0.4f;
    private float timerPlayerPoints = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        displacementSpeed = data.displacementSpeed;
        crowDisplacementSpeed = data.displacementSpeed * 1.1f;
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
}
