using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public interface IChestService
{
    ChestState GetChest(string uniqueId);
    bool CanOpenChest(string uniqueId);
    ChestResult TryOpenChest(string uniqueId, DateTime now, out ChestState state);
    void MarkChestReady(string uniqueId, DateTime now);
    void CreateChests();
    IReadOnlyDictionary <string, ChestState> GetOpenedChests();
    IReadOnlyDictionary<string, ChestState> GetAllChests();
    event Action<string, double> OnChestOpen;
    event Action<string, ChestState> OnChestReady;
}
