using UnityEngine;

namespace _BuildSim.Scripts.Logic.Interfaces
{
    public interface IMovement
    {
        bool CanMove { get; set; }
        
        void MoveTo(Vector3 position);
    }
}
