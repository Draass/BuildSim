using System.Collections.Generic;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.Interfaces
{
    public interface IUnloadSpot
    {
        string ResourceId { get; }
        bool IsOccupied { get; }
        bool Occupy(bool state);

        void EnqueueTransport(ITransportInQueue transport);
        void OnTransportUnloaded();
    }

    public class UnloadSpot : IUnloadSpot
    {
        private readonly Queue<ITransportInQueue> _queue = new();
        
        private ITransportInQueue _current;
        
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
            return IsOccupied;
        }

        public void EnqueueTransport(ITransportInQueue transport)
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

    public interface ITransportInQueue
    {
        void StartUnloading();
        void SetQueueIndex(int index);
    }
}