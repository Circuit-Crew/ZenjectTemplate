using SecretCrush.Zenject;
using Zenject;

namespace SpaceGameOne
{
    public class SystemCenterFacade : ObjectFacade
    {
        [Inject] private Signals.SystemGrow _systemGrowSignal;


        [Inject]
        public override void Construct(ObjectModel model, ObjectRegistry registry)
        {
            base.Construct(model, registry);
        }

        public void Grow()
        {
            _systemGrowSignal.Fire(this);
        }

        public new class Factory : Factory<ObjectTunables, ObjectFacade> {}
    }
}