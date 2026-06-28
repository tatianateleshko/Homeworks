using System;
using UnityEngine;

public class ChestBus : IChestBus
{
    public event Action<string> OnChestOpenClick;
    public event Action OnOpenChestWindowClick;

    public void ChestCreateClick() => OnOpenChestWindowClick?.Invoke();
   
    public void ChestOpenClick(string id) => OnChestOpenClick.Invoke(id);
}
