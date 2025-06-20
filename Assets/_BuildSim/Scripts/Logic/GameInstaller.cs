using _BuildSim.Scripts.Logic.Transport;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace _BuildSim.Scripts.Logic
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField, Required, SceneObjectsOnly]
        private UnloadSpotProvider _unloadSpotProvider;

        [SerializeField, Required, SceneObjectsOnly]
        private EndOfMapPositionProvider _endOfMapPositionProvider;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<UnloadSpot>().AsSingle();
            
            Container.BindInterfacesTo<UnloadSpotProvider>().FromInstance(_unloadSpotProvider).AsSingle();
            Container.BindInterfacesTo<EndOfMapPositionProvider>().FromInstance(_endOfMapPositionProvider).AsSingle();
            
            Container.BindInterfacesTo<ResourceContainer>().AsSingle();

            Container.BindInterfacesTo<TransportSpawner>().AsSingle();
        }
    }
}