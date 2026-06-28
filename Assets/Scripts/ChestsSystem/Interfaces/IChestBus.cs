using System;

public interface IChestBus
{
    event Action<string> OnChestOpenClick;
    event Action OnOpenChestWindowClick;

    void ChestOpenClick(string id);
    void ChestCreateClick();
}
