using Services.GameStateMachine;
using UnityEngine;
using Zenject;

namespace Services.StateFactory
{
    public class StateFactory : IStateFactory
    {
        private readonly IInstantiator _instantiator;

        public StateFactory(IInstantiator instantiator) =>
            _instantiator = instantiator;

        public TState GetState<TState>() where TState : class, IExitableState =>
            _instantiator.Instantiate<TState>();
    }

}
