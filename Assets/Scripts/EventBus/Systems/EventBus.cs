using System;
using UnityEngine;
using Zenject;

public class EventBus : IEventBus
{
    private SignalBus _signalBus;

    public void RaiseEvent<T>(T evt)
    {
        _signalBus.Fire(evt);
    }

    public void Subscribe<T>(Action<T> handler)
    {
       _signalBus.Subscribe(handler);
    }

    public void Unsubscribe<T>(Action<T> handler)
    {
        _signalBus.TryUnsubscribe(handler);
    }
}
