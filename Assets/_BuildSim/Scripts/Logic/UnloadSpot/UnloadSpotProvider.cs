using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.UnloadSpot;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.UnloadSpot
{
    public class UnloadSpotProvider : MonoBehaviour, IUnloadSpotProvider
    {
        [SerializeField]
        private Transform _unloadSpot;

        public Vector3 Position => _unloadSpot.position;
    }
}