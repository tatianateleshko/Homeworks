using Newtonsoft.Json;
using System;
using UnityEngine;

[Serializable]
public class ChestState
{
    public string UniqueID;
    public string Name;
    public int GoldReward;
    public float DelayTimeAfterOpen;
    public TimerData Timer;
    public bool ReadyToOpen;


    [JsonConstructor]
    public ChestState(
        string uniqueId,
        string name,
        int goldReward,
        float delayTimeAfterOpen,
        TimerData timer, 
        bool readyToOpen)
    {
        UniqueID = uniqueId;
        Name = name;
        GoldReward = goldReward;
        DelayTimeAfterOpen = delayTimeAfterOpen;
        Timer = timer ?? new TimerData();
        ReadyToOpen = readyToOpen;
    }

    public ChestState(
        string uniqueId,
        string name,
        int goldReward,
        float delayTimeAfterOpen)
    {
        UniqueID = uniqueId;
        Name = name;
        GoldReward = goldReward;
        DelayTimeAfterOpen = delayTimeAfterOpen;
        Timer =  new TimerData();
        ReadyToOpen = true;
    }

    public bool CanOpen(DateTime now)
    {
        return ReadyToOpen && Timer.IsComplete(now);
    }

    public bool TryOpen(DateTime now)
    {
        if(!CanOpen(now)) return false;

        Open(now);
        return true;
    }

    private void Open(DateTime now)
    {
        ReadyToOpen = false;
        Timer.SetEndTime(now.AddSeconds(DelayTimeAfterOpen));
    }

    public void MakeReady()
    {
        ReadyToOpen = true;
    }

    public void ResetTimer() 
    { 
        Timer.Reset();
    }

    public void UpdateReadyState(DateTime now)
    {
        if(!ReadyToOpen && Timer.IsComplete(now))
            ReadyToOpen = true ;
    }

}
