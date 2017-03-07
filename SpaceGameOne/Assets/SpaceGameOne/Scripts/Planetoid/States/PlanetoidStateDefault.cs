using SecretCrush.Zenject;
using Zenject;

namespace SpaceGameOne.States
{
    public class PlanetoidStateDefault : IObjectState
    {
        private readonly PlanetoidModel _model;

        [Inject] private Signals.DespawnPlanetoid _despawnPlanetoid;

        public PlanetoidStateDefault(PlanetoidModel model)
        {
            _model = model;
        }

        public void Dispose() {}

        public void Initialize() {}

        public void Update() {}

        public void LateUpdate()
        {
            if (_model.Rigidbody.position.sqrMagnitude > 1000 * 1000) _despawnPlanetoid.Fire(_model.Facade);
        }
    }
}