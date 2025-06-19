using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Common;
using _BuildSim.Scripts.UI;
using Cysharp.Threading.Tasks;
using DraasGames.Core.Runtime.Infrastructure.Loaders.Abstract;
using DraasGames.Core.Runtime.Infrastructure.Loaders.Concrete;
using UnityEngine;
using Zenject;

namespace _BuildSim.Scripts.Logic
{
    public class LoadingScreenController : ILoadingScreenController, IAsyncLazyInitialize
    {
        private IAssetLoader _assetLoader;
        private IInstantiator _instantiator;

        private LoadingView _loadingViewPrefab;
        
        private LoadingView _loadingView;
        
        public LoadingScreenController(
            IAssetLoader assetLoader)
        {
            _assetLoader = assetLoader;

            LazyInitialize = new AsyncLazy(InitializeAsync);
        }
        
        public AsyncLazy LazyInitialize { get; }
        
        public async UniTask ShowAsync()
        {
            _loadingView = _instantiator.InstantiatePrefabForComponent<LoadingView>(_loadingViewPrefab);
        }

        public void Hide()
        {
            GameObject.Destroy(_loadingView.gameObject);
        }

        private async UniTask InitializeAsync()
        {
            _loadingViewPrefab = await _assetLoader.LoadWithComponentAsync<LoadingView>
                (Constants.Screens.LoadingView, ProjectLifetimeHolder.ProjectLifeTime);
        }
    }
}