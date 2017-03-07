using System;
using SecretCrush.Zenject;
using UnityEngine;

namespace SpaceGameOne.Planetoid.States
{
    public class PlanetoidStateMove : IObjectState
    {
        private readonly PlanetoidModel _model;
        private readonly Vector2 _initCenterPos;

        public PlanetoidStateMove(PlanetoidModel model, Vector2 initCenterPos)
        {
            _model = model;
            _initCenterPos = initCenterPos;
        }

        public void Dispose() {}

        public void Initialize()
        {
            var d = Vector2.Distance(_model.Rigidbody.position, _initCenterPos);
            var _relPos = _model.Rigidbody.position - _initCenterPos;
            var g = 1000f / (d * d);
            var angularVelocity = Mathf.Sqrt(1000 / d);
            //var angularVel = Mathf.Abs(g) * Mathf.Sin(90 * Mathf.Deg2Rad) / d;
            var dir = new Vector2(_relPos.y, -_relPos.x).normalized;
            //_model.Rigidbody.velocity = dir * angularVelocity;
            _model.Rigidbody.AddForce(dir * angularVelocity, ForceMode2D.Impulse);
        }

        public void Update() {}

        public void LateUpdate()
        {
            if (_model.Rigidbody.position.sqrMagnitude > (1000 * 1000)) GameObject.Destroy(_model.Rigidbody.gameObject);
        }

    }
}