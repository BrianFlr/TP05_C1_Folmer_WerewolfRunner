using UnityEngine;

public class groundRepeat : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundWidth = 0f;

    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        groundWidth = groundCollider.bounds.size.x;
    }

    void Update()
    {
        // Si la posicion del suelo es menor al ancho del collider, significa que esta fuera de pantalla
        if (transform.position.x < -groundWidth)
        {
            // Modifico la posicion del suelo y lo teletransporto delante del actual
            transform.Translate(Vector2.right * 2f * groundWidth);
        }
    }
}
