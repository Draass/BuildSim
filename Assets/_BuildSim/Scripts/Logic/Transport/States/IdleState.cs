using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Data.States;
using _BuildSim.Scripts.Logic.Interfaces.Common.StateMachine;
using UnityHFSM;

namespace _BuildSim.Scripts.Logic.Transport.States
{
    public class IdleState : State<TransportState>
    {
        private readonly IStateMachineTrigger<TransportState> _stateMachineTrigger;

        public IdleState(IStateMachineTrigger<TransportState> stateMachineTrigger)
        {
            _stateMachineTrigger = stateMachineTrigger;
        }
        
        public override void OnLogic()
        {
            base.OnLogic();

            // TODO проверить возможно ли движение и есть ли цель

            var hasTarget = true;
            
            if (!hasTarget)
            {
                return;
            }
            
            // если движение возможно - ехать и вызвать смену состояния
            
            _stateMachineTrigger.Trigger(TransportStateMachineConstants.TargetFound);
        }
    }
}