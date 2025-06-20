using DraasGames.Core.Runtime.UI.Views.Concrete;
using R3;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _BuildSim.Scripts.UI
{
    public class TransportControlView : View
    {
        [SerializeField, Required, ChildGameObjectsOnly]
        private Button _spawnTransportButton;
        
        [SerializeField, Required, ChildGameObjectsOnly]
        private TMP_InputField _delayInputField;

        public Observable<Unit> OnSpawnTransportClicked { get; private set; }
        
        protected override void Awake()
        {
            base.Awake();

            OnSpawnTransportClicked = _spawnTransportButton.OnClickAsObservable();
        }
    }
}