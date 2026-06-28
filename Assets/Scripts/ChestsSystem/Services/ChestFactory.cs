using UnityEditorInternal;
using UnityEngine;
using Zenject;

public class ChestFactory : IChestFactory
{

    private readonly IConfigDataService _configDataService;
    private readonly DiContainer   _container;

    public ChestFactory(IConfigDataService configDataService, DiContainer container)
    {
        _configDataService = configDataService;
        _container = container;
    }

    public ChestView CreateChestView(string id, Transform parent)
    {
        var gameConfig = _configDataService.GetGameConfigData();
        var config = _configDataService.GetChest(id);

        var chestObject = Object.Instantiate(gameConfig.ChestViewPrefab, parent);
        var chestView = chestObject.GetComponent<ChestView>();
        chestView.SetUp(config.UniqueId,
            config.Name,
            config.Icon);

        _container.InjectGameObject(chestObject);
        return chestView;
    }

    public ChestState CresteChest(string id)
    {
        var config = _configDataService.GetChest(id);

        var chestState = new ChestState
            (config.UniqueId,
            config.Name,
            config.GoldReward,
            config.DelayTimeAfterOpen);
            
        return chestState;
    }

}
