using System.Linq;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class PlanetoidFacade : ObjectFacade
    {
        [Inject] private Signals.DespawnPlanetoid _despawnPlanetoidSignal;
        [Inject] private Signals.SystemGrow _systemGrowSignal;
        [Inject] private PlanetoidModel _model;

        public string[] ValidTags;

        private void Reset(ObjectTunables settings)
        {
            Model.StateManager.Reinitialize(settings);
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (!ValidTags.Any(validTag => collision.gameObject.CompareTag(validTag))) return;
            _despawnPlanetoidSignal.Fire(this);
            _systemGrowSignal.Fire(collision.gameObject.GetComponent<SystemCenterFacade>());
            collision.gameObject.GetComponent<SystemCenterFacade>().Grow();
        }

        public void AddExplosionForce()
        {
            _model.Rigidbody.AddForce(Random.insideUnitCircle * 1000);
        }

        public new class Factory : Factory<ObjectTunables, ObjectFacade> {}

        public class Pool : MonoMemoryPool<ObjectTunables, PlanetoidFacade>
        {
            protected override void Reinitialize(ObjectTunables p1, PlanetoidFacade item)
            {
                item.Reset(p1);
            }

            protected override void OnDespawned(PlanetoidFacade item)
            {
                base.OnDespawned(item);
                item.Registry.RemoveObject(item);
            }
        }
    }
}