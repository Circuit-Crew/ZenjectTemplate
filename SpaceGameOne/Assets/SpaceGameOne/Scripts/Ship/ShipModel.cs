using SecretCrush.Zenject;

namespace SpaceGameOne
{
    public class ShipModel : ObjectModel
    {
        public ShipModel(ObjectTunables settings, ObjectStateManager stateManager)
            : base(settings, stateManager) {}
    }
}