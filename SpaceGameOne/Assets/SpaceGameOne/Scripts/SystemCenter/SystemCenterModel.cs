using SecretCrush.Zenject;
using UnityEngine;

namespace SpaceGameOne
{
    public class SystemCenterModel : ObjectModel
    {

        public Transform Transform { get; private set; }

        public SystemCenterModel(ObjectTunables settings, ObjectStateManager stateManager, Transform transform)
            : base(settings, stateManager)
        {
            Transform = transform;
        }
    }
}