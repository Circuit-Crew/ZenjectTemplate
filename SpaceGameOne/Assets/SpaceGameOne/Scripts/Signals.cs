using Zenject;

namespace SpaceGameOne
{
    public class Signals
    {
        public class DespawnPlanetoid : Signal<PlanetoidFacade, DespawnPlanetoid> {}
    }
}