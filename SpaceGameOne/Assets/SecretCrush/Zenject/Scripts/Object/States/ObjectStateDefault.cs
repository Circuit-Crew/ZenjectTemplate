using System;

namespace SecretCrush.Zenject.States
{
    /// <summary>
    /// Default state. If unmodified will do nothing.
    /// </summary>
    public class ObjectStateDefault : IObjectState
    {
        private readonly ObjectGlobalTunables _globalTunables;
        private readonly ObjectRegistry _registry;
        private readonly ObjectStateManager _stateManager;
        private readonly Settings _settings;
        private readonly ObjectModel _model;

        public ObjectStateDefault(
            ObjectGlobalTunables globalTunables,
            Settings settings,
            ObjectRegistry registry,
            ObjectStateManager stateManager,
            ObjectModel model)
        {
            _globalTunables = globalTunables;
            _registry = registry;
            _stateManager = stateManager;
            _model = model;
            _settings = settings;
        }

        public void Initialize() {}

        public void Dispose() {}

        public void Update() {}

        public void LateUpdate() {}

        [Serializable]
        public class Settings {}
    }
}