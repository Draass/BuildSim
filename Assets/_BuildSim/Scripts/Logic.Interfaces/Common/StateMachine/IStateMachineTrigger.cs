namespace _BuildSim.Scripts.Logic.Interfaces.Common.StateMachine
{
    public interface IStateMachineTrigger<T>
    {
        void Trigger(string trigger);
    }
}