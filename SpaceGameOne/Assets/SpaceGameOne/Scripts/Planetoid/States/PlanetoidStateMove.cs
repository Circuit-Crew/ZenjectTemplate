using System;
using SecretCrush.Zenject;
using UnityEngine;

namespace SpaceGameOne.Planetoid.States
{
    public class PlanetoidStateMove : IObjectState
    {
        private readonly PlanetoidModel _model;
        private readonly Settings _settings;

        public PlanetoidStateMove(PlanetoidModel model, Settings settings)
        {
            _model = model;
            _settings = settings;
        }

        public void Dispose() {}

        public void Initialize()
        {
            var d = Vector2.Distance(_model.Rigidbody.position, Vector2.zero);
            // this is bad and doesn't actually do what it should do but it's close enough
            var f = _settings.ForceScale * _model.Rigidbody.mass / d * d;
            _model.Rigidbody.AddRelativeForce(new Vector2(_model.Rigidbody.position.y / d, -_model.Rigidbody.position.x / d) * f);
        }

        public void Update() {}

        public void LateUpdate() {}

        [Serializable]
        public class Settings
        {
            public float ForceScale;
        }
    }
}