using RandomFromDistributions;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class PlanetoidModel : ObjectModel
    {
        private readonly PlanetoidInstaller.PlanetoidTunables _tunables;

        public Rigidbody2D Rigidbody { get; private set; }
        public PointEffector2D PointEffector { get; private set; }
        public CircleCollider2D EffectorCollider { get; private set; }
        public CircleCollider2D SpriteCollider { get; private set; }

        public PlanetoidModel(
            ObjectTunables settings,
            ObjectStateManager stateManager,
            PlanetoidInstaller.PlanetoidTunables tunables,
            Rigidbody2D rigidbody,
            PointEffector2D effector,
            [Inject(Id = "EffectorCollider")] CircleCollider2D effectorCollider,
            [Inject(Id = "SpriteCollider")] CircleCollider2D spriteCollider)
            : base(settings, stateManager)
        {
            Rigidbody = rigidbody;
            PointEffector = effector;
            EffectorCollider = effectorCollider;
            _tunables = tunables;
            SpriteCollider = spriteCollider;

            var r =  Random.insideUnitCircle;
            var pos = r  * _tunables.PositionMax;
            Rigidbody.position = pos;

            var exp = new CurveTestScript() {direction = RandomFromDistribution.Direction_e.Left, skew = 100f};
            var scale = exp.GetRandomNumber(1, tunables.RadiusMax);
            SpriteCollider.transform.localScale = Vector3.one * scale;

            Rigidbody.mass = Mathf.PI * scale * scale;

            PointEffector.forceMagnitude = -1 * _tunables.EffectorForceScale * Rigidbody.mass * Rigidbody.mass;
            EffectorCollider.radius = scale * scale * scale * _tunables.EffectorRadiusScale;

            Rigidbody.velocity = Vector2.zero;
        }
    }
}