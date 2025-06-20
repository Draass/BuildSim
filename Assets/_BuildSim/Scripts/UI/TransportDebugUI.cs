using System;
using _BuildSim.Scripts.Data.States;
using _BuildSim.Scripts.Logic.Interfaces;
using _BuildSim.Scripts.Logic.Transport;
using TMPro;
using UnityEngine;
using UnityHFSM;
using Zenject;

namespace _BuildSim.Scripts.UI
{
    public class TransportDebugUI : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text _queueIndex;

        [SerializeField] 
        private TMP_Text _stateText;
        
        private TransportStateMachine _stateMachine;
        private ITransportQueueController _transportQueueController;

        [Inject]
        private void Construct(
            TransportStateMachine stateMachine, 
            ITransportQueueController transportQueueController)
        {
            _stateMachine = stateMachine;
            _transportQueueController = transportQueueController;
        }
        
        private void Awake()
        {
            _stateMachine.StateChanged += StateMachineOnStateChanged;
            _transportQueueController.OnQueueIndexChanged += TransportQueueControllerOnOnQueueControllerIndexChanged;
        }

        private void OnDestroy()
        {
            _stateMachine.StateChanged -= StateMachineOnStateChanged;
            _transportQueueController.OnQueueIndexChanged -= TransportQueueControllerOnOnQueueControllerIndexChanged;
        }

        private void StateMachineOnStateChanged(StateBase<TransportState> obj)
        {
            _stateText.SetText(obj.name.ToString());
        }
        
        private void TransportQueueControllerOnOnQueueControllerIndexChanged(int obj)
        {
            _queueIndex.SetText(obj.ToString());
        }
    }
}