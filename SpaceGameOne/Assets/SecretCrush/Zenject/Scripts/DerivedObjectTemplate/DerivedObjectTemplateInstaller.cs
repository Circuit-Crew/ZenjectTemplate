using System;
using SecretCrush.Zenject;
using SecretCrush.Zenject.DerivedObjectTemplate;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class DerivedObjectTemplateInstaller : MonoInstaller<DerivedObjectTemplateInstaller>
    {
        [InjectOptional] private readonly ObjectTunables _settingsOverride = null; // required for default tunable override below
        [SerializeField] private readonly Settings _settings = null;

        public override void InstallBindings()
        {
            // This allows you to override the default settings in the installer with a different ObjectTunables object
            // that you can create at runtime
            Container.BindInstance(_settingsOverride ?? _settings.DefaultSettings);

            // Cast your init state enum into an int so the StateManager doesn't complain
            //_settings.DefaultSettings.InitState = (int) _settings.InitState;
            Container.BindInstance(_settings.DefaultSettings);

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
            public DerivedObjectTemplateState InitState;
            public ObjectTunables DefaultSettings;
        }
    }
}