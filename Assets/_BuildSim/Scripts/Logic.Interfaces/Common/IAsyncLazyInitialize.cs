using Cysharp.Threading.Tasks;

namespace _BuildSim.Scripts.Logic.Interfaces.Common
{
    public interface IAsyncLazyInitialize
    {
        AsyncLazy LazyInitialize { get; }
    }
}