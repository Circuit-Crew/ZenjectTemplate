using SecretCrush.Zenject;
using UnityEngine;
using Zenject;

namespace SpaceGameOne
{
    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public ObjectGlobalTunables ObjectGlobalTunablesSettings;
        public GameInstaller.Settings GameInstallerSettings;
        public PlanetoidSpawner.Settings PlanetoidSpawnerSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(ObjectGlobalTunablesSettings);
            Container.BindInstance(GameInstallerSettings);
            Container.BindInstance(PlanetoidSpawnerSettings);
        }
    }
}