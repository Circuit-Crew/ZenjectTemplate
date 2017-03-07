using System;
using ModestTree;
using SecretCrush.Zenject;
using SpaceGameOne.Planetoid.States;
using SpaceGameOne.States;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public enum PlanetoidState
    {
        None,
        DefaultState,
        Move
    }

    public class PlanetoidStateFactory : ObjectStateFactory
    {
        public PlanetoidStateFactory(DiContainer container)
            : base(container) {}

        public override void Validate()
        {
            Assert.That(Application.isEditor);

            foreach (var state in new[] { PlanetoidState.DefaultState, PlanetoidState.Move })
                Create(state, new object[] {Vector2.zero});
        }

        public override IObjectState Create(int state, object[] extraArgs = null)
        {
            var planetoidStates = (PlanetoidState) state;
            switch (planetoidStates)
            {
                case PlanetoidState.DefaultState:
                    return Container.Instantiate<PlanetoidStateDefault>();
                case PlanetoidState.None:
                    break;
                case PlanetoidState.Move:
                    return Container.Instantiate<PlanetoidStateMove>(extraArgs);
                default:
                    throw new ArgumentOutOfRangeException("state", state, null);
            }

            throw Assert.CreateException();
        }

        public IObjectState Create(PlanetoidState state, object[] extraArgs = null)
        {
            return Create((int)state, extraArgs);
        }
    }
}