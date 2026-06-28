using System;
using UnityEngine;

public class TimeService : ITimeService
{
    public DateTime LocalTimePlusOffset(float seconds)
    {
        return LocalTimeNow() + TimeSpan.FromSeconds(seconds);  
    }

    public DateTime LocalTimeNow()
    {
        return DateTime.Now;
    }

    public void SetGlobalTime()
    {

    }
}
