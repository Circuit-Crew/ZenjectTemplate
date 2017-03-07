using System;
using ModestTree;
using SpaceGameOne.States;
using UnityEngine;
using Zenject;

namespace SecretCrush.Zenject.SystemCenter
{
    public enum SystemCenterState 
    {
        // The first state must always be a "blank" state 
        // The second state will be the default init state
        None,
        DefaultState
    }

    public class SystemCenterStateFactory : ObjectStateFactory
    {
        public SystemCenterStateFactory(DiContainer container)
            : base(container) {}

        public override void Validate()
        {
            Assert.That(Application.isEditor);

            foreach (var state in new[] { SystemCenterState.DefaultState })
                Create((int) state);
        }

        public override IObjectState Create(int state, object[] extraArgs = null)
        {
            var systemCenterStates = (SystemCenterState) state;
            switch (systemCenterStates)
            {
                case SystemCenterState.DefaultState:
                    return Container.Instantiate<SystemCenterStateDefault>();
                case SystemCenterState.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("state", state, null);
            }

            throw Assert.CreateException();
        }

        public IObjectState Create(SystemCenterState state, object[] extraArgs = null)
        {
            return Create((int) state, extraArgs);
        }
    }
}