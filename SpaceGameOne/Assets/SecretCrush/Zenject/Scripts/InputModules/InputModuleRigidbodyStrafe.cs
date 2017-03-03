using System;
using UnityEngine;
using Zenject;

namespace SecretCrush.Zenject.InputModules
{
    public class InputModuleRigidbodyStrafe : IFixedTickable
    {
        private readonly Rigidbody2D _rigidbody;
        private readonly Settings _settings;

        public InputModuleRigidbodyStrafe(Rigidbody2D rigidbody, Settings settings)
        {
            _rigidbody = rigidbody;
            _settings = settings;
        }

        public void FixedTick()
        {
            _rigidbody.AddRelativeForce(Vector2.up * Input.GetAxis(_settings.VerticalAxis) * _settings.Force);
            _rigidbody.AddRelativeForce(Vector2.right * Input.GetAxis(_settings.HorizontalAxis) * _settings.Force);
        }

        [Serializable]
        public class Settings
        {
            public string VerticalAxis;
            public string HorizontalAxis;
            public float Force;
        }
    }
}