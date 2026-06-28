using UnityEngine;

public readonly struct ChestTimerState
{
    public readonly string ChestId;
    public readonly double SecondsLeft;
    public readonly bool IsComplete;

    public ChestTimerState(string chestId, double secondsLeft, bool isComplete)
    {
        ChestId = chestId;
        SecondsLeft = secondsLeft;
        IsComplete = isComplete;
    }
}
