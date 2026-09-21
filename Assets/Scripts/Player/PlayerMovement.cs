using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    private Rigidbody2D rb;

    public float playerSpeed = 0f;
    public float playerJumpSpeed = 0f;

    public bool isGround = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerSpeed = data.speed;
        playerJumpSpeed = data.jumpSpeed;
    }

    private void FixedUpdate()
    {
        ResetGroundState();

        // Si está en el suelo el personaje puede moverse y saltar
        if (isGround)
        {
            if (Input.GetKey(data.moveLeft))
            {
                rb.linearVelocity = new Vector2(-1, 0) * playerSpeed;
            }

            if (Input.GetKey(data.moveRight))
            {
                rb.linearVelocity = new Vector2(1, 0) * playerSpeed;
            }

            if (Input.GetKey(data.jump))
            {
                rb.linearVelocity = new Vector2(0, 1) * playerJumpSpeed;
            }
        }
    }

    private void ResetGroundState()
    {
        float inGroundPosition = -3.23f;
        float playerPositionY = transform.position.y;

        if (playerPositionY <= inGroundPosition)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        playerJumpSpeed += 1f;
    }
}
