using System;
using Zenject;

namespace SecretCrush.Zenject
{
    public abstract class ObjectStateFactory : IValidatable
    {
        protected readonly DiContainer Container;

        protected ObjectStateFactory(DiContainer container)
        {
            Container = container;
        }

        public abstract void Validate();

        public abstract IObjectState Create(int state, object[] extraArgs = null);
    }
}