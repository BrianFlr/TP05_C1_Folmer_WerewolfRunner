using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxSpeed = 0f;
    [SerializeField] private List<Transform> sprites = new List <Transform>();

    private void Update()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            sprites[i].position = Vector3.left * (parallaxSpeed * Time.deltaTime);
        }

        if (sprites[0].transform.position.x > 0)
        {
            Transform current = sprites[0];
            sprites.Remove(current);
            sprites.Add(current);
        }
    }
}
