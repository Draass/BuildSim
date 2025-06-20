using _BuildSim.Scripts.Data.States;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Common.StateMachine;
using _BuildSim.Scripts.Logic.Interfaces.Transport;
using UnityEngine;
using UnityHFSM;

namespace _BuildSim.Scripts.Logic.Transport.States
{
    public class LeavingMapState : State<TransportState>
    {
        private readonly IMovement _movement;
        private readonly IEndOfMapPositionProvider _endOfMapPositionProvider;
        private readonly IStateMachineTrigger<TransportState> _stateMachineTrigger;
        
        public LeavingMapState(
            IMovement movement,
            IEndOfMapPositionProvider endOfMapPositionProvider,
            IStateMachineTrigger<TransportState> stateMachineTrigger)
        {
            _movement = movement;
            _endOfMapPositionProvider = endOfMapPositionProvider;
            _stateMachineTrigger = stateMachineTrigger;
        }
        
        public override void OnEnter()
        {
            base.OnEnter();

            _movement.CanMove = true;
            
            _movement.MoveTo(_endOfMapPositionProvider.Position);
            
            _movement.OnDestinationReached += MovementOnOnDestinationReached;
            // TODO move to end of map
            
            Debug.Log("Leaving map");
        }

        private void MovementOnOnDestinationReached()
        {
            _movement.OnDestinationReached -= MovementOnOnDestinationReached;
            
            Debug.Log("Leaved map, should dispose this transport");
            
            // TODO free this transport
        }
    }
}