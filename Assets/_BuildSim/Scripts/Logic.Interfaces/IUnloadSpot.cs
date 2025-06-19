using System;

namespace _BuildSim.Scripts.Logic.Interfaces
{
    public interface IUnloadSpot
    {
        event Action<bool> OnOccupied; 
        
        string ResourceId { get; }
        bool IsOccupied { get; }
        bool Occupy(bool state);

        void EnqueueTransport(ITransportQueueController transport);
        void OnTransportUnloaded();
    }
}