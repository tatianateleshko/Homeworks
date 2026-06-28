using System;
using System.Collections.Generic;


public class ChestService : IChestService
{
    public event Action<string, double> OnChestOpen;
    public event Action<string, ChestState> OnChestReady;

    private Dictionary<string, ChestState> _chests = new();
    private Dictionary<string, ChestState> _openedChest = new();

    private readonly ITimeService _time;
    private readonly IChestFactory _chestFactory;
    private readonly IConfigDataService _configs;


    public ChestService(ITimeService time,
        IChestFactory chestFactory, IConfigDataService configs)
    {
        _time = time;
        _chestFactory = chestFactory;
        _configs = configs;
    }

    public bool CanOpenChest(string uniqueId)
    {
        if(!_chests.TryGetValue(uniqueId, out var state)) 
            return false;

        var now = _time.LocalTimeNow();
        return state.CanOpen(now);
    }
     
    public void CreateChests()
    {
        foreach( var kv in _configs.GetAllChest())
        {
            var chestState = _chestFactory.CresteChest(kv.Key);

            _chests.Add(kv.Key, chestState);
        }
    }

    public IReadOnlyDictionary<string, ChestState> GetAllChests()
    {
       return _chests;
    }

    public ChestState GetChest(string uniqueId)
    {
        return _chests[uniqueId];
    }

    public IReadOnlyDictionary<string, ChestState> GetOpenedChests()
    {
        return _openedChest;
    }

    public void MarkChestReady(string uniqueId, DateTime now)
    {
        if (!_openedChest.TryGetValue(uniqueId, out var chest))
            return;
        chest.UpdateReadyState(now);

        if(chest.ReadyToOpen)
            _openedChest.Remove(uniqueId);

        OnChestReady?.Invoke(uniqueId, chest);
       
    }

    public ChestResult TryOpenChest(string uniqueId, DateTime now, out ChestState state)
    {
        state = null;

        if (!_chests.TryGetValue(uniqueId, out var chestState))
            return ChestResult.Fail(ChestFailReason.NotFound);

        if (!chestState.TryOpen(now))
            return ChestResult.Fail(ChestFailReason.NotReady);

        state = chestState;

        _openedChest[uniqueId] = state;

        OnChestOpen?.Invoke(uniqueId, state.Timer.GetRemainTimeInSeconds(now));

        return ChestResult.Success;


    }
}
