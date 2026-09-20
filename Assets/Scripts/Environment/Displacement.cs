using UnityEngine;

public class Displacement : MonoBehaviour
{
    private float displacementSpeed = 0f;

    private void Start()
    {
        displacementSpeed = GameManager.Instance.GetDisplacementSpeed();
    }

    void Update()
    {
        // Desplazo constantemente al objeto hacia la izquierda
        transform.Translate(Vector2.left * displacementSpeed * Time.deltaTime);
    }
}
