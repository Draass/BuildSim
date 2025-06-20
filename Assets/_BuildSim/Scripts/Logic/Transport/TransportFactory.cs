using System.Collections.Generic;
using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Logic.Interfaces.Common;
using _BuildSim.Scripts.Logic.Interfaces.Transport;
using Cysharp.Threading.Tasks;
using DraasGames.Core.Runtime.Infrastructure.Loaders.Abstract;
using UnityEngine;
using Zenject;

namespace _BuildSim.Scripts.Logic.Transport
{
    public class TransportFactory : ITransportFactory, IAsyncLazyInitialize
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetLoader _assetLoader;
        private readonly IScopeLifetimeProvider _scopeLifetimeProvider;
        
        private readonly Dictionary<string, GameObject> _transportsPrefabs = new();

        public TransportFactory(
            IInstantiator instantiator,
            IAssetLoader assetLoader,
            IScopeLifetimeProvider scopeLifetimeProvider)
        {
            _instantiator = instantiator;
            _assetLoader = assetLoader;
            _scopeLifetimeProvider = scopeLifetimeProvider;
            
            LazyInitialize = new AsyncLazy(InitializeAsync);
        }
        
        public AsyncLazy LazyInitialize { get; }
        
        public GameObject Create(string id)
        {
            var transportPrefab = _transportsPrefabs.GetValueOrDefault(id);

            if (!transportPrefab)
            {
                Debug.LogWarning("Transport prefab not found");
                return null;
            }

            var go = _instantiator.InstantiatePrefab(transportPrefab);
            
            return go;
        }

        private async UniTask InitializeAsync()
        {
            var transport = await _assetLoader.LoadAsync<GameObject>
                (Constants.Transport.DefaultTransport, _scopeLifetimeProvider.ScopeLifetime);
            
            _transportsPrefabs.Add(Constants.Transport.DefaultTransport, transport);
        }
    }
}