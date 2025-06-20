using System;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.UnloadSpot;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.UnloadSpot
{
    public class UnloadSpot : IUnloadSpot
    {
        //private readonly Queue<ITransportQueueController> _queue = new();
        
        //private ITransportQueueController _current;

        public event Action<bool> OnOccupied;

        public Vector3 Position { get; }
        
        public string ResourceId { get; }
        
        public bool IsOccupied { get; private set; }

        public UnloadSpot()
        {
        }

        public void Occupy(bool state)
        {
            IsOccupied = state;
            
            OnOccupied?.Invoke(IsOccupied);
        }

        // public void EnqueueTransport(ITransportQueueController transport)
        // {
        //     Debug.Log($"Enqueding transport");
        //     
        //     _queue.Enqueue(transport);
        //     UpdateQueueIndices();
        //     TryProcessNext();
        // }

        // private void TryProcessNext()
        // {
        //     if (!IsOccupied && _queue.Count > 0)
        //     {
        //         _current = _queue.Dequeue();
        //         IsOccupied = true;
        //         
        //         _current.StartUnloading();
        //         UpdateQueueIndices();
        //     }
        // }
        //
        // public void OnTransportUnloaded()
        // {
        //     Debug.Log("Transport unloaded");
        //     
        //     IsOccupied = false;
        //     _current = null;
        //     TryProcessNext();
        // }
        //
        // private void UpdateQueueIndices()
        // {
        //     int i = 0;
        //     
        //     foreach (var t in _queue)
        //     {
        //         t.SetQueueIndex(i);
        //         i++;
        //     }
        // }
    }
}