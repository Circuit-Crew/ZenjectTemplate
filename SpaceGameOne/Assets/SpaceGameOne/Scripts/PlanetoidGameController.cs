using System;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    /// <summary>
    ///     Component in the scene that acts as the API for other components in the scene to access non-monobehaviors
    ///     e.g. Gives access to Spawners so button events can create windows
    /// </summary>
    public class PlanetoidGameController : MonoBehaviour, IDisposable
    {
        private PlanetoidSpawner _planetoidSpawner;
        private ShipSpawner _shipSpawner;
        private SystemCenterSpawner _systemSpawner;

        public void Dispose() {}

        [Inject]
        public void Construct(
            [Inject(Id = "PlanetoidSpawner")] ObjectSpawner objectSpawer,
            [Inject(Id = "ShipSpawner")] ObjectSpawner shipSpawner,
            [Inject(Id = "SystemCenterSpawner")] ObjectSpawner systemCenterSpawner)
        {

            _systemSpawner = (SystemCenterSpawner) systemCenterSpawner;
            _systemSpawner.SpawnInitSystems();

            _planetoidSpawner = (PlanetoidSpawner) objectSpawer;
            //_planetoidSpawner.DespawnAllPlanetoids();
            _planetoidSpawner.SpawnInitPlanetoids();

            _shipSpawner = (ShipSpawner) shipSpawner;
            //_shipSpawner.SpawnObject();

        }

        public void SpawnObject()
        {
            _planetoidSpawner.CreateObject();
        }
    }
}