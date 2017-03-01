namespace SecretCrush.Zenject
{
    public abstract class ObjectModel
    {
        public ObjectStateManager StateManager { get; set; }

        protected ObjectModel(ObjectTunables settings, ObjectStateManager stateManager)
        {
            StateManager = stateManager;
        }
    }
}