using SecretCrush.Zenject;
using Zenject;

namespace SpaceGameOne.SystemCenter.States
{
    public class SystemCenterStateDefault : IObjectState
    {
        [Inject] private Signals.SystemGrow _systemGrowSignal;
        [Inject] private Signals.Supernova _supernovaSignal;
        private int _growthStage;
        [Inject] private SystemCenterFacade _facade;
        [Inject] private SystemCenterModel _model;

        public void Dispose() {}

        public void Initialize()
        {
            _systemGrowSignal += Grow;
        }

        public void Update() {}

        public void LateUpdate() {}

        private void Grow(SystemCenterFacade facade)
        {
            if (facade == _facade)
            {
                _model.Transform.localScale *= 1.05f;
                _growthStage++;
            }
            if (_growthStage > 10)
                Supernova();
        }

        private void Supernova()
        {
            _growthStage = 0;
            _supernovaSignal.Fire(_model.Transform.position);
            UnityEngine.Object.Destroy(_model.Transform.gameObject);
        }
    }
}