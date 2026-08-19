using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "TeamSpawnConfig", menuName = "Scriptable Objects/TeamSpawnConfig")]
public class TeamSpawnConfig : SerializedScriptableObject
{
    [SerializeField] private List<TeamSpawnData> _teamSpawnData;

    public TeamSpawnData GetTeamSpawnData(string name)
    {
        if (_teamSpawnData == null)
            return null;
        foreach (var teamSpawnData in _teamSpawnData)
        {
            if (teamSpawnData.Name == name)
                return teamSpawnData;
        }
        
        return null;
    }
}

[Serializable]
public class TeamSpawnData
{
    public string Name;
    public bool IsEnemy;
    public List<UnitData> Units;
}
