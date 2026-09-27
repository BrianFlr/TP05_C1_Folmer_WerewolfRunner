using UnityEngine;

public class CrowDisplacement : MonoBehaviour
{
    private float crowDisplacementSpeed = 0f;

    void Update()
    {
        // Consulto constantemente la velocidad a la que debe desplazarse
        crowDisplacementSpeed = GameManager.Instance.GetCrowDisplacementSpeed();

        // Desplazo constantemente al objeto hacia la izquierda
        transform.Translate(Vector2.left * crowDisplacementSpeed * Time.deltaTime);
    }
}
