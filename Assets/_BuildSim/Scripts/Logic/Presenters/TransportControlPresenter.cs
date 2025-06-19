using _BuildSim.Scripts.Data;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.UI;
using Cysharp.Threading.Tasks;
using DraasGames.Core.Runtime.UI.PresenterNavigationService.Abstract;
using DraasGames.Core.Runtime.UI.Views.Abstract;
using R3;

namespace _BuildSim.Scripts.Logic.Presenters
{
    public class TransportControlPresenter : IPresenter
    {
        private readonly IViewRouter _viewRouter;
        private readonly ITransportSpawner _transportSpawner;
        
        public TransportControlPresenter(
            IViewRouter viewRouter,
            ITransportSpawner transportSpawner)
        {
            _viewRouter = viewRouter;
            _transportSpawner = transportSpawner;
        }
        
        public async UniTask ShowAsync()
        {
            var view = await _viewRouter.ShowAsync<TransportControlView>();

            view.OnSpawnTransportClicked.Subscribe(_ => SpawnTransport()).AddTo(view);
        }

        private void SpawnTransport()
        {
            _transportSpawner.Spawn(Constants.Transport.DefaultTransport);
        }
    }
}