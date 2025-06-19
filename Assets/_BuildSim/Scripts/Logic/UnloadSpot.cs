using System;
using System.Collections.Generic;
using System.Linq;
using _BuildSim.Scripts.Logic.Interfaces;
using UnityEngine;

namespace _BuildSim.Scripts.Logic
{
    public class UnloadSpot : IUnloadSpot
    {
        private readonly Queue<ITransportQueueController> _queue = new();
        
        private ITransportQueueController _current;

        public event Action<bool> OnOccupied;
        
        public string ResourceId { get; }
        
        public bool IsOccupied { get; private set; }

        public UnloadSpot()
        {
            ResourceId = GetHashCode().ToString();
        }

        public bool Occupy(bool state)
        {
            Debug.Log($"Slot {ResourceId} is occupied: {state}");
            IsOccupied = state;
            
            OnOccupied?.Invoke(IsOccupied);
            
            return IsOccupied;
        }

        public void EnqueueTransport(ITransportQueueController transport)
        {
            Debug.Log($"Enqueding transport");
            
            _queue.Enqueue(transport);
            UpdateQueueIndices();
            TryProcessNext();
        }

        private void TryProcessNext()
        {
            if (!IsOccupied && _queue.Count > 0)
            {
                _current = _queue.Dequeue();
                IsOccupied = true;
                
                // Assume that transport is at position
                
                _current.StartUnloading();
                UpdateQueueIndices();
            }
        }

        public void OnTransportUnloaded()
        {
            Debug.Log("Transport unloaded");
            
            IsOccupied = false;
            _current = null;
            TryProcessNext();
        }

        private void UpdateQueueIndices()
        {
            int i = 0;
            
            foreach (var t in _queue)
            {
                t.SetQueueIndex(i);
                i++;
            }
        }
    }
}