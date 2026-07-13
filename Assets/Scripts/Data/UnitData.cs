using Gameplay.Enums;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "Scriptable Objects/UnitData")]
public class UnitData : ScriptableObject, IUnitData
{
    public string UnitName => _name;
    public Sprite Icon => _icon;
    public float Health => _health;
    public float AttackValue => _attackValue;

    public UnitType UnitType => _unitType;

    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _health;
    [SerializeField] private float _attackValue;
    [SerializeField] private UnitType _unitType;
}
