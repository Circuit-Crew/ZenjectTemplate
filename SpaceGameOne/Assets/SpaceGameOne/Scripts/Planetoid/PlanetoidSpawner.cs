using System;
using SecretCrush.Zenject;
using UnityEngine;

namespace SpaceGameOne
{
    public class PlanetoidSpawner : ObjectSpawner
    {
        private readonly Settings _settings;

        public PlanetoidSpawner(ObjectGlobalTunables globalTunables, ObjectRegistry registry, PlanetoidFacade.Factory factory, Settings settings)
            : base(globalTunables, registry)
        {
            ObjectFactory = factory;
            _settings = settings;
        }

        public void SpawnInitPlanetoids()
        {
            for (var i = 0; i < _settings.NumberToSpawn; i++)
                SpawnObject();
        }

        [Serializable]
        public class Settings
        {
            [Range(0, 100)] public int NumberToSpawn;
        }
    }
}