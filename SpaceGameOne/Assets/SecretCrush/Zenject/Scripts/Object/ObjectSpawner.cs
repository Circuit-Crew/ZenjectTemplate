using UnityEngine;
using Zenject;

namespace SecretCrush.Zenject
{
    public abstract class ObjectSpawner
    {
        protected readonly ObjectGlobalTunables GlobalTunables;
        protected readonly ObjectRegistry ObjectRegistry;

        protected Factory<ObjectTunables, ObjectFacade> ObjectFactory { get; set; }

        protected ObjectSpawner(ObjectGlobalTunables globalTunables,  ObjectRegistry registry)
        {
            GlobalTunables = globalTunables;
            ObjectRegistry = registry;
        }

        public virtual void SpawnObject()
        {
            var settings = new ObjectTunables { };
            ObjectFactory.Create(settings);
        }

        public virtual void SpawnObject(object[] extraArgs)
        {
            var settings = new ObjectTunables { ExtraArgs = extraArgs};
            ObjectFactory.Create(settings);
        }
    }
}