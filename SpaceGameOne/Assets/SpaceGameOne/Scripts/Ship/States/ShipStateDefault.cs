using System;
using SecretCrush.Zenject;
using UnityEngine;

namespace SpaceGameOne.States
{
    public class ShipStateDefault : IObjectState
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Settings _settings;
        public ShipStateDefault(Rigidbody2D rigidbody, Settings settings)
        {
            _rigidbody = rigidbody;
            _settings = settings;
        }

        public void Dispose() {}

        public void Initialize() {}

        public void Update()
        {
            _rigidbody.AddRelativeForce(Vector2.up * Input.GetAxis("Ship Forward") * _settings.Force);
            _rigidbody.AddRelativeForce(Vector2.right * Input.GetAxis("Ship Strafe") * _settings.Force);

            var turn = Input.GetAxis("Ship Turn");

            _rigidbody.AddTorque(turn);
        }

        public void LateUpdate()
        {
            
        }

        [Serializable]
        public class Settings
        {
            public float Force;
        }
    }
}