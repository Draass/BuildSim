using UnityEngine;

namespace _BuildSim.Scripts.Logic.Interfaces
{
    // TODO переработать, получать ближайший спот для нужного ресурса с минимальной очередью
    public interface IUnloadSpotProvider
    {
        Vector3 Position { get; }
    }
}