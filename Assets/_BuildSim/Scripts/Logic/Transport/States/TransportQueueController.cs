using System;
using _BuildSim.Scripts.Logic.Interfaces;

namespace _BuildSim.Scripts.Logic.Transport.States
{
    public class TransportQueueController : ITransportQueueController
    {
        public event Action<int> OnQueueIndexChanged;
        
        public int QueueIndex { get; private set; }
        
        private readonly IUnloadSpot _unloadSpot;
        private readonly IMovement _movement;

        public TransportQueueController(IUnloadSpot unloadSpot, IMovement movement)
        {
            _unloadSpot = unloadSpot;
            _movement = movement;
        }
        
        public void StartUnloading()
        {
            // TODO remove this to qaiting queue state probably
            _unloadSpot.Occupy(false);
        }

        public void SetQueueIndex(int index)
        {
            _movement.CanMove = false;
            
            QueueIndex = index;
            
            OnQueueIndexChanged?.Invoke(index);
            
            // TODO в реализации с переходом в состояние передвижения вычислять вручную
            // при одинаковой скорости транспорта нужды нет
            
            // if (_queueIndex < 0)
            // {
            //     return;
            // }
            //
            // return;
            //
            // // TODO получать позицию в очереди для движения из unload spot, вынести вычисления туда
            // Vector3 target = _provider.Position - Vector3.back * QueueSpacing * (_queueIndex + 1);
            //
            // _movement.MoveTo(target);
            // _movement.CanMove = true;
        }
    }
}