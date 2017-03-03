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

        [Serializable]
        public class Settings
        {
            public Vector2 InitPositionMin;
            public Vector2 InitPositionMax;
        }
    }
}