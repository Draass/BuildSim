using System;
using _BuildSim.Scripts.Logic.Interfaces;
using Pathfinding;
using UnityEngine;
using Zenject;

namespace _BuildSim.Scripts.Logic
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
            _astarAI.destination = position;
            
            _reachedDestinationInvoked = false;
        }

        public void Tick()
        {
            if (!_astarAI.reachedEndOfPath)
            {
                return;
            }
            
            if (_reachedDestinationInvoked)
            {
                return;
            }
                
            Debug.Log("Reached destination");
            
            OnDestinationReached?.Invoke();
            
            _reachedDestinationInvoked = true;
        }
    }
}