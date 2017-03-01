using System;
using SecretCrush.Zenject;

namespace SpaceGameOne
{
    public class DerivedObjectTemplateSpawner : ObjectSpawner
    {
        private readonly Settings _settings;

        public DerivedObjectTemplateSpawner(ObjectGlobalTunables globalTunables, ObjectRegistry registry, DerivedObjectTemplateFacade.Factory factory, Settings settings)
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