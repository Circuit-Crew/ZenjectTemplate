using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    public class Signals
    {
        public class DespawnPlanetoid : Signal<PlanetoidFacade, DespawnPlanetoid> {}

        public class SystemGrow : Signal<SystemCenterFacade, SystemGrow> {}

        public class Supernova : Signal<Vector2, Supernova> {}
    }
}