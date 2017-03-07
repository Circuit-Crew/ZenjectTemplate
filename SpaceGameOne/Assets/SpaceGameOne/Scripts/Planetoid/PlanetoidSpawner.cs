using System;
using SecretCrush.Zenject;
using UnityEngine;

namespace SpaceGameOne
{
    public class PlanetoidSpawner : ObjectSpawner
    {
        private readonly Settings _settings;

        public PlanetoidSpawner(
            ObjectGlobalTunables globalTunables,
            ObjectRegistry registry,
            PlanetoidFacade.Factory factory,
            Settings settings)
            : base(globalTunables, registry)
        {
            ObjectFactory = factory;
            _settings = settings;
        }

        public void SpawnInitPlanetoids()
        {
            for (var i = 0; i < _settings.NumberToSpawn; i++)
                SpawnObject(new object[] {Vector2.zero});
        }

        public void SpawnAtPosition(Vector2 pos)
        {
            var obj = SpawnObject(new object[] {pos});
            var model = (PlanetoidModel) obj.Model;
            model.Rigidbody.position += pos;
        }

        public void SpawnAtPosition(PlanetoidState initState, Vector2 pos)
        {
            var obj = SpawnObject(new object[] { pos }, initState);
            var model = (PlanetoidModel)obj.Model;
        }

        private ObjectFacade SpawnObject(object[] extraArgs, PlanetoidState initState = PlanetoidState.DefaultState)
        {
            var t = new ObjectTunables
            {
                InitState = (int) initState,
                ExtraArgs = extraArgs
            };
            var obj = ObjectFactory.Create(t);
            return obj;
        }

        [Serializable]
        public class Settings
        {
            [Range(0, 100)] public int NumberToSpawn;
            public PlanetoidState InitState;
        }
    }
}