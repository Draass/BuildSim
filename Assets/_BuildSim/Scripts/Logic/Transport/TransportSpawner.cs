using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Transport;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.Transport
{
    public class TransportSpawner : ITransportSpawner
    {
        private readonly ITransportFactory _transportFactory;
        private readonly ITransportSpawnPositionProvider _transportSpawnPositionProvider;
        
        public TransportSpawner(
            ITransportFactory transportFactory,
            ITransportSpawnPositionProvider transportSpawnPositionProvider)
        {
            _transportFactory = transportFactory;
            _transportSpawnPositionProvider = transportSpawnPositionProvider;
        }
        
        public void Spawn(string id)
        {
            var transport = _transportFactory.Create(id);
            
            transport.transform.SetPositionAndRotation(_transportSpawnPositionProvider.Position, Quaternion.identity);
        }
    }
}