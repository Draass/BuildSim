using _BuildSim.Scripts.Logic.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _BuildSim.Scripts.Logic
{
    public class EndOfMapPositionProvider : MonoBehaviour, IEndOfMapPositionProvider
    {
        [SerializeField, Required, SceneObjectsOnly]
        private Transform _target;
        
        public Vector3 Position => _target.position;
    }
}