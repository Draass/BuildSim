﻿using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace _BuildSim.Scripts.Logic.Interfaces.Common
{
    public interface ISceneLoadService
    {
        public UniTask LoadScene(string scene, LoadSceneMode loadSceneMode = LoadSceneMode.Single);
    }
}