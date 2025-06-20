using _BuildSim.Scripts.Logic.Interfaces.Common;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace _BuildSim.Scripts.Logic.Common
{
    public class SceneLoadService : ISceneLoadService
    {
        public async UniTask LoadScene(string scene, LoadSceneMode mode)
        {
            await Addressables.LoadSceneAsync(scene, mode);
        }
    }
}