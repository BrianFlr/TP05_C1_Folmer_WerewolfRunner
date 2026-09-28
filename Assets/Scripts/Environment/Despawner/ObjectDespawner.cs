using UnityEngine;

public class ObjectDespawner : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Desactivo el objeto que entre al trigger de mi despawner
        collision.gameObject.SetActive(false);
    }
}
