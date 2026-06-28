using System.Collections.Generic;
using UnityEngine;

public interface IConfigDataService
{
    void WarmUp();
    public GameConfigData GetGameConfigData();
    ChestConfigData GetChest(string id);
    IReadOnlyDictionary<string, ChestConfigData> GetAllChest();
}
