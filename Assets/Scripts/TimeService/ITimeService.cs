using System;
using UnityEngine;

public interface ITimeService
{
    DateTime LocalTimeNow();
    DateTime LocalTimePlusOffset(float seconds);
    void SetGlobalTime();
}
