using Pathfinding;

namespace _BuildSim.Scripts.Logic.Interfaces
{
    public interface IPathfinderProvider
    {
        IAstarAI AstarAI { get; }
    }
}