using System;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class SpaceObjectInstaller : MonoInstaller<SpaceObjectInstaller>
    {
        [SerializeField] private Settings _settings = null;

        [InjectOptional] private ObjectTunables _settingsOverride = null;

        public override void InstallBindings()
        {
            Container.BindInstance(_settingsOverride ?? _settings.DefaultSettings);

            Container.Bind<SpaceObjectModel>().AsSingle();
            Container.Bind<ObjectModel>().To<SpaceObjectModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpaceObjectStateFactory>().AsSingle();
            Container.Bind<ObjectStateFactory>().To<SpaceObjectStateFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<ObjectStateManager>().AsSingle();
            Container.BindInterfacesTo<ObjectStateCommon>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public ObjectTunables DefaultSettings;
        }
    }


}