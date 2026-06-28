using UnityEngine;

public interface IChestFactory
{
    ChestView CreateChestView(string id, Transform parent);
    ChestState CresteChest(string id);
}
