using System;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SpaceGameOne
{
    public class SystemCenterSpawner : ObjectSpawner
    {
        private readonly Settings _settings;
        private readonly PlanetoidSpawner _planetoidSpawner;

        public SystemCenterSpawner(
            ObjectGlobalTunables globalTunables,
            ObjectRegistry registry,
            SystemCenterFacade.Factory factory,
            Settings settings,
            [Inject(Id = "PlanetoidSpawner")] ObjectSpawner planetoidSpawner)
            : base(globalTunables, registry)
        {
            ObjectFactory = factory;
            _settings = settings;
            _planetoidSpawner = (PlanetoidSpawner) planetoidSpawner;
        }

        public void SpawnInitSystems()
        {
            for (var i = 0; i < _settings.NumberToSpawn; i++)
            {
                var sysFacade = (SystemCenterFacade) CreateObject();
                var pos = ((SystemCenterModel) sysFacade.Model).Transform;

                var r = Random.insideUnitCircle * _settings.SpawnRadius;
                pos.position = r;
                for (var j = 0; j < _settings.NumberOfPlanetsPerSystem; j++)
                    _planetoidSpawner.CreateAtPosition(_settings.InitPlanetoidState, pos.position);
            }
        }

        [Serializable]
        public class Settings
        {
            public float SpawnRadius;
            [Range(0, 20)] public int NumberToSpawn;
            [Range(0, 12)] public int NumberOfPlanetsPerSystem;
            public PlanetoidState InitPlanetoidState;
        }
    }
}