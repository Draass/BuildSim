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

        //private readonly ITransportQueue _transportQueue;
        
        private readonly IUnloadSpot _unloadSpot;
        private readonly IUnloadSpotProvider _unloadSpotProvider;
        private readonly ITransportQueueService _queueService;
        private readonly IMovement _movement;

        private IAstarAI _astarAI;

        public TransportQueueController(
            IUnloadSpot unloadSpot, 
            IMovement movement,
            IUnloadSpotProvider unloadSpotProvider,
            ITransportQueueService transportQueueService)
        {
            _unloadSpot = unloadSpot;
            _movement = movement;
            _unloadSpotProvider = unloadSpotProvider;
            _queueService = transportQueueService;
        }

        public void StartUnloading()
        {
            // TODO remove this to qaiting queue state probably
            SetQueueIndex(0);
            
            _unloadSpot.Occupy(false);
        }

        public void SetQueueIndex(int index)
        {
            _movement.CanMove = false;

            QueueIndex = index;

            OnQueueIndexChanged?.Invoke(index);

            
            Vector3 destination = index == 0
                ? _queueService.Spot.Position
                : _queueService.GetSlotPoint(index - 1);

            _movement.CanMove = true;
            _movement.MoveTo(destination);

            // _stateMachine.Trigger(index == 0
            //     ? TransportSM.ContinueMoveTrigger
            //     : TransportSM.EnteredQueueTrigger);
        }
    }
}