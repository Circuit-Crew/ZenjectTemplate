﻿using System;
using ModestTree;
using SecretCrush.Zenject;
using SpaceGameOne.States;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class DerivedObjectTemplateStateFactory : ObjectStateFactory
    {
        public DerivedObjectTemplateStateFactory(DiContainer container)
            : base(container) {}

        public override void Validate()
        {
            Assert.That(Application.isEditor);

            foreach (var state in new[] { ObjectStates.DefaultState })
                Create(state);
        }

        public override IObjectState Create(ObjectStates state = ObjectStates.DefaultState, object[] extraArgs = null)
        {
            switch(state)
            {
                case ObjectStates.DefaultState:
                    return Container.Instantiate<DerivedObjectTemplateStateDefault>();
                case ObjectStates.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("state", state, null);
            }

            throw Assert.CreateException();
        }
    }
}