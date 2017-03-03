using System;
using SecretCrush.Zenject;

namespace SpaceGameOne
{
    public class ShipSpawner : ObjectSpawner
    {
        private readonly Settings _settings;

        public ShipSpawner(ObjectGlobalTunables globalTunables, ObjectRegistry registry, ShipFacade.Factory factory, Settings settings)
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