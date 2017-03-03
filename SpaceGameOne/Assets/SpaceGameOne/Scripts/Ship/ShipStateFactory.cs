using System;
using ModestTree;
using SecretCrush.Zenject;
using SpaceGameOne.States;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public enum ShipState 
    {
        // The first state must always be a "blank" state 
        // The second state will be the default init state
        None,
        DefaultState
    }

    public class ShipStateFactory : ObjectStateFactory
    {
        public ShipStateFactory(DiContainer container)
            : base(container) {}

        public override void Validate()
        {
            Assert.That(Application.isEditor);

            foreach (var state in new[] { ShipState.DefaultState })
                Create((int) state);
        }

        public override IObjectState Create(int state, object[] extraArgs = null)
        {
            var shipState = (ShipState) state;
            switch (shipState)
            {
                case ShipState.DefaultState:
                    return Container.Instantiate<ShipStateDefault>();
                case ShipState.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("state", state, null);
            }

            throw Assert.CreateException();
        }

        public IObjectState Create(ShipState state, object[] extraArgs = null)
        {
            return Create((int) state, extraArgs);
        }
    }
}