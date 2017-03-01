using SecretCrush.Zenject;
using Zenject;

namespace SpaceGameOne
{
    public class DerivedObjectTemplateFacade : ObjectFacade
    {
        public new class Factory : Factory<ObjectTunables, ObjectFacade> {}
    }
}