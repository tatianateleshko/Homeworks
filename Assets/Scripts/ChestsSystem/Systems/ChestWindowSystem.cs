using Zenject;
using UnityEngine;

public class ChestWindowSystem : IInitializable
{
    private readonly IChestBus _chestBus;
    private readonly IChestWindowPresenter _chestWindowPresenter;
    public void Initialize()
    {
        _chestBus.OnOpenChestWindowClick += OpenChestWindow;
    }

    public void Tick()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            _chestWindowPresenter.OpenWindow(); 
        }
    }

    private void OpenChestWindow()
    {
        _chestWindowPresenter.OpenWindow();
    }
}
