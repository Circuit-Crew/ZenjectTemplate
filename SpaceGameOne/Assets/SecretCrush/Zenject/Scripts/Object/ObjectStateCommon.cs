using System;
using Zenject;

namespace SecretCrush.Zenject
{
    /// <summary>
    ///     Any behavior that is common to all Objects regardless of state or type goes here
    /// </summary>
    public class ObjectStateCommon : IInitializable, IDisposable, ITickable
    {
        private readonly ObjectModel _model;

        public ObjectStateCommon(ObjectModel model)
        {
            _model = model;
        }

        public void Dispose() {}

        public void Initialize() {}

        public void Tick() {}
    }
}