using _BuildSim.Scripts.Logic.Interfaces;
using UnityEngine;

namespace _BuildSim.Scripts.Logic
{
    public class UnloadSpotProvider : MonoBehaviour, IUnloadSpotProvider
    {
        [SerializeField]
        private Transform _unloadSpot;

        public Vector3 Position => _unloadSpot.position;
    }
}