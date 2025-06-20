using System.Collections.Generic;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Transport;
using _BuildSim.Scripts.Logic.Interfaces.UnloadSpot;
using Pathfinding;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.Transport
{
    public class TransportQueueService : ITransportQueueService
    {
        private const float SlotLength = 3f;
        
        private readonly IUnloadSpot _spot;
        
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
            {
                transport.StartUnloading();
            }

            return index;
        }

        public void NotifyUnloaded()
        {
            if (_queue.Count == 0)
            {
                return;
            }

            _queue.Dequeue();
            _spot.Occupy(false);

            var index = 0;

            foreach (var t in _queue)
            {
                t.SetQueueIndex(index);

                if (index == 0)
                {
                    t.StartUnloading();
                }

                index++;
            }
        }

        public Vector3 GetSlotPoint(int queueIndex)
        {
            var origin = _spot.Position;

            // Empyric number for exact case. This algorithm is not working, should find another way to build queues
            var dir = new Vector3(1, 0, 1);

            Vector3 roughTarget = origin + dir * SlotLength * (queueIndex + 1);

            var nn = AstarPath.active.GetNearest(roughTarget, NNConstraint.Default);
            
            return nn.position;
        }
    }
}