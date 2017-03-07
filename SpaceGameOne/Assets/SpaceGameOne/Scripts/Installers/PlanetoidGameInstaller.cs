using System;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class PlanetoidGameInstaller : MonoInstaller<PlanetoidGameInstaller>
    {
        [Inject] private readonly Settings _settings = null;

        public override void InstallBindings()
        {
            Container.Bind<ObjectRegistry>().AsSingle();
            Container.BindFactory<ObjectTunables, ObjectFacade, PlanetoidFacade.Factory>()
                .FromSubContainerResolve()
                .ByNewPrefab<PlanetoidInstaller>(_settings.PlanetoidPrefab);
            Container.Bind<ObjectSpawner>().WithId("PlanetoidSpawner").To<PlanetoidSpawner>().AsSingle();

            Container.BindFactory<ObjectTunables, ObjectFacade, ShipFacade.Factory>()
                .FromSubContainerResolve()
                .ByNewPrefab<ShipInstaller>(_settings.ShipPrefab);
            Container.Bind<ObjectSpawner>().WithId("ShipSpawner").To<ShipSpawner>().AsSingle();

            Container.BindFactory<ObjectTunables, ObjectFacade, SystemCenterFacade.Factory>()
                .FromSubContainerResolve()
                .ByNewPrefab<SystemCenterInstaller>(_settings.SystemCenterPrefab);
            Container.Bind<ObjectSpawner>().WithId("SystemCenterSpawner").To<SystemCenterSpawner>().AsSingle();

            Container.Bind<PlanetoidSpawner>().WhenInjectedInto<SystemCenterSpawner>();

            DeclareSignals();
        }

        private void DeclareSignals()
        {
            // if you have signals 
        }

        [Serializable]
        public class Settings
        {
            public GameObject PlanetoidPrefab;
            public GameObject ShipPrefab;
            public GameObject SystemCenterPrefab;
        }
    }
}