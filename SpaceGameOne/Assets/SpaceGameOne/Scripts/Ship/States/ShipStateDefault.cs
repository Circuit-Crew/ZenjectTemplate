using System;
using SecretCrush.Zenject;
using SecretCrush.Zenject.InputModules;
using UnityEngine;

namespace SpaceGameOne.States
{
    public class ShipStateDefault : IObjectState
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Settings _settings;
        private InputModuleRigidbodyStrafe _inputModuleRigidbodyStrafe;
        private InputModuleRigidbodyTorque _inputModuleRigidbodyTorque;

        public ShipStateDefault(
            Rigidbody2D rigidbody,
            Settings settings,
            InputModuleRigidbodyStrafe inputModuleRigidbodyStrafe,
            InputModuleRigidbodyTorque torque)
        {
            _rigidbody = rigidbody;
            _settings = settings;
            _inputModuleRigidbodyStrafe = inputModuleRigidbodyStrafe;
            _inputModuleRigidbodyTorque = torque;
        }

        public void Dispose() {}

        public void Initialize() {}

        public void Update()
        {
        }

        public void LateUpdate() {}

        [Serializable]
        public class Settings {}
    }
}