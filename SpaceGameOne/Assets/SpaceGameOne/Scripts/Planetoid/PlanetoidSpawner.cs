using System;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SpaceGameOne
{
    public class PlanetoidSpawner : ObjectSpawner
    {
        private readonly Settings _settings;
        private readonly PlanetoidFacade.Pool _pool;
        private Signals.DespawnPlanetoid _despawnPlanetoidSignal;
        private Signals.Supernova _supernovaSignal;

        public PlanetoidSpawner(
            ObjectGlobalTunables globalTunables,
            ObjectRegistry registry,
            PlanetoidFacade.Factory factory,
            PlanetoidFacade.Pool pool,
            Settings settings,
            Signals.DespawnPlanetoid despawnPlanetoid,
            Signals.Supernova supernova)
            : base(globalTunables, registry)
        {
            ObjectFactory = factory;
            _settings = settings;
            _pool = pool;
            _supernovaSignal = supernova;

            _despawnPlanetoidSignal = despawnPlanetoid;
            _despawnPlanetoidSignal += DespawnPlanetoid;

            _supernovaSignal += Supernova;
        }

        public void SpawnInitPlanetoids()
        {
            for (var i = 0; i < _settings.NumberToSpawn; i++)
                CreateAtPosition(Random.insideUnitCircle * _settings.InitPositionRange);
        }

        public ObjectFacade CreateAtPosition(Vector2 pos)
        {
            var obj = CreateObject(new object[] {pos});
            var model = (PlanetoidModel) obj.Model;
            model.Rigidbody.position = pos;
            return obj;
        }

        private void Supernova(Vector2 pos)
        {
            for (int i = 0; i < 10; i++)
            {
                var obj = (PlanetoidFacade) CreateAtPosition(pos);
                obj.AddExplosionForce();
            }
        }

        public void CreateAtPosition(PlanetoidState initState, Vector2 pos)
        {
            var obj = CreateObject(new object[] { pos }, initState);
            var model = (PlanetoidModel)obj.Model;

            model.Rigidbody.position = pos + GetRandomSpawnLocation();
        }

        private ObjectFacade CreateObject(object[] extraArgs, PlanetoidState initState = PlanetoidState.DefaultState)
        {
            var t = new ObjectTunables
            {
                InitState = (int) initState,
                ExtraArgs = extraArgs
            };
            //var obj = ObjectFactory.Create(t);
            var obj = _pool.Spawn(t);
            return obj;
        }

        public void DespawnPlanetoid(PlanetoidFacade which)
        {
            _pool.Despawn(which);
        }

        public void DespawnAllPlanetoids()
        {
            _pool.DespawnAll();
        }

        private Vector2 GetRandomSpawnLocation()
        {
            var dist = Random.Range(_settings.PositionMin, _settings.PositionMax);
            var dir = Random.insideUnitCircle.normalized;
            var r = dir * dist;
            return r;
        }

        [Serializable]
        public class Settings
        {
            [Range(0, 100)] public int NumberToSpawn;
            public PlanetoidState InitState;
            public float PositionMin;
            public float PositionMax;
            public float InitPositionRange;
        }
    }
}