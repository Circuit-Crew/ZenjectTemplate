namespace SecretCrush.Zenject
{
    public abstract class ObjectModel
    {
        public ObjectStateManager StateManager { get; set; }
        public ObjectTunables Settings { get; set; }

        protected ObjectModel(ObjectTunables settings, ObjectStateManager stateManager)
        {
            Settings = settings;
            StateManager = stateManager;
        }
    }
}