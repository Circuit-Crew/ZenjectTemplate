using System;
using SecretCrush.Zenject;
using UnityEngine;
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
            PlanetoidSpawner planetoidSpawner)
            : base(globalTunables, registry)
        {
            ObjectFactory = factory;
            _settings = settings;
            _planetoidSpawner = planetoidSpawner;
        }

        public void SpawnInitSystems()
        {
            for (var i = 0; i < _settings.NumberToSpawn; i++)
            {
                var sysFacade = (SystemCenterFacade) SpawnObject();
                var pos = ((SystemCenterModel) sysFacade.Model).Transform;

                var r = Random.insideUnitCircle * _settings.SpawnRadius;
                pos.position = r;
                for (var j = 0; j < _settings.NumberOfPlanetsPerSystem; j++)
                    _planetoidSpawner.SpawnAtPosition(_settings.InitPlanetoidState, pos.position);
            }
        }

        [Serializable]
        public class Settings
        {
            public float SpawnRadius;
            [Range(0, 12)] public int NumberToSpawn;
            [Range(0, 12)] public int NumberOfPlanetsPerSystem;
            public PlanetoidState InitPlanetoidState;
        }
    }
}