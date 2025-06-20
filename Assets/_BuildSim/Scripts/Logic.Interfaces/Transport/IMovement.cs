using System;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.Interfaces.Transport
{
    public interface IMovement
    {
        event Action OnDestinationReached;
        
        Vector3 Position { get; }
        
        bool CanMove { get; set; }
        
        void MoveTo(Vector3 position);
    }
}
