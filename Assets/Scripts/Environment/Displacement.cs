using UnityEngine;

public class Displacement : MonoBehaviour
{
    [SerializeField] private GameplayDataSo data;

    private float displacementSpeed = 0f;

    private void Start()
    {
        displacementSpeed = data.displacementSpeed;
    }

    void Update()
    {
        // Desplazo constantemente al objeto hacia la izquierda
        transform.Translate(Vector2.left * displacementSpeed * Time.deltaTime);
    }
}
