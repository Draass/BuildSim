using _BuildSim.Scripts.Logic.Transport;
using _BuildSim.Scripts.Logic.Transport.States;
using UnityEngine;
using Zenject;

namespace _BuildSim.Scripts.Logic
{
    public class TransportInstaller : MonoInstaller
    {
        [SerializeField] 
        private PathfinderProvider _pathfinderProvider;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PathfinderProvider>().FromInstance(_pathfinderProvider).AsSingle();

            Container.BindInterfacesTo<TransportQueueController>().AsSingle();
            Container.BindInterfacesTo<TransportMovement>().AsSingle();
            
            Container.BindInterfacesTo<MovingToPositionState>().AsSingle();

            Container.BindInterfacesAndSelfTo<TransportStateMachine>().AsSingle();
        }
    }
}