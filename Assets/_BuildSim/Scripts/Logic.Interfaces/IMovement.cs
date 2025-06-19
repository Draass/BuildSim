using System;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.Interfaces
{
    public interface IMovement
    {
        event Action OnDestinationReached;
        
        bool CanMove { get; set; }
        
        void MoveTo(Vector3 position);
    }
}
