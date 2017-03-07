using SecretCrush.Zenject;
using Zenject;

namespace SpaceGameOne
{
    public class SystemCenterFacade : ObjectFacade
    {
        public new class Factory : Factory<ObjectTunables, ObjectFacade> {}
    }
}