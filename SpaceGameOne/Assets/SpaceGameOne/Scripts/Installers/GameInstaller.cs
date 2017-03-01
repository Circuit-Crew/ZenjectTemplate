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
            Container.BindFactory<ObjectTunables, ObjectFacade, SpaceObjectFacade.Factory>()
                .FromSubContainerResolve()
                .ByNewPrefab<SpaceObjectInstaller>(_settings.SpaceObjectPrefab);
            Container.Bind<ObjectSpawner>().WithId("SpaceObjectSpawner").To<SpaceObjectSpawner>().AsSingle();

            DeclareSignals();
        }

        private void DeclareSignals()
        {
            // if you have signals 
        }

        [Serializable]
        public class Settings
        {
            public GameObject SpaceObjectPrefab;
        }
    }
}