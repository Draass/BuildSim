namespace _BuildSim.Scripts.Logic.Interfaces.Common
{
    public interface IFactory<out T>
    {
        public T Create(string id);
    }
}