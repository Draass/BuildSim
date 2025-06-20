using UnityEngine;

namespace _BuildSim.Scripts.Logic.Utilities
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            transform.LookAt(_camera.transform.position);
        }
    }
}