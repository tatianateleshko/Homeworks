using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public interface IChestTimerService
{
    void CollectCompletedChestsIds(List<string> buffer, DateTime now);  
    IEnumerable<ChestTimerState> GetActiveTimers(DateTime now);

}
