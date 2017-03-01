using SecretCrush.Zenject;
using UnityEngine;

namespace SpaceGameOne
{
    public class PlanetoidModel : ObjectModel
    {
        public Rigidbody2D Rigidbody { get; private set; }

        public PlanetoidModel(ObjectTunables settings, ObjectStateManager stateManager, Rigidbody2D rigidbody)
            : base(settings, stateManager)
        {
            Rigidbody = rigidbody;
        }
    }
}