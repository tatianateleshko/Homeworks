using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChestTimerSystem : ITickable
{
    private readonly IChestService _chestService;
    private readonly ITimeService _timeService;

    private List<string> _completeChestTimerBuffer = new(8);
    private float _checkCooldown = 1f;

    public ChestTimerSystem(IChestService chestService, ITimeService timeService)
    {
        _chestService = chestService;
        _timeService = timeService;
    }

    public void Tick()
    {
        _checkCooldown -= Time.deltaTime;

        if (_checkCooldown > 0f)
            return;

        _checkCooldown = 1f;

        var openedChests =_chestService.GetOpenedChests();

        if(openedChests.Count == 0)
            return;

        var now = _timeService.LocalTimeNow();
        _completeChestTimerBuffer.Clear();

        foreach (var kv in openedChests)
        {
            var id = kv.Key;
            var chest = kv.Value;

            if(chest.Timer.IsComplete(now))
                _completeChestTimerBuffer.Add(id);  
        }

        foreach (var readyId in _completeChestTimerBuffer)
        {
            _chestService.MarkChestReady(readyId, now);
        }

        _completeChestTimerBuffer.Clear();
    }
}
