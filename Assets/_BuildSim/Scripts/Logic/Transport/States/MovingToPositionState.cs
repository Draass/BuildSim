using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Data.States;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Common.StateMachine;
using UnityEngine;
using UnityHFSM;

namespace _BuildSim.Scripts.Logic.Transport.States
{
    public class MovingToPositionState : State<TransportState>
    {
        private readonly IUnloadSpot _unloadSpot;
        private readonly IUnloadSpotProvider _unloadSpotProvider;
        private readonly IMovement _movement;
        private readonly IStateMachineTrigger<TransportState> _stateMachineTrigger;

        public MovingToPositionState(
            IUnloadSpot unloadSpot,
            IUnloadSpotProvider unloadSpotProvider,
            IMovement movement,
            IStateMachineTrigger<TransportState> stateMachineTrigger)
        {
            _unloadSpot = unloadSpot;
            _unloadSpotProvider = unloadSpotProvider;
            _movement = movement;
            _stateMachineTrigger = stateMachineTrigger;
        }

        public override void OnEnter()
        {
            _movement.CanMove = true;

            _movement.OnDestinationReached += MovementOnOnDestinationReached;
            _unloadSpot.OnOccupied += UnloadSpotOnOnOccupied;

            _movement.MoveTo(_unloadSpotProvider.Position);
        }

        private void UnloadSpotOnOnOccupied(bool isOccupied)
        {
            _unloadSpot.OnOccupied -= UnloadSpotOnOnOccupied;
            
            if (isOccupied)
            {
                _stateMachineTrigger.Trigger(TransportStateMachineConstants.EnteredQueue);
            }
        }

        public override void OnExit()
        {
            _movement.CanMove = false;
        }

        private void MovementOnOnDestinationReached()
        {
            _movement.OnDestinationReached -= MovementOnOnDestinationReached;

            // TODO если не занят и мы не доехали, надо доехать
            if (_unloadSpot.IsOccupied)
            {
                _stateMachineTrigger.Trigger(TransportStateMachineConstants.EnteredQueue);
            }
            else
            {
                
                Debug.Log("Slot is not occupied, reached destination");
                _stateMachineTrigger.Trigger(TransportStateMachineConstants.DestinationReached);
            }
        }
    }
}