using Cysharp.Threading.Tasks;

namespace _BuildSim.Scripts.Logic.Interfaces
{
    public interface ILoadingScreenController
    {
        UniTask ShowAsync();

        void Hide();
    }
}