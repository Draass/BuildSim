using Cysharp.Threading.Tasks;

namespace _BuildSim.Scripts.Logic.Interfaces.Common
{
    public interface ILoadingScreenController
    {
        UniTask ShowAsync();

        void Hide();
    }
}