using System;
using ModestTree;
using Zenject;

namespace SecretCrush.Zenject
{
    public class ObjectStateManager : ITickable, IInitializable, IDisposable, ILateTickable
    {
        private readonly ObjectStates _initState;
        private readonly object[] _initArgs;

        public ObjectStateFactory StateFactory { get; private set; }
        public IObjectState StateHandler { get; private set; }

        public ObjectStates CurrentState { get; private set; }

        public ObjectStateManager(ObjectTunables settings, ObjectStateFactory stateFactory)
        {
            StateFactory = stateFactory;
            _initState = settings.InitState;
            _initArgs = settings.ExtraArgs;
        }

        public void Dispose()
        {
            if (StateHandler == null) return;
            StateHandler.Dispose();
            StateHandler = null;
        }

        public void Initialize()
        {
            Assert.IsEqual(CurrentState, ObjectStates.None);
            Assert.IsNull(StateHandler);
            ChangeState(_initState, _initArgs);
        }

        public void LateTick()
        {
            StateHandler.LateUpdate();
        }

        public void Tick()
        {
            StateHandler.Update();
        }

        public void ChangeState(ObjectStates state, object[] extraArgs)
        {
            if ((CurrentState == state) && (extraArgs == _initArgs))
                return;

            CurrentState = state;

            if (StateHandler != null)
            {
                StateHandler.Dispose();
                StateHandler = null;
            }

            StateHandler = StateFactory.Create(state, extraArgs);
            StateHandler.Initialize();
        }
    }
}