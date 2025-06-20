using _BuildSim.Scripts.Logic.Interfaces.UnloadSpot;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.Interfaces.Transport
{
    public interface ITransportQueueService
    {
        IUnloadSpot Spot { get; }

        /// <summary>
        /// Enqueue transport and get it's position in the queue
        /// </summary>
        /// <param name="transport"></param>
        /// <returns></returns>
        int Enqueue(ITransportQueueController transport);
        
        void NotifyUnloaded();

        /// <summary>
        /// Return position in queue. If 0, returns unload point position
        /// </summary>
        /// <param name="queueIndex"></param>
        /// <returns></returns>
        Vector3 GetSlotPoint(int queueIndex);
    }
}