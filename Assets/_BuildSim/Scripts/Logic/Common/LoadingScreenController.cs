using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Common;
using _BuildSim.Scripts.UI;
using Cysharp.Threading.Tasks;
using DraasGames.Core.Runtime.Infrastructure.Loaders.Abstract;
using DraasGames.Core.Runtime.Infrastructure.Loaders.Concrete;
using Zenject;

namespace _BuildSim.Scripts.Logic.Common
{
    public class LoadingScreenController : ILoadingScreenController, IAsyncLazyInitialize
    {
        private readonly IAssetLoader _assetLoader;
        private readonly IInstantiator _instantiator;

        private LoadingView _loadingViewPrefab;
        
        private LoadingView _loadingView;
        
        public LoadingScreenController(
            IAssetLoader assetLoader,
            IInstantiator instantiator)
        {
            _assetLoader = assetLoader;
            _instantiator = instantiator;

            LazyInitialize = new AsyncLazy(InitializeAsync);
        }
        
        public AsyncLazy LazyInitialize { get; }
        
        public async UniTask ShowAsync()
        {
            await LazyInitialize;

            if (!_loadingView)
            {
                _loadingView = _instantiator.InstantiatePrefabForComponent<LoadingView>(_loadingViewPrefab);
            }
            
            _loadingView.Show();
        }

        public void Hide()
        {
            _loadingView?.Hide();
        }

        private async UniTask InitializeAsync()
        {
            _loadingViewPrefab = await _assetLoader.LoadWithComponentAsync<LoadingView>
                (Constants.Screens.LoadingView, ProjectLifetimeHolder.ProjectLifeTime);
        }
    }
}