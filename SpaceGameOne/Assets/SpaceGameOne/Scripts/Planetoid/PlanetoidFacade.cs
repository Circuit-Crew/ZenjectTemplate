using SecretCrush.Zenject;
using Zenject;

namespace SpaceGameOne
{
    public class PlanetoidFacade : ObjectFacade
    {
        public new class Factory : Factory<ObjectTunables, ObjectFacade> {}
    }
}