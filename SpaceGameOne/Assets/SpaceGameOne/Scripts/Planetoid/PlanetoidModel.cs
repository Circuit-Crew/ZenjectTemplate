using SecretCrush.Zenject;

namespace SpaceGameOne
{
    public class PlanetoidModel : ObjectModel
    {
        public PlanetoidModel(ObjectTunables settings, ObjectStateManager stateManager)
            : base(settings, stateManager) {}
    }
}