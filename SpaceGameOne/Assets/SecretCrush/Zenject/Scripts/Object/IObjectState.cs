using System;

namespace SecretCrush.Zenject
{
    public interface IObjectState : IDisposable
    {
        void Initialize();
        void Update();
        void LateUpdate();
    }
}