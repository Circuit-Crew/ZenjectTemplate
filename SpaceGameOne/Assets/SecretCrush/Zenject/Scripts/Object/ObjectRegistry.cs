using System.Collections.Generic;

namespace SecretCrush.Zenject
{
    public class ObjectRegistry
    {
        private readonly List<ObjectFacade> _Objects = new List<ObjectFacade>();

        public List<ObjectFacade> Objects { get { return _Objects; } }

        public void AddObject(ObjectFacade facade)
        {
            _Objects.Add(facade);
        }

        public void RemoveObject(ObjectFacade facade)
        {
            _Objects.Remove(facade);
        }
    }
}