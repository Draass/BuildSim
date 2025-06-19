using System.Collections.Generic;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Common;
using _BuildSim.Scripts.Logic.Presenters;
using _BuildSim.Scripts.UI;
using Cysharp.Threading.Tasks;
using DraasGames.Core.Runtime.UI.PresenterNavigationService.Abstract;
using UnityEngine;
using Zenject;

namespace _BuildSim.Scripts.Logic.Bootstrappers
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IEnumerable<IAsyncLazyInitialize> _initializables;
        private IPresenterNavigationService _presenterNavigation;
        private ILoadingScreenController _loadingScreenController;
        
        private bool _hasInitialized;

        [Inject]
        private void Construct(
            IEnumerable<IAsyncLazyInitialize> initializables,
            IPresenterNavigationService presenterNavigation,
            ILoadingScreenController loadingScreenController)
        {
            _initializables = initializables;
            _presenterNavigation = presenterNavigation;
            _loadingScreenController = loadingScreenController;
        }
        
        private void Awake()
        {
            InitializeAsync().Forget();
        }

        private void Start()
        {
            StartGameAsync().Forget();
        }

        private async UniTaskVoid StartGameAsync()
        {
            await UniTask.WaitUntil(() => _hasInitialized);
            
            await _presenterNavigation.NavigateAsync<TransportControlPresenter>();
            
            _loadingScreenController.Hide();
        }

        private async UniTask InitializeAsync()
        {
            foreach (var initializable in _initializables)
            {
                await initializable.LazyInitialize;
            }
            
            _hasInitialized = true;
        }
    }
}