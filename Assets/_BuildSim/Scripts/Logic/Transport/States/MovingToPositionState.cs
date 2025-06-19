using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Data.States;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Common.StateMachine;
using UnityHFSM;

namespace _BuildSim.Scripts.Logic.Transport.States
{
    public class MovingToPositionState : State<TransportState>
    {
        private readonly IUnloadSpotProvider _unloadSpotProvider;
        private readonly IMovement _movement;
        private readonly IStateMachineTrigger<TransportState> _stateMachineTrigger;

        public MovingToPositionState(
            IUnloadSpotProvider unloadSpotProvider,
            IMovement movement,
            IStateMachineTrigger<TransportState> stateMachineTrigger)
        {
            _unloadSpotProvider = unloadSpotProvider;
            _movement = movement;
            _stateMachineTrigger = stateMachineTrigger;
        }

        public override void OnEnter()
        {
            _movement.CanMove = true;

            _movement.OnDestinationReached += MovementOnOnDestinationReached;
            
            _movement.MoveTo(_unloadSpotProvider.Position);
        }

        public override void OnExit()
        {
            _movement.CanMove = false;
        }

        private void MovementOnOnDestinationReached()
        {
            _movement.OnDestinationReached -= MovementOnOnDestinationReached;

            _stateMachineTrigger.Trigger(TransportStateMachineConstants.DestinationReached);
            // Invoke transition to another state
        }
    }
}