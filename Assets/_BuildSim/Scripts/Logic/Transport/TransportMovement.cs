﻿using System;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Pathfinding;
using _BuildSim.Scripts.Logic.Interfaces.Transport;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace _BuildSim.Scripts.Logic.Transport
{
    public class TransportMovement : IMovement, ITickable
    {
        private readonly IAstarAI _astarAI;
        
        private bool _reachedDestinationInvoked;

        public TransportMovement(IPathfinderProvider pathfinderProvider)
        {
            _astarAI = pathfinderProvider.AstarAI;
        }

        public event Action OnDestinationReached;

        public Vector3 Position => _astarAI.position;
        
        public bool CanMove 
        { 
            get => _astarAI.canMove; 
            set => _astarAI.canMove = value; 
        }
        
        public void MoveTo(Vector3 position)
        {
            _reachedDestinationInvoked = false;
            _astarAI.destination = position;
        }

        public void Tick()
        {
            if (!_astarAI.reachedDestination)
            {
                return;
            }
            
            if (_reachedDestinationInvoked)
            {
                return;
            }
                
            OnDestinationReached?.Invoke();
            
            _reachedDestinationInvoked = true;
        }
    }
}