using Services.GameStateMachine;
using System.Net.NetworkInformation;
using UnityEngine;

namespace Services.StateFactory
{
    public interface IStateFactory
    {
        TState GetState<TState>() where TState : class, IExitableState;
    }

}
