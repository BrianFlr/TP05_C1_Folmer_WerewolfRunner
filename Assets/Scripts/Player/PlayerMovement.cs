using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ScriptableObject playerData;

    private Rigidbody2D player;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(playerData.jump))
        //{

        //}
    }
}
