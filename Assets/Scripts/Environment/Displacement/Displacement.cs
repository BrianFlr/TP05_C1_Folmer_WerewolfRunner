using UnityEngine;

public class Displacement : MonoBehaviour
{
    private float displacementSpeed = 0f;

    void Update()
    {
        // Consulto constantemente la velocidad a la que debe desplazarse
        displacementSpeed = GameManager.Instance.GetDisplacementSpeed();

        // Desplazo constantemente al objeto hacia la izquierda
        transform.Translate(Vector2.left * displacementSpeed * Time.deltaTime);
    }
}
