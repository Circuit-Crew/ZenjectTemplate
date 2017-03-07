using System.Collections.Generic;

namespace SecretCrush.Zenject
{
    public class ObjectRegistry
    {
        private readonly List<ObjectFacade> _objects = new List<ObjectFacade>();

        public List<ObjectFacade> Objects { get { return _objects; } }

        public void AddObject(ObjectFacade facade)
        {
            _objects.Add(facade);
        }

        public void RemoveObject(ObjectFacade facade)
        {
            _objects.Remove(facade);
        }
    }
}