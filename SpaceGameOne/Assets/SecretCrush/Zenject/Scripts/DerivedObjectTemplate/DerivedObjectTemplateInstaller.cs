using System;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class DerivedObjectTemplateInstaller : MonoInstaller<DerivedObjectTemplateInstaller>
    {
        [SerializeField] private Settings _settings = null;

        [InjectOptional] private readonly ObjectTunables _settingsOverride = null;

        public override void InstallBindings()
        {
            Container.BindInstance(_settingsOverride ?? _settings.DefaultSettings);

            Container.Bind<DerivedObjectTemplateModel>().AsSingle();
            Container.Bind<ObjectModel>().To<DerivedObjectTemplateModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<DerivedObjectTemplateStateFactory>().AsSingle();
            Container.Bind<ObjectStateFactory>().To<DerivedObjectTemplateStateFactory>().AsSingle();
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