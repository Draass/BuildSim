using _BuildSim.Scripts.Logic.Interfaces.Transport;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.Transport
{
    public class TransportSpawnPositionProvider : MonoBehaviour, ITransportSpawnPositionProvider
    {
        [SerializeField, Required, SceneObjectsOnly]
        private Transform _transportSpawn;
        
        public Vector3 Position => _transportSpawn.position;
    }
}