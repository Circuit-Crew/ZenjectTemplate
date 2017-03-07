using RandomFromDistributions;
using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class PlanetoidModel : ObjectModel
    {
        private readonly PlanetoidInstaller.PlanetoidTunables _tunables;

        public GameObject GameObject { get; private set; }

        public Rigidbody2D Rigidbody { get; private set; }
        private PointEffector2D PointEffector { get; set; }
        private CircleCollider2D EffectorCollider { get; set; }
        private CircleCollider2D SpriteCollider { get; set; }

        private Transform EffectorSpriteTransform { get; set; }
        public PlanetoidFacade Facade { get; private set; }

        public PlanetoidModel(
            ObjectTunables settings,
            ObjectStateManager stateManager,
            PlanetoidInstaller.PlanetoidTunables tunables,
            Rigidbody2D rigidbody,
            PointEffector2D effector,
            [Inject(Id = "EffectorCollider")] CircleCollider2D effectorCollider,
            [Inject(Id = "SpriteCollider")] CircleCollider2D spriteCollider,
            [Inject(Id = "EffectorSprite")] Transform effectorTransform,
            PlanetoidFacade facade)
            : base(settings, stateManager)
        {
            Rigidbody = rigidbody;
            GameObject = rigidbody.gameObject;
            PointEffector = effector;
            EffectorCollider = effectorCollider;
            _tunables = tunables;
            SpriteCollider = spriteCollider;
            EffectorSpriteTransform = effectorTransform;
            Facade = facade;

            var exp = new CurveTestScript {direction = RandomFromDistribution.Direction_e.Left, skew = 100f};
            var scale = exp.GetRandomNumber(1, tunables.RadiusMax);
            SpriteCollider.transform.localScale = Vector3.one * scale;

            Rigidbody.mass = Mathf.PI * scale * scale;

            PointEffector.forceMagnitude = -1 * _tunables.EffectorForceScale * Rigidbody.mass * Rigidbody.mass;
            EffectorCollider.radius = scale * scale * scale * _tunables.EffectorRadiusScale;
            EffectorSpriteTransform.localScale = Vector2.one * EffectorCollider.radius * 2;

            Rigidbody.velocity = Vector2.zero;
        }
    }
}