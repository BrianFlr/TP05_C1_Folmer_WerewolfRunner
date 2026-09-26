using UnityEngine;

[CreateAssetMenu(fileName = "GameplayData", menuName = "Data/Game/GameplayData")]

public class GameplayDataSo : ScriptableObject
{
    [Range(5, 25)] public float displacementSpeed = 5f;
    [Range(5, 25)] public float crowDisplacementSpeed = 5f;
}
