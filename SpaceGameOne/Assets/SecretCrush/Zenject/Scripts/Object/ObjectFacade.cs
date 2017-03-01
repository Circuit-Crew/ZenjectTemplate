using UnityEngine;
using Zenject;

namespace SecretCrush.Zenject
{
    /// <summary>
    ///     The ObjectFacade is the public API for objects external to the Object to interact with a Object
    /// </summary>
    public abstract class ObjectFacade : MonoBehaviour
    {
        public virtual ObjectModel Model { get; protected set; }
        public virtual ObjectRegistry Registry { get; protected set; }

        [Inject]
        public virtual void Construct(ObjectModel model, ObjectRegistry registry)
        {
            Model = model;
            Registry = registry;

            Register();
        }

        public virtual void Destroy()
        {
            Destroy(gameObject);
        }

        public virtual void Register()
        {
            Registry.AddObject(this);
        }

        // OnDestroy is a unity method that fires automatically on destruction of a monobehavior
        public virtual void OnDestroy()
        {
            Registry.RemoveObject(this);
        }

        public abstract class Factory : Factory<ObjectTunables, ObjectFacade> {}
    }
}