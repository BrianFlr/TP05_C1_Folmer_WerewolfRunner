using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameplayDataSo data;

    [SerializeField] private float displacementSpeed = 0f;
    [SerializeField] private float crowDisplacementSpeed = 0f;
    private float playerPoints = 0f;
    private float timerPlayerPoints = 2f;

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


        playerPoints += Time.time;
    }

    // Get para llevar con facilidad la velocidad de dezplazamiento a donde se requiera
    public float GetDisplacementSpeed()
    {
        return displacementSpeed;
    }
    
    public float GetCrowDisplacementSpeed()
    {
        return crowDisplacementSpeed;
    }

    public float GetPlayerPoints()
    {
        return playerPoints;
    }
}
