using UnityEngine;
using Zenject;

namespace _BuildSim.Scripts.Logic
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private UnloadSpotProvider _unloadSpotProvider;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UnloadSpotProvider>().FromInstance(_unloadSpotProvider).AsSingle();
        }
    }
}