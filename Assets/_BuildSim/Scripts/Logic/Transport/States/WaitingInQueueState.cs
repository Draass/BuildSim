using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Data.States;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Common.StateMachine;
using UnityHFSM;

namespace _BuildSim.Scripts.Logic.Transport.States
{
    public class WaitingInQueueState : State<TransportState>
    {
        private readonly IUnloadSpot _unloadSpot;
        private readonly IStateMachineTrigger<TransportState> _trigger;
        private readonly ITransportQueueController _transportQueueController;
        private readonly ITransportQueueService _transportQueue;
        
        public WaitingInQueueState(
            IUnloadSpot unloadSpot,
            IStateMachineTrigger<TransportState> trigger,
            ITransportQueueController transportQueueController,
            ITransportQueueService transportQueueService)
        {
            _unloadSpot = unloadSpot;
            _trigger = trigger;
            _transportQueueController = transportQueueController;
            _transportQueue = transportQueueService;
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
         
            _transportQueueController.OnQueueIndexChanged += TransportQueueControllerOnOnQueueIndexChanged;
            
            _transportQueue.Enqueue(_transportQueueController);
        }
        
        public override void OnExit()
        {
            base.OnExit();
            
            _transportQueueController.OnQueueIndexChanged -= TransportQueueControllerOnOnQueueIndexChanged;
        }

        private void TransportQueueControllerOnOnQueueIndexChanged(int obj)
        {
            if (obj == 0)
            {
                _trigger.Trigger(TransportStateMachineConstants.ContinueMovement);
            }
        }
    }
}