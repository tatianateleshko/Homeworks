using UnityEngine;


[CreateAssetMenu(fileName = "ChestConfig", menuName = "Configs/ChestConfig")]
public class ChestConfigData : ScriptableObject
{
    public string Name;
    public int GoldReward;
    public string UniqueId;
    public float DelayTimeAfterOpen;
    public Sprite Icon;
}
