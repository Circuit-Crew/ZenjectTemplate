using System;
using SecretCrush.Zenject;
using SecretCrush.Zenject.InputModules;
using SpaceGameOne.States;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class ShipInstaller : MonoInstaller<ShipInstaller>
    {
        [InjectOptional] private ObjectTunables _settingsOverride = null;
        [SerializeField] private Settings _settings = null;

        public override void InstallBindings()
        {
            // This shows up in the example project but I don't think it works??
            //Container.BindInstance(_settingsOverride ?? _settings.DefaultSettings);

            // Cast your init state enum into an int so the StateManager doesn't complain
            _settings.DefaultSettings.InitState = (int) _settings.InitState;
            Container.BindInstance(_settings.DefaultSettings);

            Container.Bind<ShipModel>().AsSingle();
            Container.Bind<ObjectModel>().To<ShipModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<ShipStateFactory>().AsSingle();
            Container.Bind<ObjectStateFactory>().To<ShipStateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ObjectStateManager>().AsSingle();
            Container.BindInterfacesTo<ObjectStateCommon>().AsSingle();

            Container.BindInterfacesAndSelfTo<InputModuleRigidbodyStrafe>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputModuleRigidbodyTorque>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public ShipState InitState;
            public ObjectTunables DefaultSettings;
        }
    }
}