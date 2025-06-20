using System;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.Interfaces.UnloadSpot
{
    public interface IUnloadSpot
    {
        // TODO make this thinner, too much logic

        // Queue should be absolutely other thing

        event Action<bool> OnOccupied;

        Vector3 Position { get; }
        
        string ResourceId { get; }

        bool IsOccupied { get; }

        void Occupy(bool state);

        // void EnqueueTransport(ITransportQueueController transport);
        //
        // void OnTransportUnloaded();
    }
}