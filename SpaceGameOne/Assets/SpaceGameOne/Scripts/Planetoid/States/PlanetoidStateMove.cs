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
            var d = Vector2.Distance(_model.Rigidbody.position, Vector2.zero);
            var f = 1000 / d * d;
            _model.Rigidbody.AddRelativeForce(new Vector2(_model.Rigidbody.position.y / d, -_model.Rigidbody.position.x / d) * f);
        }

        public void Update() {}

        public void LateUpdate() {}
    }
}