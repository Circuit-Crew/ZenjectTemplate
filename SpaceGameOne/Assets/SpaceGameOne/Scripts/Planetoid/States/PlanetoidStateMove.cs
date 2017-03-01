using SecretCrush.Zenject;
using UnityEngine;

namespace SpaceGameOne.Planetoid.States
{
    public class PlanetoidStateMove : IObjectState
    {
        private readonly PlanetoidModel _model;

        public PlanetoidStateMove(PlanetoidModel model)
        {
            _model = model;
        }

        public void Dispose() {}

        public void Initialize()
        {
            _model.Rigidbody.AddRelativeForce(Vector2.down, ForceMode2D.Impulse);
        }

        public void Update() {}

        public void LateUpdate() {}
    }
}