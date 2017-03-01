using System;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace LostMemories
{
    /// <summary>
    ///     Component in the scene that acts as the API for other components in the scene to access non-monobehaviors
    ///     e.g. Gives access to Spawners so button events can create windows
    /// </summary>
    public class GameController : MonoBehaviour, IDisposable
    {
        private ObjectSpawner _objectSpawner;


        public void Dispose() {}

        [Inject]
        public void Construct([Inject(Id = "SpaceObjectSpawner")] ObjectSpawner objectSpawer)
        {
            _objectSpawner = objectSpawer;
            SpawnObject();
        }

        public void SpawnObject()
        {
            _objectSpawner.SpawnObject();
        }
    }
}