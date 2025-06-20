using System;
using _BuildSim.Scripts.Data.States;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Interfaces.Transport;
using Cysharp.Threading.Tasks;
using UnityHFSM;

namespace _BuildSim.Scripts.Logic.Transport.States
{
    public class LeavingMapState : State<TransportState>
    {
        private readonly IMovement _movement;
        private readonly IEndOfMapPositionProvider _endOfMapPositionProvider;
        private readonly ITransportSpawner _transportSpawner;
        private readonly IEntity _entity;
        
        public LeavingMapState(
            IMovement movement,
            IEndOfMapPositionProvider endOfMapPositionProvider,
            ITransportSpawner transportSpawner,
            IEntity entity)
        {
            _movement = movement;
            _endOfMapPositionProvider = endOfMapPositionProvider;
            _transportSpawner = transportSpawner;
            _entity = entity;
        }
        
        public override void OnEnter()
        {
            base.OnEnter();

            // TODO bug when first transport arrives to unload point without queue it is invoked immediately 
            //      because reached desti
            _movement.OnDestinationReached += MovementOnOnDestinationReached;
            
            _movement.CanMove = true;
            
            _movement.MoveTo(_endOfMapPositionProvider.Position);
        }

        private void MovementOnOnDestinationReached()
        {
            _movement.OnDestinationReached -= MovementOnOnDestinationReached;
            
            DespawnTransportDelayed().Forget();
        }

        private async UniTaskVoid DespawnTransportDelayed()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            
            _transportSpawner.Despawn(_entity.InstanceId);
        }
    }
}