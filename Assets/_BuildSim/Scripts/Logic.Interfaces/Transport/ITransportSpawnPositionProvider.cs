using UnityEngine;

namespace _BuildSim.Scripts.Logic.Interfaces.Transport
{
    public interface ITransportSpawnPositionProvider
    {
        Vector3 Position { get; }
    }
}