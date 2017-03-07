using SecretCrush.Zenject;
using SecretCrush.Zenject.InputModules;
using SpaceGameOne.Planetoid.States;
using SpaceGameOne.States;
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
        public ShipSpawner.Settings ShipSpawnerSettings;
        public ShipStateDefault.Settings ShipStateDefaultSettings;
        public InputModuleRigidbodyStrafe.Settings StrafeSettings;
        public InputModuleRigidbodyTorque.Settings TorqueSettings;
        public SystemCenterSpawner.Settings SystemSpawnerSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(ObjectGlobalTunablesSettings);
            Container.BindInstance(GameInstallerSettings);
            Container.BindInstance(PlanetoidSpawnerSettings);
            Container.BindInstance(ShipSpawnerSettings);
            Container.BindInstance(ShipStateDefaultSettings);
            Container.BindInstance(StrafeSettings);
            Container.BindInstance(TorqueSettings);
            Container.BindInstance(SystemSpawnerSettings);
        }
    }
}