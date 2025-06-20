using System;
using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Data.States;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Common.StateMachine;
using Cysharp.Threading.Tasks;
using UnityHFSM;

namespace _BuildSim.Scripts.Logic.Transport.States
{
    public class UnloadingState : State<TransportState>
    {
        private readonly IUnloadSpot _unloadSpot;
        private readonly ITransportQueueService _queueService;
        
        private readonly IResourceContainer _resourceContainer;
        private readonly IStateMachineTrigger<TransportState> _stateMachineTrigger;

        private readonly float _unloadTime = 3f;
        
        public UnloadingState(
            IResourceContainer resourceContainer,
            IStateMachineTrigger<TransportState> stateMachineTrigger,
            IUnloadSpot unloadSpot,
            ITransportQueueService transportQueueService)
        {
            _resourceContainer = resourceContainer;
            _stateMachineTrigger = stateMachineTrigger;
            _unloadSpot = unloadSpot;
            _queueService = transportQueueService;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            UnloadAsync().Forget();
        }

        private async UniTaskVoid UnloadAsync()
        {
            _unloadSpot.Occupy(true);
            
            await UniTask.Delay(TimeSpan.FromSeconds(_unloadTime));
            
            _resourceContainer.AddResource(Constants.Brick, 1);

            _queueService.NotifyUnloaded();
            
            _stateMachineTrigger.Trigger(TransportStateMachineConstants.UnloadedTrigger);
        }
    }
}