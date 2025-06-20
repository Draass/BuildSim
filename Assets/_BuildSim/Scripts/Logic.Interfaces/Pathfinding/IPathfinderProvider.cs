using Pathfinding;

namespace _BuildSim.Scripts.Logic.Interfaces.Pathfinding
{
    public interface IPathfinderProvider
    {
        IAstarAI AstarAI { get; }
    }
}