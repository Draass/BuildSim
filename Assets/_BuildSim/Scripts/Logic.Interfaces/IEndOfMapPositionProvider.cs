using UnityEngine;

namespace _BuildSim.Scripts.Logic.Interfaces
{
    public interface IEndOfMapPositionProvider
    {
        Vector3 Position { get; }
    }
}