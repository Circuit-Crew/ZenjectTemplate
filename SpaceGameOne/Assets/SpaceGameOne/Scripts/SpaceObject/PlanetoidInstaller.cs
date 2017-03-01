using System;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class PlanetoidInstaller : MonoInstaller<PlanetoidInstaller>
    {
        [SerializeField] private Settings _settings = null;

        [InjectOptional] private ObjectTunables _settingsOverride = null;

        public override void InstallBindings()
        {
            Container.BindInstance(_settingsOverride ?? _settings.DefaultSettings);

            Container.Bind<PlanetoidModel>().AsSingle();
            Container.Bind<ObjectModel>().To<PlanetoidModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlanetoidStateFactory>().AsSingle();
            Container.Bind<ObjectStateFactory>().To<PlanetoidStateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ObjectStateManager>().AsSingle();
            Container.BindInterfacesTo<ObjectStateCommon>().AsSingle();
        }
    }

    [Serializable]
    public class Settings
    {
        public ObjectTunables DefaultSettings;
    }
}