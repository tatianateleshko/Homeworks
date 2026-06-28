using System.Collections.Generic;
using UnityEngine;

public class ChestWindowPresenter : IChestWindowPresenter
{
    private Dictionary<string, ChestView> _chestViews = new();
    private readonly IChestService _chestService;
    private IChestFactory _chestFactory;
    private ChestWindow _chestWindow;

    public ChestWindowPresenter(IChestService chestService, IChestFactory chestFactory)
    {
        _chestService = chestService;
        _chestFactory = chestFactory;

        _chestService.OnChestOpen += UpdateTimer;
        _chestService.OnChestReady += ChestReady;
    }

    public void UpdateTimer(string id, double currentTime)
    {
        if(_chestViews.TryGetValue(id, out var chestView))
        {
            chestView.UpdateTimer(currentTime);
        }
    }

    private void ChestReady(string id, ChestState chest)
    {
        if(_chestViews.TryGetValue(id,out var chestView))
        {
            chestView.UpdateState(chest);
        }
    }

    public void OpenWindow()
    {
        foreach(var kv in _chestViews)
           GameObject.Destroy(kv.Value.gameObject);

        _chestViews.Clear();

        foreach(var kv in _chestService.GetAllChests())
        {
            ChestView chestView = _chestFactory.CreateChestView
                (kv.Key, _chestWindow.ChestParent);
            chestView.UpdateState(kv.Value);
            _chestViews.Add(kv.Key, chestView);
        }

        _chestWindow.UpdateWindow();
    }

    public void Register(ChestWindow chestWindow)
    {
        _chestWindow = chestWindow;
    }
}
