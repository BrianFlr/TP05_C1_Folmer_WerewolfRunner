using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed = 1f;
    [SerializeField] private List<Transform> sprites = new List <Transform>();

    private void Update()
    {
        // Hago mover cada sprite de mi lista hacia la izquierda
        for (int i = 0; i < sprites.Count; i++)
        {
            sprites[i].position += Vector3.left * (parallaxSpeed * Time.deltaTime);
        }

        // Teletransporto el sprite cuando pasa la posicion definida por la mitad de la escala en negativo
        if (sprites[0].transform.localPosition.x < -sprites[0].transform.localScale.x / 2)
        {
            Transform current = sprites[0];
            Transform target = sprites[^1];
            sprites.Remove(current);
            sprites.Add(current);

            float positionX = target.localPosition.x;
            float scaleX = current.localScale.x;
            current.localPosition = new Vector3(positionX + scaleX, 0f, 0f);
        }
    }
}
