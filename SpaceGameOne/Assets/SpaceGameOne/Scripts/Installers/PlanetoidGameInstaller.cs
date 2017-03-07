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
            Container.BindMemoryPool<PlanetoidFacade, PlanetoidFacade.Pool>()
                .WithInitialSize(20)
                .FromComponentInNewPrefab(_settings.PlanetoidPrefab)
                .UnderTransformGroup("Planetoids");
            Container.Bind<ObjectSpawner>().WithId("PlanetoidSpawner").To<PlanetoidSpawner>().AsSingle();

            Container.BindFactory<ObjectTunables, ObjectFacade, ShipFacade.Factory>()
                .FromSubContainerResolve()
                .ByNewPrefab<ShipInstaller>(_settings.ShipPrefab);
            Container.Bind<ObjectSpawner>().WithId("ShipSpawner").To<ShipSpawner>().AsSingle();

            Container.BindFactory<ObjectTunables, ObjectFacade, SystemCenterFacade.Factory>()
                .FromSubContainerResolve()
                .ByNewPrefab<SystemCenterInstaller>(_settings.SystemCenterPrefab);
            Container.Bind<ObjectSpawner>().WithId("SystemCenterSpawner").To<SystemCenterSpawner>().AsSingle();

            DeclareSignals();
        }

        private void DeclareSignals()
        {
            Container.Bind<SignalManager>().AsSingle();
            Container.DeclareSignal<Signals.DespawnPlanetoid>();
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