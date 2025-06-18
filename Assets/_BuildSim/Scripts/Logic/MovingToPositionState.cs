using _BuildSim.Scripts.Logic.Interfaces;
using Zenject;

namespace _BuildSim.Scripts.Logic
{
    public class MovingToPositionState : IInitializable
    {
        private readonly IUnloadSpotProvider _unloadSpotProvider;
        private readonly IMovement _movement;

        public MovingToPositionState(
            IUnloadSpotProvider unloadSpotProvider,
            IMovement movement)
        {
            _unloadSpotProvider = unloadSpotProvider;
            _movement = movement;
        }
        
        public void OnEnter()
        {
            _movement.CanMove = true;
            
            _movement.MoveTo(_unloadSpotProvider.Position);
        }

        public void OnLogic()
        {
            
        }

        public void OnExit()
        {
            _movement.CanMove = false;
        }

        public void Initialize()
        {
            OnEnter();
        }
    }
}