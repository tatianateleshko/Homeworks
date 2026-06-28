using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Scriptable Objects/GameConfig")]
public class GameConfigData : ScriptableObject
{
    [Header("Chests Settings")]
    public GameObject ChestViewPrefab;
}
