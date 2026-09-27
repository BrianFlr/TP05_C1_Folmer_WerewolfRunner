using System;
using TMPro;
using UnityEngine;

public class UiPlayerPoints : MonoBehaviour
{
    [Header("Canvas Players Points Text")]
    [SerializeField] private TMP_Text textPoints;
    [SerializeField] private TMP_Text textTimePowerUp;
    private float powerUpSeconds = 0f;

    void Update()
    {
        // Muestro los puntos del player
        textPoints.text = GameManager.Instance.GetPlayerPoints().ToString("0");

        // Muestro el tiempo activo de los power ups
        powerUpSeconds = GameManager.Instance.GetPowerUpTime();
        TimeSpan timePowerUp = TimeSpan.FromSeconds(powerUpSeconds);
        textTimePowerUp.text = timePowerUp.ToString(@"mm\:ss");
    }
}
