using System;
using UnityEngine;
using Zenject;

namespace SecretCrush.Zenject.InputModules
{
    public class InputModuleRigidbodyTorque : IFixedTickable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Settings _settings;

        public InputModuleRigidbodyTorque(Rigidbody2D rigidbody, Settings settings)
        {
            _rigidbody = rigidbody;
            _settings = settings;
        }

        public void FixedTick()
        {
            _rigidbody.AddTorque(Input.GetAxis(_settings.TorqueAxis));
        }

        [Serializable]
        public class Settings
        {
            public string TorqueAxis;
            public float Force;
        }
    }
}