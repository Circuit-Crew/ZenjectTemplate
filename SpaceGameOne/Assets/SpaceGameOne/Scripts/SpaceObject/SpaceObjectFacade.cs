using SecretCrush.Zenject;
using Zenject;

namespace SpaceGameOne
{
    public class SpaceObjectFacade : ObjectFacade
    {
        public new class Factory : Factory<ObjectTunables, ObjectFacade> {}
    }
}