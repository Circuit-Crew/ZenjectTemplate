using System;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [Inject] private readonly Settings _settings = null;

        public override void InstallBindings()
        {
            Container.Bind<ObjectRegistry>().AsSingle();
            Container.BindFactory<ObjectTunables, ObjectFacade, PlanetoidFacade.Factory>()
                .FromSubContainerResolve()
                .ByNewPrefab<PlanetoidInstaller>(_settings.PlanetoidPrefab);
            Container.Bind<ObjectSpawner>().WithId("PlanetoidSpawner").To<PlanetoidSpawner>().AsSingle();

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
        }
    }
}