using UnityEngine;
using Zenject;

public class ChestTimerViewSystem : ITickable
{
    private readonly IChestService _chestService;
    private readonly ITimeService _timeService;
    private readonly IChestWindowPresenter _chestWindowPresenter;


    private float _updateCooldown = 1f;

    public ChestTimerViewSystem(IChestService chestService,
        ITimeService timeService,
        IChestWindowPresenter chestWindowPresenter)
    {
        _chestService = chestService;
        _timeService = timeService;
        _chestWindowPresenter = chestWindowPresenter;
    }


    public void Tick()
    {
        _updateCooldown -= Time.deltaTime;

        if (_updateCooldown > 0f)
            return;

        _updateCooldown = 1f;

        var openedChests = _chestService.GetOpenedChests();

        if(openedChests.Count == 0)
            return;

        var now = _timeService.LocalTimeNow();


        foreach(var kvp in openedChests)
        {
            var id = kvp.Key;
            var chest = kvp.Value;  

            var secondLeft = chest.Timer.GetRemainTimeInSeconds(now);
            _chestWindowPresenter.UpdateTimer(id, secondLeft);
        }
    }

}
