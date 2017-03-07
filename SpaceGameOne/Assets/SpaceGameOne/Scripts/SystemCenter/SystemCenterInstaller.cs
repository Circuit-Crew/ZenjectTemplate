using System;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class SystemCenterInstaller : MonoInstaller<SystemCenterInstaller>
    {
        [SerializeField] private Settings _settings = null;

        [InjectOptional] private readonly ObjectTunables _settingsOverride = null;

        public override void InstallBindings()
        {
            // This shows up in the example project but I don't think it works??
            //Container.BindInstance(_settingsOverride ?? _settings.DefaultSettings);

            // Cast your init state enum into an int so the StateManager doesn't complain
            _settings.DefaultSettings.InitState = (int) _settings.InitState;
            Container.BindInstance(_settings.DefaultSettings);

            Container.Bind<SystemCenterModel>().AsSingle();
            Container.Bind<ObjectModel>().To<SystemCenterModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<SystemCenterStateFactory>().AsSingle();
            Container.Bind<ObjectStateFactory>().To<SystemCenterStateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ObjectStateManager>().AsSingle();
            Container.BindInterfacesTo<ObjectStateCommon>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public SystemCenterState InitState;
            public ObjectTunables DefaultSettings;
        }
    }
}