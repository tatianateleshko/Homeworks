using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Objects/UnitData")]
public class UnitData : ScriptableObject, IUnitData
{
    public string UnitName => _name;
    public Sprite Icon => _icon;
    public float Health { get; set; }
    public float AttackValue { get; set; }

    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float Speed;
}
