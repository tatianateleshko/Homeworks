using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConfigDataService : IConfigDataService
{
    private Dictionary<string, ChestConfigData> _chests = new();
    private GameConfigData _gameConfigData;
    public void WarmUp()
    {
        _chests = Resources.LoadAll<ChestConfigData>("Config/Chests")
            .ToDictionary(x => x.UniqueId, x => x);

        _gameConfigData = Resources.Load<GameConfigData>("Configs/Commov/GameConfig");
    }
    public IReadOnlyDictionary<string, ChestConfigData> GetAllChest() => _chests;

    public ChestConfigData GetChest(string id) => 
        _chests.TryGetValue(id, out var configData)
        ? configData : null;

    public GameConfigData GetGameConfigData() => _gameConfigData;
     
}
