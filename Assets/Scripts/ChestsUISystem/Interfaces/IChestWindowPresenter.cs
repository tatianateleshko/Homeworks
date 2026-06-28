using UnityEngine;

public interface IChestWindowPresenter
{
    void OpenWindow();
    void UpdateTimer(string id, double currentTime);
    void Register(ChestWindow chestWindow);
}
