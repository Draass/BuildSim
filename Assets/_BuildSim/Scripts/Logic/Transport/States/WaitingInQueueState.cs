using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Data.States;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Common.StateMachine;
using UnityEngine;
using UnityHFSM;

namespace _BuildSim.Scripts.Logic.Transport.States
{
    public class WaitingInQueueState : State<TransportState>, ITransportInQueue
    {
        private readonly IUnloadSpotProvider _provider;
        private readonly IUnloadSpot _unloadSpot;
        private readonly IMovement _movement;
        private readonly IStateMachineTrigger<TransportState> _trigger;
        private int _queueIndex = int.MaxValue;

        private const float QueueSpacing = 2.5f;

        public WaitingInQueueState(
            IUnloadSpot unloadSpot,
            IUnloadSpotProvider provider,
            IMovement movement,
            IStateMachineTrigger<TransportState> trigger)
        {
            _unloadSpot = unloadSpot;
            _provider = provider;
            _movement = movement;
            _trigger = trigger;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            _unloadSpot.EnqueueTransport(this);
        }

        public void StartUnloading()
        {
            _trigger.Trigger(TransportStateMachineConstants.StartUnloading);
        }

        public void SetQueueIndex(int index)
        {
            _queueIndex = index;
            MoveToQueueSlot();
        }

        private void MoveToQueueSlot()
        {
            if (_queueIndex < 0)
            {
                return;
            }

            // TODO получать позицию в очереди для движения из unload spot, вынести вычисления туда
            Vector3 target = _provider.Position - Vector3.back * QueueSpacing * (_queueIndex + 1);

            _movement.CanMove = true;
            _movement.MoveTo(target);
        }
    }
}