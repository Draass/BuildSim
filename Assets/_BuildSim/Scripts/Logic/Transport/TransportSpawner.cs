using System.Collections.Generic;
using _BuildSim.Scripts.Logic.Interfaces.Transport;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.Transport
{
    public class TransportSpawner : ITransportSpawner
    {
        private readonly ITransportFactory _transportFactory;
        private readonly ITransportSpawnPositionProvider _transportSpawnPositionProvider;
        
        private readonly Dictionary<int, MonoEntity> _spawnedEntities = new Dictionary<int, MonoEntity>();
        
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
            
            _spawnedEntities.Add(transport.InstanceId, transport);
        }

        public void Despawn(int instanceId)
        {
            if (!_spawnedEntities.TryGetValue(instanceId, out var entity))
            {
                Debug.LogWarning($"Transport prefab not found for instance id: {instanceId}");
                return;
            }
            
            Object.Destroy(entity.gameObject);
        }
    }
}