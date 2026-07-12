using Zenject;
using UnityEngine;

public class ChestWindowSystem : IInitializable, ITickable
{
    private readonly IChestBus _chestBus;
    private readonly IChestWindowPresenter _chestWindowPresenter;

    public ChestWindowSystem(IChestBus chestBus,
   IChestWindowPresenter chestWindow)
    {
        _chestBus = chestBus;
        _chestWindowPresenter = chestWindow;
    }

    public void Initialize()
    {
        _chestBus.OnOpenChestWindowClick += OpenChestWindow;
    }

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _chestWindowPresenter.OpenWindow();
        }
    }

    private void OpenChestWindow()
    {
        _chestWindowPresenter.OpenWindow();
    }
}
