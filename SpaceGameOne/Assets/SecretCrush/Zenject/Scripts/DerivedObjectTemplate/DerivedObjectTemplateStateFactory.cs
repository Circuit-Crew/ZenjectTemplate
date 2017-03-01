using System;
using ModestTree;
using SpaceGameOne.States;
using UnityEngine;
using Zenject;

namespace SecretCrush.Zenject.DerivedObjectTemplate
{
    public enum DerivedObjectTemplateState 
    {
        // The first state must always be a "blank" state 
        // The second state will be the default init state
        None,
        DefaultState
    }

    public class DerivedObjectTemplateStateFactory : ObjectStateFactory
    {
        public DerivedObjectTemplateStateFactory(DiContainer container)
            : base(container) {}

        public override void Validate()
        {
            Assert.That(Application.isEditor);

            foreach (var state in new[] { DerivedObjectTemplateState.DefaultState })
                Create((int) state);
        }

        public override IObjectState Create(int state, object[] extraArgs = null)
        {
            var derivedObjectTemplateStates = (DerivedObjectTemplateState) state;
            switch (derivedObjectTemplateStates)
            {
                case DerivedObjectTemplateState.DefaultState:
                    return Container.Instantiate<DerivedObjectTemplateStateDefault>();
                case DerivedObjectTemplateState.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("state", state, null);
            }

            throw Assert.CreateException();
        }

        public IObjectState Create(DerivedObjectTemplateState state, object[] extraArgs = null)
        {
            return Create((int) state, extraArgs);
        }
    }
}