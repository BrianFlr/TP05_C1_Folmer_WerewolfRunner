using System.Collections;
using UnityEngine;

public class PlayerCollisionEnemies : MonoBehaviour
{
    private int playerLayer = 0;
    private int enemiesLayer = 0;
    private float invulnerabilityTime = 1f;

    void Start()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        enemiesLayer = LayerMask.NameToLayer("Enemies");
    }

    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
    //    {
    //        GameManager.Instance.RemovePlayerHealth();
    //        StartCoroutine("Invulnerability");
    //    }
    //}

    //private IEnumerator Invulnerability()
    //{
    //    Physics2D.IgnoreLayerCollision(playerLayer, enemiesLayer, true);
    //    yield return new WaitForSeconds(invulnerabilityTime);
    //    Physics2D.IgnoreLayerCollision(playerLayer, enemiesLayer, false);
    //}
}
