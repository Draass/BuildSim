using _BuildSim.Scripts.Logic.Interfaces;
using Pathfinding;
using UnityEngine;

namespace _BuildSim.Scripts.Logic
{
    public class TransportMovement : IMovement
    {
        private readonly IAstarAI _astarAI;

        public TransportMovement(IPathfinderProvider pathfinderProvider)
        {
            _astarAI = pathfinderProvider.AstarAI;
        }
     
        public bool CanMove 
        { 
            get => _astarAI.canMove; 
            set => _astarAI.canMove = value; 
        }
        
        public void MoveTo(Vector3 position)
        {
            _astarAI.destination = position;
        }
    }
}