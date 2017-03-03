using SecretCrush.Zenject;
using Zenject;

namespace SpaceGameOne
{
    public class ShipFacade : ObjectFacade
    {
        public new class Factory : Factory<ObjectTunables, ObjectFacade> {}
    }
}