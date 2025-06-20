using System.Collections.Generic;
using _BuildSim.Scripts.Logic.Interfaces;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.Transport
{
    public class TransportQueueService : ITransportQueueService
    {
        private readonly IUnloadSpot _spot;
        private readonly List<Transform> _slotPoints;
        private readonly Vector3 _fallbackDirection;
        private readonly float _slotLength;
        private readonly Queue<ITransportQueueController> _queue = new();
        
        public TransportQueueService(
            IUnloadSpot spot)
        {
            _spot = spot;
        }

        public IUnloadSpot Spot => _spot;
        
        public int Enqueue(ITransportQueueController transport)
        {
            _queue.Enqueue(transport);
            int index = _queue.Count - 1;
            
            transport.SetQueueIndex(index);

            if (!_spot.IsOccupied && index == 0)
                transport.StartUnloading();

            return index;
        }

        public void NotifyUnloaded()
        {
            if (_queue.Count == 0) return;

            _queue.Dequeue();
            _spot.Occupy(false);

            int index = 0;
            foreach (var t in _queue)
            {
                t.SetQueueIndex(index);
                if (index == 0)
                    t.StartUnloading();
                index++;
            }
        }

        public Vector3 GetSlotPoint(int queueIndex)
        {
            // TODO there was a method in Astar Pro
            
            var origin = _spot.Position;
            
            var dir =  Vector3.back;
            return origin + dir * (_slotLength * (queueIndex + 1));
        }
    }
}