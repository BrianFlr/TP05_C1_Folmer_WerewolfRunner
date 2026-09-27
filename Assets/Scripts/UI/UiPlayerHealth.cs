using System.Collections.Generic;
using UnityEngine;

public class UiPlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerDataSo data;
    [SerializeField] private List<GameObject> heartList = new List<GameObject>();

    private void Update()
    {
        // Condiciones para mostrar corazones
        if (GameManager.Instance.GetPlayerHealth() >= 1)
        {
            heartList[0].SetActive(true);
        }
        else
        {
            heartList[0].SetActive(false);
        }

        if (GameManager.Instance.GetPlayerHealth() >= 2)
        {
            heartList[1].SetActive(true);
        }
        else
        {
            heartList[1].SetActive(false);
        }

        if (GameManager.Instance.GetPlayerHealth() >= 3)
        {
            heartList[2].SetActive(true);
        }
        else
        {
            heartList[2].SetActive(false);
        }

    }
}
