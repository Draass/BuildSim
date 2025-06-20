using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Pathfinding;
using Pathfinding;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.UnloadSpot
{
    public class PathfinderProvider : MonoBehaviour, IPathfinderProvider
    {
        [field: SerializeField, Required, ChildGameObjectsOnly] 
        private AIPath _aiPath;
        
        public IAstarAI AstarAI => _aiPath;
    }
}