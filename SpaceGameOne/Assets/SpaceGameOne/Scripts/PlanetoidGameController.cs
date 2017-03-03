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
        private PlanetoidSpawner _objectSpawner;

        public void Dispose() {}

        [Inject]
        public void Construct([Inject(Id = "PlanetoidSpawner")] ObjectSpawner objectSpawer)
        {
            _objectSpawner = (PlanetoidSpawner) objectSpawer;
            _objectSpawner.SpawnInitPlanetoids();
        }

        public void SpawnObject()
        {
            _objectSpawner.SpawnObject();
        }
    }
}