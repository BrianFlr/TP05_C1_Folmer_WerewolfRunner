using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;

    [SerializeField] private LayerMask layerGround;
    private Rigidbody2D rb;
    public float playerSpeed = 0f;
    public float playerJumpForce = 0f;
    public float rayCastLength = 0.52f;

    public bool isGround = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerSpeed = data.speed;
        playerJumpForce = data.jumpForce;
    }

    private void FixedUpdate()
    {
        // Creo un rayo en la posicion del player mirando hacia abajo que detecte cuándo colisiono con el layer Ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayCastLength, layerGround);

        // Si el rayo colisiona con el layer de Ground va a ser true y en caso contrario, false
        isGround = hit.collider != null;

        //ResetGroundState();

        // Si está en el suelo el player puede moverse y saltar
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
                rb.linearVelocity = new Vector2(0, 1) * playerJumpForce;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayCastLength);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.SetActive(false);
        //playerJumpForce += 1f;
    }
}
