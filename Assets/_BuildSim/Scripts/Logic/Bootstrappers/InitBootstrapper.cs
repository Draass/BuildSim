using System.Collections.Generic;
using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Common;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _BuildSim.Scripts.Logic.Bootstrappers
{
    public class InitBootstrapper : MonoBehaviour
    {
        private IEnumerable<IAsyncLazyInitialize> _initializables;
        private ILoadingScreenController _loadingScreenController;
        private ISceneLoadService _sceneLoadService;

        [Inject]
        private void Construct(
            IEnumerable<IAsyncLazyInitialize> initializables,
            ILoadingScreenController loadingScreenController,
            ISceneLoadService sceneLoadService)
        {
            _initializables = initializables;
            _loadingScreenController = loadingScreenController;
            _sceneLoadService = sceneLoadService;
        }
        
        private void Awake()
        {
            InitializeAsync().Forget();
        }

        private async UniTask InitializeAsync()
        {
            await _loadingScreenController.ShowAsync();
            
            foreach (var initializable in _initializables)
            {
                await initializable.LazyInitialize;
            }
            
            _sceneLoadService.LoadScene(Constants.Scenes.GameScene).Forget();
        }
    }
}