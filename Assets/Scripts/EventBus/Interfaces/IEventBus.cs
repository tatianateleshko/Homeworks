using System;

public interface IEventBus
{
    void RaiseEvent<T>(T evt);
    void Subscribe<T>(Action<T> handler);
    void Unsubscribe<T>(Action<T> handler);
    
}
