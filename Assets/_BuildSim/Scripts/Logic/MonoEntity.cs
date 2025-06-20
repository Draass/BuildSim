using _BuildSim.Scripts.Logic.Interfaces;
using UnityEngine;

namespace _BuildSim.Scripts.Logic
{
    public class MonoEntity : MonoBehaviour, IEntity
    {
        public int InstanceId => gameObject.GetInstanceID();
    }
}