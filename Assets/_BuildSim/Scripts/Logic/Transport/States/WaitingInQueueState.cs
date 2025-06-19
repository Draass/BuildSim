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
        
        public WaitingInQueueState(
            IUnloadSpot unloadSpot,
            IStateMachineTrigger<TransportState> trigger,
            ITransportQueueController transportQueueController)
        {
            _unloadSpot = unloadSpot;
            _trigger = trigger;
            _transportQueueController = transportQueueController;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            _unloadSpot.EnqueueTransport(_transportQueueController);
            
            _transportQueueController.OnQueueIndexChanged += TransportQueueControllerOnOnQueueIndexChanged;
        }

        private void TransportQueueControllerOnOnQueueIndexChanged(int obj)
        {
            if (obj == 0)
            {
                _trigger.Trigger(TransportStateMachineConstants.ContinueMovement);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            
            _transportQueueController.OnQueueIndexChanged -= TransportQueueControllerOnOnQueueIndexChanged;
        }
    }
}