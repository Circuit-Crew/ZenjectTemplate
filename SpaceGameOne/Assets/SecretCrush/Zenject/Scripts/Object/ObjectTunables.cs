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
        public int InitState = 1;
        public object[] ExtraArgs;
    }

    /// <summary>
    ///     Shared between all instances of Object
    /// </summary>
    [Serializable]
    public class ObjectGlobalTunables
    {
    }
}