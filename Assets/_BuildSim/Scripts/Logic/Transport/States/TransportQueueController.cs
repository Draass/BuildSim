using System;
using System.Collections.Generic;
using _BuildSim.Scripts.Logic.Interfaces;
using Pathfinding;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.Transport.States
{
    public class TransportQueueController : ITransportQueueController
    {
        public event Action<int> OnQueueIndexChanged;

        public int QueueIndex { get; private set; }

        private readonly IUnloadSpot _unloadSpot;
        private readonly IUnloadSpotProvider _unloadSpotProvider;
        private readonly IMovement _movement;

        private IAstarAI _astarAI;

        public TransportQueueController(
            IUnloadSpot unloadSpot, 
            IMovement movement,
            IUnloadSpotProvider unloadSpotProvider)
        {
            _unloadSpot = unloadSpot;
            _movement = movement;
            _unloadSpotProvider = unloadSpotProvider;
        }

        public void StartUnloading()
        {
            // TODO remove this to qaiting queue state probably
            _unloadSpot.Occupy(false);
        }

        public void SetQueueIndex(int index)
        {
            _movement.CanMove = false;

            QueueIndex = index;

            OnQueueIndexChanged?.Invoke(index);

            // UpdateTransportPosition(index);
        }
    }
}