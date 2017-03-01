using SecretCrush.Zenject;

namespace SpaceGameOne
{
    public class SpaceObjectModel : ObjectModel
    {
        public SpaceObjectModel(ObjectTunables settings, ObjectStateManager stateManager)
            : base(settings, stateManager) {}
    }
}