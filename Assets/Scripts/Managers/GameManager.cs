using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameplayDataSo data;

    [SerializeField] private float displacementSpeed = 0f;

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
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    // Get para llevar con facilidad la velocidad de dezplazamiento a donde se requiera
    public float GetDisplacementSpeed()
    {
        return displacementSpeed;
    }
}
