using SecretCrush.Zenject;
using SpaceGameOne.Planetoid.States;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class PlanetoidGameSettingsInstaller : ScriptableObjectInstaller<PlanetoidGameSettingsInstaller>
    {
        public ObjectGlobalTunables ObjectGlobalTunablesSettings;
        public PlanetoidGameInstaller.Settings GameInstallerSettings;
        public PlanetoidSpawner.Settings PlanetoidSpawnerSettings;
        public PlanetoidStateMove.Settings PlanetoidMoveStateSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(ObjectGlobalTunablesSettings);
            Container.BindInstance(GameInstallerSettings);
            Container.BindInstance(PlanetoidSpawnerSettings);
            Container.BindInstance(PlanetoidMoveStateSettings);
        }
    }
}