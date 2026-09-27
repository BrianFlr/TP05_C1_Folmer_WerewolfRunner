using System;
using TMPro;
using UnityEngine;

public class UiPlayerPowerUp : MonoBehaviour
{
    [SerializeField] private TMP_Text textTimePowerUp;

    private float powerUpSeconds = 0f;

    // Update is called once per frame
    void Update()
    {
        // Muestro el tiempo activo de los power ups
        powerUpSeconds = GameManager.Instance.GetPowerUpTime();
        TimeSpan timePowerUp = TimeSpan.FromSeconds(powerUpSeconds);
        textTimePowerUp.text = timePowerUp.ToString(@"mm\:ss");
    }
}
