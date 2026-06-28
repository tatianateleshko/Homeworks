using Zenject;

public class ChestOpenSystem : IInitializable
{
    private readonly IChestBus _bus;
    private readonly IEventBus _eventBus;
    private readonly IChestService _chestService;
    private ITimeService _timeService;

    public ChestOpenSystem(IChestBus bus, IEventBus eventBus, IChestService chestService, ITimeService timeService)
    {
        _bus = bus;
        _eventBus = eventBus;
        _chestService = chestService;
        _timeService = timeService;
    }

    public void Initialize()
    {
        _chestService.CreateChests();
        _bus.OnChestOpenClick += TryOpenChest;
    }


    private void TryOpenChest(string id) 
    {
        var nowTime = _timeService.LocalTimeNow();

        if(_chestService.TryOpenChest(id, nowTime, out var chest).IsSuccess)    
        {
            _eventBus.RaiseEvent(new ChestOpenRewardSignal(chest.GoldReward));
        
        } 
    }
}
