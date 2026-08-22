using UI;
using UnityEngine;

public struct PlayerViewSelectedSignal
{
    public readonly UnitView PlayerView;

    public PlayerViewSelectedSignal(UnitView unitView)
    {
        PlayerView = unitView;
    }
}
