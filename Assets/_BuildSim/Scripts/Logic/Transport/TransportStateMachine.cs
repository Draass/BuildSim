using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Data.States;
using _BuildSim.Scripts.Logic.Interfaces.Common.StateMachine;
using _BuildSim.Scripts.Logic.Transport.States;
using UnityHFSM;
using Zenject;

namespace _BuildSim.Scripts.Logic.Transport
{
    /// <summary>
    /// To see states visualization check <see cref="TransportStateMachine.puml"/>
    /// </summary>
    public class TransportStateMachine : StateMachine<TransportState>, ITickable, IInitializable,
        IStateMachineTrigger<TransportState>
    {
        private readonly IInstantiator _instantiator;

        public TransportStateMachine(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public void Initialize()
        {
            Init();
        }

        public override void Init()
        {
            SetStartState(TransportState.Idle);

            AddState(TransportState.Idle, _instantiator.Instantiate<IdleState>());
            AddState(TransportState.MovingToUnloadSpot, _instantiator.Instantiate<MovingToPositionState>());
            AddState(TransportState.Unloading, _instantiator.Instantiate<UnloadingState>());
            AddState(TransportState.WaitingInQueue, _instantiator.Instantiate<WaitingInQueueState>());
            AddState(TransportState.LeavingMap, _instantiator.Instantiate<LeavingMapState>());
            
            AddTriggerTransition(TransportStateMachineConstants.TargetFound,
                new Transition<TransportState>(TransportState.Idle, TransportState.MovingToUnloadSpot));
            
            AddTriggerTransition(TransportStateMachineConstants.DestinationReached,
                new Transition<TransportState>(TransportState.MovingToUnloadSpot, TransportState.Unloading));
            
            AddTriggerTransition(TransportStateMachineConstants.EnteredQueue,
                new Transition<TransportState>(TransportState.MovingToUnloadSpot, TransportState.WaitingInQueue));

            AddTriggerTransition(TransportStateMachineConstants.StartUnloading,
                new Transition<TransportState>(TransportState.WaitingInQueue, TransportState.Unloading));
            
            AddTriggerTransition(TransportStateMachineConstants.UnloadedTrigger,
                new Transition<TransportState>(TransportState.Unloading, TransportState.LeavingMap));
            
            AddTriggerTransition(TransportStateMachineConstants.ContinueMovement,
                new Transition<TransportState>(TransportState.WaitingInQueue, TransportState.MovingToUnloadSpot));
            
            base.Init();
        }

        public void Tick()
        {
            OnLogic();
        }
    }
}