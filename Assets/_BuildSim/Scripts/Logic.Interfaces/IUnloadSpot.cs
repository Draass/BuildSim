namespace _BuildSim.Scripts.Logic.Interfaces
{
    public interface IUnloadSpot
    {
        bool IsOccupied { get; }

        bool Occupy(bool state);
    }
}