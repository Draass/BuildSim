using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Logic.Interfaces;

namespace _BuildSim.Scripts.Logic.Transport
{
    public class TransportQueueController : ITransportInQueue
    {
        private TransportStateMachine _transportStateMachine;
        
        public void StartUnloading()
        {
            _transportStateMachine.Trigger(TransportStateMachineConstants.DestinationReached);
        }

        public void SetQueueIndex(int index)
        {
            // TODO update transport position?
            throw new System.NotImplementedException();
        }
    }
}