using System;
using System.Collections.Generic;

public class ChestTimerService : IChestTimerService
{
    private readonly IChestService _chestService;

    public ChestTimerService(IChestService chestService)
    {
        _chestService = chestService;
    }

    public void CollectCompletedChestsIds(List<string> buffer, DateTime now)
    {
        var openedChests = _chestService.GetOpenedChests();

        foreach(var kv in openedChests)
        {
            var chestId = kv.Key;
            var chest = kv.Value;

            if(chest.Timer.IsComplete(now))
                buffer.Add(chestId);
        }
    }

    public IEnumerable<ChestTimerState> GetActiveTimers(DateTime now)
    {
        var openedChests = _chestService.GetOpenedChests();
        foreach (var kv in openedChests)
        {
            var chestId = kv.Key;   

            var chest = kv.Value;

            var seconsLeft = chest.Timer.GetRemainTimeInSeconds(now);
            var isComplete = chest.Timer.IsComplete(now);

            yield return new ChestTimerState(chestId, seconsLeft, isComplete);
        }
    }
}
