using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    [SerializeField] private GameObject floor;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == floor)
        {
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == floor)
        {
            isGround = false;
        }
    }
}
