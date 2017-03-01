using SecretCrush.Zenject;

namespace SpaceGameOne
{
    public class DerivedObjectTemplateModel : ObjectModel
    {
        public DerivedObjectTemplateModel(ObjectTunables settings, ObjectStateManager stateManager)
            : base(settings, stateManager) {}
    }
}