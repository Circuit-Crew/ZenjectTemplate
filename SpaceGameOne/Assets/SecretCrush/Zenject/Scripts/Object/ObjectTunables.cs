using System;
using UnityEngine;

namespace SecretCrush.Zenject
{
    /// <summary>
    ///     Passed as parameters on instantiation of a Object instance
    /// </summary>
    [Serializable]
    public class ObjectTunables
    {
        public ObjectStates InitState = ObjectStates.DefaultState;
        public object[] ExtraArgs = null;
    }

    /// <summary>
    ///     Shared between all instances of Object
    /// </summary>
    [Serializable]
    public class ObjectGlobalTunables
    {
    }
}