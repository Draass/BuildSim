using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Common;
using Cysharp.Threading.Tasks;
using DraasGames.Core.Runtime.Infrastructure.Loaders.Abstract;
using UnityEngine;

namespace _BuildSim.Scripts.Logic.Transport
{
    public class TransportSpawner : ITransportSpawner, IAsyncLazyInitialize
    {
        private readonly IAssetLoader _assetLoader;
        private readonly IScopeLifetimeProvider _scopeLifetimeProvider;
        
        private GameObject _prefab;
        
        public TransportSpawner(
            IAssetLoader assetLoader,
            IScopeLifetimeProvider scopeLifetimeProvider)
        {
            _assetLoader = assetLoader;
            _scopeLifetimeProvider = scopeLifetimeProvider;
            
            LazyInitialize = new AsyncLazy(InitializeAsync);
        }
        
        public AsyncLazy LazyInitialize { get; }
        
        public void Spawn(string id)
        {
            
        }

        private async UniTask InitializeAsync()
        {
            _prefab = await _assetLoader.LoadAsync<GameObject>
                (Constants.Transport.DefaultTransport, _scopeLifetimeProvider.ScopeLifetime);
        }
    }
}