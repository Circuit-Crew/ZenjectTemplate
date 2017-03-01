using System;
using SecretCrush.Zenject;

namespace SpaceGameOne
{
    public class SpaceObjectSpawner : ObjectSpawner
    {
        private readonly Settings _settings;

        public SpaceObjectSpawner(ObjectGlobalTunables globalTunables, ObjectRegistry registry, SpaceObjectFacade.Factory factory, Settings settings)
            : base(globalTunables, registry)
        {
            ObjectFactory = factory;
            _settings = settings;
        }

        [Serializable]
        public class Settings
        {
            
        }
    }
}