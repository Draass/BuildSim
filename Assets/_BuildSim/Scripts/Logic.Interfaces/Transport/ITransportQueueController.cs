using System;

namespace _BuildSim.Scripts.Logic.Interfaces.Transport
{
    public interface ITransportQueueController
    {
        event Action<int> OnQueueIndexChanged; 
        
        /// <summary>
        /// Represents queue index. Returns -1 if not in queue
        /// </summary>
        int QueueIndex { get; }
        
        void StartUnloading();
        
        void SetQueueIndex(int index);
    }
}