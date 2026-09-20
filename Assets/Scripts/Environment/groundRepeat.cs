using UnityEngine;

public class groundRepeat : MonoBehaviour
{
    private float groundPositionLoop = 1.6f;
    private float groundPositionReset = -35f;

    void Update()
    {
        // Si la posicion del suelo es menor al ancho del collider, significa que esta fuera de pantalla
        if (transform.position.x < groundPositionReset)
        {
            // Modifico la posicion del suelo y lo teletransporto delante del actual
            transform.position = new Vector2(groundPositionLoop, -0.85f);
        }
    }
}
